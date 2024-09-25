using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.UX.Api;
using Common.UX.Api.Endpoints;

namespace Common.UX.Wpf.Helpers
{
    public class HelpDeskHelper
    {
        public async static void GetUserScreen()
        {
            var screen = Screen.PrimaryScreen;
            string filePath = Application.StartupPath.ToString() + @"\Logs\";
            if (!Directory.Exists(@filePath))
            {
                Directory.CreateDirectory(@filePath);
            }

            filePath += @"ErrorImages" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";

            byte[] currentImageInBytes;

            using (Bitmap currentScreenShot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height))
            using (var graphics = Graphics.FromImage(currentScreenShot))
            {
                graphics.CopyFromScreen(new Point(screen.Bounds.Left, screen.Bounds.Top), new Point(0, 0), screen.Bounds.Size);
                currentScreenShot.Save(filePath, ImageFormat.Png);
            }
            using (Bitmap currentbitmap = new Bitmap(filePath))
            {
                try
                {
                    currentImageInBytes = await ConvertImageToByteArray(currentbitmap);
                    if (currentImageInBytes.Length > 0)
                    {
                        ServiceHelper.ProcessOperation(ServiceEndpointRoutes.ErrorLog, 
                            ServiceHelperExceptionLogging.ValidationMessage("HelpDesk", UserPreferenceSetupHelper.UserPrincipalGuid, currentImageInBytes),compress:false);
                    }
                }
                catch (Exception e) { }
            }
        }

        private static async Task<byte[]> ConvertImageToByteArray(Image imageSource)
        {
            try
            {
                MemoryStream memoryObj = new MemoryStream();
                await Task.Run(() => { imageSource.Save(memoryObj, ImageFormat.Png); });
                return memoryObj.ToArray();
            }
            catch (Exception) { }
            return null;
        }
    }
}
