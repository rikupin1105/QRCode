using OpenCvSharp;
using System;

namespace QRCode
{
    class Program
    {
        static void Main(string[] args)
        {
            using var straightQrCode = new Mat();
            var qr = new QRCodeDetector();


            var capture = new VideoCapture();
            capture.Open(0);

            using (var normalWindow = new Window("QRCode"))
            {
                var normalFrame = new Mat();
                var srFrame = new Mat();
                while (true)
                {
                    capture.Read(normalFrame);
                    normalWindow.ShowImage(normalFrame);


                    var QRCodeContent = qr.DetectAndDecode(normalFrame, out var point);
                    if (QRCodeContent != "")
                    {
                        Console.WriteLine(QRCodeContent);
                    }


                    Cv2.WaitKey(500);
                }
            }
        }
    }
}
