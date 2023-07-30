using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace skinchanger_cod4
{
    public class functionality
    {
        static void changeskins(string cod4Pth, string skinsPth, string lengCod) {
            string[] auxListCommands = {
                "Rename-Item -Path " + cod4Pth + "\\main\\iw00.iwd -NewName localized" + lengCod + "_aa.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw01.iwd -NewName localized" + lengCod + "_aab.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw01.iwd -NewName localized" + lengCod + "_aab.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw02.iwd -NewName localized" + lengCod + "_aac.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw03.iwd -NewName localized" + lengCod + "_aad.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw04.iwd -NewName localized" + lengCod + "_aae.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw05.iwd -NewName localized" + lengCod + "_aaf.iwd -Force",
                "Rename-Item -Path " + cod4Pth + "\\main\\iw06.iwd -NewName localized" + lengCod + "_aag.iwd -Force",
                "mkdir " + cod4Pth + "\\temporaryUtilities\\images",
                "Move-Item -Path " + skinsPth + "\\*.iwi -Destination " + cod4Pth + "\\temporaryUtilities\\images -Force",
                "powershell Compress-Archive " + cod4Pth + "\\temporaryUtilities\\images " + cod4Pth + "\\temporaryUtilities\\images.zip",
                "Rename-Item -Path " + cod4Pth + "\\temporaryUtilities\\images.zip -NewName localized" + lengCod + "iw07.iwd -Force",
                "Move-Item -Path " + cod4Pth + "\\temporaryUtilities\\localized" + lengCod + "_iw07.iwd -Destination " + cod4Pth + "\\main -Force",
            };
            PowerShell ps = PowerShell.Create();
            foreach (string c in auxListCommands) {
                ps.AddScript(c);
                ps.Invoke();
                ps.Commands.Clear();
            }
        }
    }
}
