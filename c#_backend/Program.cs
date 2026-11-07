
using System;
using OpenCvSharp;

namespace Drone
{
    class Program
    {
        static void Main(string[] args)
        {
            using var capture = new VideoCapture(0, VideoCaptureAPIs.V4L2);
            
            if (!capture.IsOpened())
            {
                Console.WriteLine("Error: Cannot connect to webcam index 0.");
                return;
            }

            using var window = new Window("Video frame");
            using var frame = new Mat();
            
            Console.WriteLine("Camera initialized. Press ESC to exit.");

            while(true)
            {
                capture.Read(frame);
                
                if (frame.Empty()) 
                    break;
                    
                window.ShowImage(frame);
                
                if (Cv2.WaitKey(1) == 27) // Press ESC to exit
                    break;
            }
        }
    }
}