using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Diagnostics;

namespace skinchanger_cod4
{
    public class functionality
    {
        private static void executepower(string command) {
            using (Process psProcess = new Process())
            {
                psProcess.StartInfo.FileName = "powershell.exe";
                psProcess.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"";
                psProcess.StartInfo.RedirectStandardOutput = true;
                psProcess.StartInfo.RedirectStandardError = true;
                psProcess.StartInfo.UseShellExecute = false;
                psProcess.StartInfo.CreateNoWindow = true;

                psProcess.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                psProcess.ErrorDataReceived += (sender, e) => Console.WriteLine("Error: " + e.Data);

                psProcess.Start();
                psProcess.BeginOutputReadLine();
                psProcess.BeginErrorReadLine();
                psProcess.WaitForExit();
            }
        }
        public static void changeskins(string cod4Pth, string skinsPth, string lengCod) {
            int i = 0;
            string[] auxListCommands = {
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_00.iwd -NewName localized_" + lengCod + "_aa.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_01.iwd -NewName localized_" + lengCod + "_aab.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_01.iwd -NewName localized_" + lengCod + "_aab.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_02.iwd -NewName localized_" + lengCod + "_aac.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_03.iwd -NewName localized_" + lengCod + "_aad.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_04.iwd -NewName localized_" + lengCod + "_aae.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_05.iwd -NewName localized_" + lengCod + "_aaf.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw_06.iwd -NewName localized_" + lengCod + "_aag.iwd -Force",
                "mkdir " + cod4Pth + "\\temporaryUtilities\\images",
                "Move-Item -Path " + skinsPth + "\\*.iwi -Destination " + cod4Pth + "\\temporaryUtilities\\images -Force",
                "powershell Compress-Archive " + cod4Pth + "\\temporaryUtilities\\images " + cod4Pth + "\\temporaryUtilities\\images.zip",
                "Rename-Item -Path " + cod4Pth + "\\temporaryUtilities\\images.zip -NewName localized_" + lengCod + "_iw07.iwd -Force",
                "Move-Item -Path " + cod4Pth + "\\temporaryUtilities\\localized_" + lengCod + "_iw07.iwd -Destination " + cod4Pth + "\\main -Force",
            };

            foreach (string c in auxListCommands)
            {
                i = i+1;
                executepower(c);
                if (i == 11) {
                    Thread.Sleep(8000);
                }
                
            }
        }
    }
}
