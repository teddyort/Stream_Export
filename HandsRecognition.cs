using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using SharpAvi;
using SharpAvi.Output;
using BitmapExtension;

namespace hands_viewer.cs
{
    class HandsRecognition
    {
        byte[] LUT;
        private MainForm form;
        private bool _disconnected = false;
        //Queue containing depth image - for synchronization purposes
        private Queue<PXCMImage> m_images;
        private const int NumberOfFramesToDelay = 3;
        private int _framesCounter = 0;
        private float _maxRange;

        public HandsRecognition(MainForm form)
        {
            m_images = new Queue<PXCMImage>();
            this.form = form;
            LUT = Enumerable.Repeat((byte)0, 256).ToArray();
            LUT[255] = 1;
        }

        /* Checking if sensor device connect or not */
        private bool DisplayDeviceConnection(bool state)
        {
            if (state)
            {
                if (!_disconnected) form.UpdateStatus("Device Disconnected");
                _disconnected = true;
            }
            else
            {
                if (_disconnected) form.UpdateStatus("Device Reconnected");
                _disconnected = false;
            }
            return _disconnected;
        }

        /* Displaying current frame gestures */
        private void DisplayGesture(PXCMHandData handAnalysis,int frameNumber)
        {

            int firedGesturesNumber = handAnalysis.QueryFiredGesturesNumber();
            string gestureStatusLeft = string.Empty;
            string gestureStatusRight = string.Empty;
            if (firedGesturesNumber == 0)
            {
              
                return;
            }
           
            for (int i = 0; i < firedGesturesNumber; i++)
            {
                PXCMHandData.GestureData gestureData;
                if (handAnalysis.QueryFiredGestureData(i, out gestureData) == pxcmStatus.PXCM_STATUS_NO_ERROR)
                {
                    PXCMHandData.IHand handData;
                    if (handAnalysis.QueryHandDataById(gestureData.handId, out handData) != pxcmStatus.PXCM_STATUS_NO_ERROR)
                        return;
                   
                    PXCMHandData.BodySideType bodySideType = handData.QueryBodySide();
                    if (bodySideType == PXCMHandData.BodySideType.BODY_SIDE_LEFT)
                    {
                        gestureStatusLeft += "Left Hand Gesture: " + gestureData.name;
                    }
                    else if (bodySideType == PXCMHandData.BodySideType.BODY_SIDE_RIGHT)
                    {
                        gestureStatusRight += "Right Hand Gesture: " + gestureData.name;
                    }
                   
                }
                  
            }
            if (gestureStatusLeft == String.Empty)
                form.UpdateInfo("Frame " + frameNumber + ") " + gestureStatusRight + "\n", Color.SeaGreen);
            else
                form.UpdateInfo("Frame " + frameNumber + ") " + gestureStatusLeft + ", " + gestureStatusRight + "\n",Color.SeaGreen);
          
        }

        /* Displaying Depth/Mask Images - for depth image only we use a delay of NumberOfFramesToDelay to sync image with tracking */
        private unsafe void DisplayPicture(PXCMImage depth, PXCMHandData handAnalysis)
        {
            if (depth == null)
                return;

            PXCMImage image = depth;

            //Mask Image
            if (form.GetLabelmapState())
            {
                Bitmap labeledBitmap = null;
                try
                {
                    labeledBitmap = new Bitmap(image.info.width, image.info.height, PixelFormat.Format32bppRgb);
                    for (int j = 0; j < handAnalysis.QueryNumberOfHands(); j++)
                    {
                        int id;
                        PXCMImage.ImageData data;

                        handAnalysis.QueryHandId(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out id);
                        //Get hand by time of appearance
                        PXCMHandData.IHand handData;
                        handAnalysis.QueryHandData(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, j, out handData);
                        if (handData != null &&
                            (handData.QuerySegmentationImage(out image) >= pxcmStatus.PXCM_STATUS_NO_ERROR))
                        {
                            if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_Y8,
                                out data) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                            {
                                Rectangle rect = new Rectangle(0, 0, image.info.width, image.info.height);

                                BitmapData bitmapdata = labeledBitmap.LockBits(rect, ImageLockMode.ReadWrite,
                                    labeledBitmap.PixelFormat);
                                byte* numPtr = (byte*) bitmapdata.Scan0; //dst
                                byte* numPtr2 = (byte*) data.planes[0]; //row
                                int imagesize = image.info.width*image.info.height;
                                byte num2 = (byte) handData.QueryBodySide();

                                byte tmp = 0;
                                for (int i = 0; i < imagesize; i++, numPtr += 4, numPtr2++)
                                {
                                    tmp = (byte) (LUT[numPtr2[0]]*num2*100);
                                    numPtr[0] = (Byte) (tmp | numPtr[0]);
                                    numPtr[1] = (Byte) (tmp | numPtr[1]);
                                    numPtr[2] = (Byte) (tmp | numPtr[2]);
                                    numPtr[3] = 0xff;
                                }

                                labeledBitmap.UnlockBits(bitmapdata);
                                image.ReleaseAccess(data);
                                
                            }
                        }
                    }
                    if (labeledBitmap != null)
                    {
                        form.DisplayBitmap(labeledBitmap);
                        labeledBitmap.Dispose();
                    }
                    image.Dispose();
                }
                catch (Exception)
                {
                    if (labeledBitmap != null)
                    {
                        labeledBitmap.Dispose();
                    }
                    if (image != null)
                    {
                        image.Dispose();
                    }
                }

            }//end label image

            //Depth Image
            else
            {
                //collecting 3 images inside a queue and displaying the oldest image
                PXCMImage.ImageInfo info;
                PXCMImage image2;

                info = image.QueryInfo();
                image2 = form.g_session.CreateImage(info);
                image2.CopyImage(image);
                m_images.Enqueue(image2);
                if (m_images.Count == NumberOfFramesToDelay)
                {
                    Bitmap depthBitmap;
                    try
                    {
                        depthBitmap = new Bitmap(image.info.width, image.info.height, PixelFormat.Format32bppRgb);
                    }
                    catch (Exception)
                    {
                        image.Dispose();
                        PXCMImage queImage = m_images.Dequeue();
                        queImage.Dispose();
                        return;
                    }

                    PXCMImage.ImageData data3;
                    PXCMImage image3 = m_images.Dequeue();
                    if (image3.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_DEPTH, out data3) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        float fMaxValue = _maxRange;
                        byte cVal;

                        Rectangle rect = new Rectangle(0, 0, image.info.width, image.info.height);
                        BitmapData bitmapdata = depthBitmap.LockBits(rect, ImageLockMode.ReadWrite, depthBitmap.PixelFormat);

                        byte* pDst = (byte*)bitmapdata.Scan0;
                        short* pSrc = (short*)data3.planes[0];
                        int size = image.info.width * image.info.height;

                        for (int i = 0; i < size; i++, pSrc++, pDst += 4)
                        {
                            cVal = (byte)((*pSrc) / fMaxValue * 255);
                            if (cVal != 0)
                                cVal = (byte)(255 - cVal);
                           
                            pDst[0] = cVal;
                            pDst[1] = cVal;
                            pDst[2] = cVal;
                            pDst[3] = 255;
                        }
                        try
                        {
                            depthBitmap.UnlockBits(bitmapdata);
                        }
                        catch (Exception)
                        {
                            image3.ReleaseAccess(data3);
                            depthBitmap.Dispose();
                            image3.Dispose();
                            return;
                        }

                        form.DisplayBitmap(depthBitmap);

                        if (form.GetExportState())
                        {
                            ExportDepthImage(depthBitmap);
                            form.stwDepthFrames.WriteLine(image.QueryTimeStamp());
                        }
                        image3.ReleaseAccess(data3);
                    }
                    depthBitmap.Dispose();
                    image3.Dispose();
                }
            }
        }

        /* Teddy - Displaying the Color Image */
        private unsafe void DisplayColorPicture(PXCMImage image)
        {
            if (image == null)
                return;
            PXCMImage.ImageData data;
            
            Bitmap colorBitmap;
            if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_RGB32, out data) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                colorBitmap = data.ToBitmap(0, image.info.width, image.info.height);
                form.DisplayColorBitmap(colorBitmap);

                if (form.GetExportState())
                {
                    ExportColorImage(colorBitmap);
                }
                image.ReleaseAccess(data);
                colorBitmap.Dispose();
            }
            /*
            try
            {
                colorBitmap = new Bitmap(image.info.width, image.info.height, PixelFormat.Format32bppRgb);
            }
            catch (Exception)
            {
                image.Dispose();
                return;
            }

            
            if (image.AcquireAccess(PXCMImage.Access.ACCESS_READ, PXCMImage.PixelFormat.PIXEL_FORMAT_Y8, out data) >= pxcmStatus.PXCM_STATUS_NO_ERROR)
            {
                float fMaxValue = _maxRange;
                byte cVal;

                Rectangle rect = new Rectangle(0, 0, image.info.width, image.info.height);
                BitmapData bitmapdata = colorBitmap.LockBits(rect, ImageLockMode.ReadWrite, colorBitmap.PixelFormat);

                byte* pDst = (byte*)bitmapdata.Scan0;
                short* pSrc = (short*)data.planes[0];
                int size = image.info.width * image.info.height;

                for (int i = 0; i < size; i++, pSrc++, pDst += 4)
                {
                    cVal = (byte)((*pSrc) / fMaxValue * 255);
                    if (cVal != 0)
                        cVal = (byte)(255 - cVal);

                    pDst[0] = cVal;
                    pDst[1] = cVal;
                    pDst[2] = cVal;
                    pDst[3] = 255;
                }
                try
                {
                    colorBitmap.UnlockBits(bitmapdata);
                }
                catch (Exception)
                {
                    image.ReleaseAccess(data);
                    colorBitmap.Dispose();
                    image.Dispose();
                    return;
                }

                form.DisplayColorBitmap(colorBitmap);

                if (form.GetExportState())
                {
                    ExportColorImage(colorBitmap);
                }
                image.ReleaseAccess(data);
            }
             * 
             */
            image.Dispose();
        }

        /* Calculating the current frames hand joints */
        private PXCMHandData.JointData[][] CalculateJointNodes(PXCMHandData handOutput, out long[] timeStamps)
        {
            if (form.GetJointsState() || form.GetSkeletonState())
            {
                //Iterate hands
                PXCMHandData.JointData[][] nodes = new PXCMHandData.JointData[][] { new PXCMHandData.JointData[0x20], new PXCMHandData.JointData[0x20] };
                int numOfHands = handOutput.QueryNumberOfHands();
                timeStamps = new long[numOfHands];
                for (int i = 0; i < numOfHands; i++)
                {
                    //Get hand by time of appearence
                    //PXCMHandAnalysis.HandData handData = new PXCMHandAnalysis.HandData();
                    PXCMHandData.IHand handData;
                    if (handOutput.QueryHandData(PXCMHandData.AccessOrderType.ACCESS_ORDER_BY_TIME, i, out handData) == pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        if (handData != null)
                        {
                            timeStamps[i] = handData.QueryTimeStamp();

                            //Iterate Joints
                            for (int j = 0; j < 0x20; j++)
                            {
                                PXCMHandData.JointData jointData;
                                handData.QueryTrackedJoint((PXCMHandData.JointType)j, out jointData);
                                nodes[i][j] = jointData;
                            } // end iterating over joints
                        }
                    }
                } // end itrating over hands

                return nodes;
            }
            else
            {
                timeStamps = null;
                return null;
            }
        }

        /* Displaying current frames hand joints */
        private void DisplayJoints(PXCMHandData.JointData[][] nodes, int numOfHands)
        {
               form.DisplayJoints(nodes, numOfHands);
        }

        /* Teddy - Export current frames hand joints*/
        private void ExportJoints(PXCMHandData.JointData[][] nodes, int numOfHands, long[] timeStamps)
        {
            if (nodes == null) return;

            String strRelAngState = "";
            String strRelPosState = "";
            String strAbsAngState = "";
            String strAbsPosState = "";

            //Loop through the hands
            for (int i = 0; i < numOfHands; i++)
            {
                if (nodes[i][0] == null) continue;
                if (form.GetRelAngChecked())
                {
                    strRelAngState += timeStamps[i].ToString() + ", ";
                }
                if (form.GetRelPosChecked())
                {
                    strRelPosState += timeStamps[i].ToString() + ", ";
                }
                if (form.GetAbsAngChecked())
                {
                    strAbsAngState += timeStamps[i].ToString() + ", ";
                }
                if (form.GetAbsPosChecked())
                {
                    strAbsPosState += timeStamps[i].ToString() + ", ";
                }

                for (int j = 0; j < PXCMHandData.NUMBER_OF_JOINTS; j++)
                {
                    if (form.GetRelAngChecked())
                    {
                        PXCMPoint4DF32 ang;
                        ang = nodes[i][j].localRotation;
                        strRelAngState += String.Join(", ", new String[] { ang.x.ToString(), ang.y.ToString(), ang.z.ToString(), ang.w.ToString() }) + ", ";
                    }
                    if (form.GetRelPosChecked())
                    {
                        PXCMPoint3DF32 pos;
                        pos = nodes[i][j].positionImage;
                        strRelPosState += String.Join(", ", new String[] { pos.x.ToString(), pos.y.ToString(), pos.z.ToString() }) + ", ";
                    }
                    if (form.GetAbsAngChecked())
                    {
                        PXCMPoint4DF32 ang;
                        ang = nodes[i][j].globalOrientation;
                        strAbsAngState += String.Join(", ", new String[] { ang.x.ToString(), ang.y.ToString(), ang.z.ToString(), ang.w.ToString() }) + ", ";
                    }
                    if (form.GetAbsPosChecked())
                    {
                        PXCMPoint3DF32 pos;
                        pos = nodes[i][j].positionWorld;
                        strAbsPosState += String.Join(", ", new String[] { pos.x.ToString(), pos.y.ToString(), pos.z.ToString() }) + ", ";
                    }
                        
                        
                }
            }

            //Write the state to the stream
            if (strRelAngState != "")
            {
                form.stwRelAng.WriteLine(strRelAngState.Substring(0, strRelAngState.Length - 2));
            }
            if (strRelPosState != "")
            {
                form.stwRelPos.WriteLine(strRelPosState.Substring(0, strRelPosState.Length - 2));
            }
            if (strAbsAngState != "")
            {
                form.stwAbsAng.WriteLine(strAbsAngState.Substring(0, strAbsAngState.Length - 2));
            }
            if (strAbsPosState != "")
            {
                form.stwAbsPos.WriteLine(strAbsPosState.Substring(0, strAbsPosState.Length - 2));
            }
        }

        /* Teddy - Export current depth frame bitmap to AVI file*/
        private void ExportDepthImage(Bitmap bitmap)
        {
            IAviVideoStream stream = form.GetDepthStream();
            byte[] frame = bitmap.ToByteArray(ImageFormat.Bmp);
            if (stream.FramesWritten == 0)
            {
                stream.Width = bitmap.Width;
                stream.Height = bitmap.Height;
            }
            int intHeader = frame.Length - (stream.Width * stream.Height * 4);
            stream.WriteFrame(true, frame, intHeader, frame.Length-intHeader);
        }

        /* Teddy - Export current color frame bitmap to AVI file*/
        private void ExportColorImage(Bitmap bitmap)
        {
            IAviVideoStream stream = form.GetColorStream();
            byte[] frame = bitmap.ToByteArray(ImageFormat.Bmp);
            if (stream.FramesWritten == 0)
            {
                stream.Width = bitmap.Width;
                stream.Height = bitmap.Height;
            }
            int intHeader = frame.Length - (stream.Width * stream.Height * 4);
            stream.WriteFrame(true, frame, intHeader, frame.Length - intHeader);
        }

        /* Displaying current frame alerts */
        private void DisplayAlerts(PXCMHandData handAnalysis, int frameNumber)
        {
            bool isChanged = false;
            string sAlert = "Alert: ";
            for (int i = 0; i < handAnalysis.QueryFiredAlertsNumber(); i++)
            {
                PXCMHandData.AlertData alertData;
                if (handAnalysis.QueryFiredAlertData(i, out alertData) != pxcmStatus.PXCM_STATUS_NO_ERROR)
                    continue;

                //See PXCMHandAnalysis.AlertData.AlertType for all available alerts
                switch (alertData.label)
                {
                    case PXCMHandData.AlertType.ALERT_HAND_DETECTED:
                        {

                            sAlert += "Hand Detected, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_NOT_DETECTED:
                        {

                            sAlert += "Hand Not Detected, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_CALIBRATED:
                        {

                            sAlert += "Hand Calibrated, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_NOT_CALIBRATED:
                        {

                            sAlert += "Hand Not Calibrated, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_INSIDE_BORDERS:
                        {

                            sAlert += "Hand Inside Border, ";
                            isChanged = true;
                            break;
                        }
                    case PXCMHandData.AlertType.ALERT_HAND_OUT_OF_BORDERS:
                        {

                            sAlert += "Hand Out Of Borders, ";
                            isChanged = true;
                            break;
                        }
                }
            }
            if (isChanged)
            {
                form.UpdateInfo("Frame " + frameNumber + ") " + sAlert + "\n", Color.RoyalBlue);
            }


        }

        public static pxcmStatus OnNewFrame(Int32 mid, PXCMBase module, PXCMCapture.Sample sample)
        {
            return pxcmStatus.PXCM_STATUS_NO_ERROR;
        }

        /* Using PXCMSenseManager to handle data */
        public void SimplePipeline()
        {   
            form.UpdateInfo(String.Empty,Color.Black);
            bool liveCamera = false;

            bool flag = true;
            PXCMSenseManager instance = null;
            _disconnected = false;
            instance = form.g_session.CreateSenseManager();
            if (instance == null)
            {
                form.UpdateStatus("Failed creating SenseManager");
                return;
            }

            if (form.GetRecordState())
            {
                instance.captureManager.SetFileName(form.GetFileName(), true);
                PXCMCapture.DeviceInfo info;
                if (form.Devices.TryGetValue(form.GetCheckedDevice(), out info))
                {
                    instance.captureManager.FilterByDeviceInfo(info);
                }

            }
            else if (form.GetPlaybackState())
            {
                instance.captureManager.SetFileName(form.GetFileName(), false);
            }
            else
            {
                PXCMCapture.DeviceInfo info;
                if (String.IsNullOrEmpty(form.GetCheckedDevice()))
                {
                    form.UpdateStatus("Device Failure");
                    return;
                }

                if (form.Devices.TryGetValue(form.GetCheckedDevice(), out info))
                {
                    instance.captureManager.FilterByDeviceInfo(info);
                }

                liveCamera = true;
            }
            /* Set Module */
            pxcmStatus status = instance.EnableHand(form.GetCheckedModule());
            instance.EnableStream(PXCMCapture.StreamType.STREAM_TYPE_COLOR, 640, 480);

            PXCMHandModule handAnalysis = instance.QueryHand();

            if (status != pxcmStatus.PXCM_STATUS_NO_ERROR || handAnalysis == null)
            {
                form.UpdateStatus("Failed Loading Module");
                return;
            }

            PXCMSenseManager.Handler handler = new PXCMSenseManager.Handler();
            handler.onModuleProcessedFrame = new PXCMSenseManager.Handler.OnModuleProcessedFrameDelegate(OnNewFrame);


            PXCMHandConfiguration handConfiguration = handAnalysis.CreateActiveConfiguration();
            PXCMHandData handData = handAnalysis.CreateOutput();

            if (handConfiguration == null)
            {
                form.UpdateStatus("Failed Create Configuration");
                return;
            }
            if (handData==null)
            {
                form.UpdateStatus("Failed Create Output");
                return;
            }

            if (form.getInitGesturesFirstTime() == false)
            {
                int totalNumOfGestures = handConfiguration.QueryGesturesTotalNumber();
                if (totalNumOfGestures > 0)
                {
                    this.form.UpdateGesturesToList("", 0);
                    for (int i = 0; i < totalNumOfGestures; i++)
                    {
                        string gestureName = string.Empty;
                        if (handConfiguration.QueryGestureNameByIndex(i, out gestureName) ==
                            pxcmStatus.PXCM_STATUS_NO_ERROR)
                        {
                            
                                this.form.UpdateGesturesToList(gestureName, i + 1);
                            
                            
                        }


                    }
                  
                    form.setInitGesturesFirstTime(true);
                    form.UpdateGesturesListSize();
                }
            }


            FPSTimer timer = new FPSTimer(form);
            form.UpdateStatus("Init Started");
            if (handAnalysis != null && instance.Init(handler) == pxcmStatus.PXCM_STATUS_NO_ERROR)
            {

                PXCMCapture.DeviceInfo dinfo;

                PXCMCapture.Device device = instance.captureManager.device;
                if (device != null)
                {
                    device.QueryDeviceInfo(out dinfo);
                    _maxRange = device.QueryDepthSensorRange().max;

                }
               

                if (handConfiguration != null)
                {
                    handConfiguration.EnableAllAlerts();
                    handConfiguration.EnableSegmentationImage(true);
                    handConfiguration.ApplyChanges();
                    handConfiguration.Update();
                }
                form.UpdateStatus("Streaming");
                int frameCounter = 0;
                int frameNumber = 0;

                while (!form.stop)
                {

                    string gestureName = form.GetGestureName();
                    if (string.IsNullOrEmpty(gestureName) == false)
                    {
                        if (handConfiguration.IsGestureEnabled(gestureName) == false)
                        {
                            handConfiguration.DisableAllGestures();
                            handConfiguration.EnableGesture(gestureName, true);
                            handConfiguration.ApplyChanges();
                        }
                    }
                    else
                    {
                        handConfiguration.DisableAllGestures();
                        handConfiguration.ApplyChanges();
                    }
                    

                    if (instance.AcquireFrame(true) < pxcmStatus.PXCM_STATUS_NO_ERROR)
                    {
                        break;
                    }

                    frameCounter++;
                    this._framesCounter = frameCounter;

                    if (!DisplayDeviceConnection(!instance.IsConnected()))
                    {

                        if (handData != null)
                        {
                            handData.Update();
                        }

                        //Teddy - Allows capturing the color stream if enabled
                        PXCMCapture.Sample sample; 
                        if (form.isColorEnabled())
                        {
                            sample = instance.QuerySample();
                        }
                        else
                        {
                            sample = instance.QueryHandSample();
                        }

                        if (sample != null && sample.depth != null)
                        {
                            DisplayPicture(sample.depth, handData);

                            //Teddy - Displays the color stream on the form
                            if (form.isColorEnabled() == true && sample.color != null)
                            {
                                DisplayColorPicture(sample.color); 
                            }


                            if (handData != null)
                            {
                                frameNumber = liveCamera ? frameCounter : instance.captureManager.QueryFrameIndex(); 
                                long[] timeStamps;
                                PXCMHandData.JointData[][] nodes = CalculateJointNodes(handData, out timeStamps);
                                int numOfHands = handData.QueryNumberOfHands();
                                if(form.GetExportState())
                                {
                                    if(form.GetJointsState())
                                    {
                                        ExportJoints(nodes, numOfHands, timeStamps);
                                    }
                                }
                                DisplayJoints(nodes, numOfHands);
                                DisplayGesture(handData,frameNumber);
                                DisplayAlerts(handData, frameNumber);
                            }
                            form.UpdatePanel();
                        }


                        timer.Tick();
                    }
                    instance.ReleaseFrame();
                }
            }
            else
            {
                form.UpdateStatus("Init Failed");
                flag = false;
            }
            foreach (PXCMImage pxcmImage in m_images)
            {
                pxcmImage.Dispose();
            }

            // Clean Up
            if (handData != null) handData.Dispose();
            if (handConfiguration != null) handConfiguration.Dispose();
            instance.Close();
            instance.Dispose();

            if (flag)
            {
                form.UpdateStatus("Stopped");
            }
        }

    }
}
