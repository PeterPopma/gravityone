using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using SharpAvi.Codecs;
using SharpAvi.Output;
using System.Diagnostics;
using SharpAvi;
using System.Windows.Forms;

namespace GravityOne
{
    internal class ScreenRecorder : IDisposable
    {
        private readonly int screenWidth;
        private readonly int screenHeight;
        private readonly AviWriter writer;
        private readonly IAviVideoStream videoStream;

        Form myParent;

        byte[] buffer;
        Task videoWriteTask = null;
        int shotsTaken = 0;

        public ScreenRecorder(Form myParent_, string fileName,
            FourCC codec, int fps)
        {
            myParent = myParent_;
            screenWidth = myParent.Width;
            screenHeight = myParent.Height;
            buffer = new byte[screenWidth * screenHeight * 4];

            // Create AVI writer and specify FPS
            writer = new AviWriter(fileName)
            {
                FramesPerSecond = fps,
                EmitIndex1 = true,
            };

            // Create video stream
            videoStream = CreateVideoStream(codec, 100);
            // Set only name. Other properties were when creating stream, 
            // either explicitly by arguments or implicitly by the encoder used
            videoStream.Name = "Screencast";
        }

        private IAviVideoStream CreateVideoStream(FourCC codec, int quality)
        {
            // Select encoder type based on FOURCC of codec
            if (codec == KnownFourCCs.Codecs.Uncompressed)
            {
                return writer.AddUncompressedVideoStream(screenWidth, screenHeight);
            }
            else if (codec == KnownFourCCs.Codecs.MotionJpeg)
            {
                return writer.AddMotionJpegVideoStream(screenWidth, screenHeight, quality);
            }
            else
            {
                return writer.AddMpeg4VideoStream(screenWidth, screenHeight, (double)writer.FramesPerSecond,
                    // It seems that all tested MPEG-4 VfW codecs ignore the quality affecting parameters passed through VfW API
                    // They only respect the settings from their own configuration dialogs, and Mpeg4VideoEncoder currently has no support for this
                    quality: quality,
                    codec: codec,
                    // Most of VfW codecs expect single-threaded use, so we wrap this encoder to special wrapper
                    // Thus all calls to the encoder (including its instantiation) will be invoked on a single thread although encoding (and writing) is performed asynchronously
                    forceSingleThreadedAccess: true);
            }
        }

        public void Dispose()
        {
            // Wait for the last frame is written
            if (videoWriteTask != null)
            {
                videoWriteTask.Wait();
            }

            // Close writer: the remaining data is written to a file and file is closed
            writer.Close();
        }

        public void RecordOneFrame()
        {
            GetScreenshot(buffer);

            /*
            Bitmap bitmap = new Bitmap(myParent.Width, myParent.Height);
            myParent.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            var bits = bitmap.LockBits(new Rectangle(0, 0, screenWidth, screenHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
            bitmap.UnlockBits(bits);
            */
            GetScreenshot(buffer);

            shotsTaken++;

            // Wait for the previous frame is written
            if (videoWriteTask != null)
            {
                videoWriteTask.Wait();
            }

            // Start asynchronous (encoding and) writing of the new frame
            videoWriteTask = videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);
        }

        private void GetScreenshot(byte[] buffer)
        {
            using (var bitmap = new Bitmap(screenWidth, screenHeight))
            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(myParent.Left, myParent.Top, 0, 0, new System.Drawing.Size(screenWidth, screenHeight));
                var bits = bitmap.LockBits(new Rectangle(0, 0, screenWidth, screenHeight), ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
                Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
                bitmap.UnlockBits(bits);

                // Should also capture the mouse cursor here, but skipping for simplicity
                // For those who are interested, look at http://www.codeproject.com/Articles/12850/Capturing-the-Desktop-Screen-with-the-Mouse-Cursor
            }
        }

    }

}
