using OpenCvSharp;
using System;

namespace QRCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var img = Cv2.ImRead(@"画像のパス");
            using var straightQrCode = new Mat();
            var qr = new QRCodeDetector();

            var QRCodeContent = qr.DetectAndDecode(img, out var point);
            Console.WriteLine(QRCodeContent);
        }
    }
}
