using System.Drawing;
using System.Windows.Forms;
using SEWSE.H1.UX.Infrastructure.Core.Converters;

namespace SEWSE.H1.UX.Infrastructure.Core.Notifications
{
    public class TrayIconHelper
    {
        public static NotifyIcon CreateTrayIcon()
        {
            UriConverter uriConverter = new UriConverter();

            ToolStripMenuItem exitItem = new ToolStripMenuItem
            {
                Image = Image.FromStream(uriConverter.UriToStream("pack://application:,,,/UX.Resource.Core;component/Images/Cross16.png")),
                Text = "Exit"
            };
            exitItem.Click += ExitApplication;

            ContextMenuStrip menuStrip = new ContextMenuStrip();
            menuStrip.Items.Add(exitItem);

            NotifyIcon icon = new NotifyIcon
            {
                Icon = new Icon(uriConverter.UriToStream("pack://application:,,,/UX.Resource.Core;component/Images/H1Icon.ico")),
                Visible = true,
                ContextMenuStrip = menuStrip
            };
            icon.DoubleClick += BringWindowToFront;

            return icon;
        }

        private static void ExitApplication(object sender, System.EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private static void BringWindowToFront(object sender, System.EventArgs e)
        {
            System.Windows.Application.Current.MainWindow.Activate();
            System.Windows.Application.Current.MainWindow.WindowState = System.Windows.WindowState.Maximized;
        }
    }
}