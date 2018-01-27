﻿using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace WebCrunch.Utilities
{
    class Updates
    {
        // check for updates, installs installer to downloads folder if available and opens it
        public static void checkForUpdate()
        {
            Version newVersion = null;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(MainForm.linkLatestVersion);
            StreamReader reader = new StreamReader(stream);
            newVersion = new Version(reader.ReadToEnd());
            Version curVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            //if (curVersion.CompareTo(newVersion) < 0)
            if (curVersion.CompareTo(newVersion) > 0)
            {
                MessageBox.Show(MainForm.form, "WebCrunch " + newVersion.ToString() + " is ready to be installed.", "WebCrunch - Update Available");

                //client.DownloadFile(MainForm.getLatestInstaller(newVersion), MainForm.pathDownloadInstaller);
                //Directory.Delete(MainForm.pathData, true);
                //Process.Start(MainForm.pathDownloadInstaller);
                Process.Start(Application.StartupPath + @"\AutoUpdater.exe");
                Application.Exit();
            }
        }
    }
}