using MachineBox.Core.Globals;
using MachineBox.SelfHost;
using System;
using System.Configuration;
using System.Deployment.Application;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineBox.Win
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            StartServer();

            Hook();

            TurnOnAutoUpdate();

            AddShortcut();

            Text = $"MachineBox v{GetRunningVersion().ToString()}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Version GetRunningVersion()
        {
            try
            {
                return ApplicationDeployment.CurrentDeployment.CurrentVersion;
            }
            catch
            {
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool StartServer()
        {
            try
            {
                Print("Server is starting..");

                var port = int.Parse(ConfigurationManager.AppSettings["port"]);

                NancySelfHost.Start(port);

                Print($"Server started successfully");

                Print($"Listening on http://localhost:{port}");

                return true;
            }
            catch(Exception e)
            {
                Print(e.Message);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool Hook()
        {
            try
            {
                Print("Hooking keyboard...");

                USBHIDGlobal.KeyboardHook.KeyDown += (sender, e) =>
                {
                    if (!USBHIDGlobal.Wait)
                        if (e == USBHIDGlobal.END_CHAR)
                            USBHIDGlobal.Wait = true;
                        else
                            USBHIDGlobal.Text += (char)e;
                };

                Print("Hooked successfully");

                return true;
            }
            catch (Exception e)
            {
                Print(e.Message);

                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void TurnOnAutoUpdate()
        {
            Print("Auto-update turned on");

            tmrUpdate.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void AddShortcut()
        {
            try
            {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.Startup) + @"\kiosk.bat";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (var tw = new StreamWriter(path, false))
                {
                    tw.WriteLine("start chrome --kiosk http://localhost:4000");

                    tw.Close();
                }

                Print("Shortcut added successfully");
            }
            catch (Exception e)
            {
                Print(e.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        private void Print(string value)
        {
            txtSummary.AppendText(String.Format("{0:dd.MM.yyyy HH:mm:ss} - {1}{2}", DateTime.Now, value, Environment.NewLine));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrUpdate_Tick(object sender, EventArgs e)
        {
            var info = default(UpdateCheckInfo);

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                var ad = ApplicationDeployment.CurrentDeployment;

                try
                {
                    info = ad.CheckForDetailedUpdate();

                    if (info.UpdateAvailable)
                    {
                        Print("New version " + info.AvailableVersion + " is available");

                        Print("Installing...");

                        if (ad.Update())
                        {
                            Print("Successfully updated");

                            Print("Restarting...");

                            Application.Restart();
                        }
                        else
                            Print("Update failed");
                    }
                }
                catch(Exception ex)
                {
                    Print(ex.Message);
                }
            }
        }


    }
}
