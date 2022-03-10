using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SandBox_202124070
{
    class CommandExcution
    {
        PermissionSet permissionSet;

        const string execution_path_key = "-exepath";
        const string configuration_key = "-config";

        string execution_path = "";
        string configuration = null;

        public CommandExcution(){}

        internal void excuteCommands(string[] args)
        {
            Sandboxer sandboxer = new Sandboxer();
            SandBoxPermissions sandBoxPermissions = new SandBoxPermissions();

            if (args.Length == 1 && args[0] == "--help")
            {
                Console.WriteLine("SandBox Tool\n");
                Console.WriteLine("-- Usage --");
                Console.WriteLine("SandBox-202124070.exe" + " {0} \"path\" " + "{1} default or \"..config details..\"", execution_path_key, configuration_key);
                Console.WriteLine("Ex:-   SandBox-202124070.exe" + " {0} \" C:\\TestApplication\\WindowsFormsApp.exe\" " + "{1} \"-ps 1,-rp 0,-sp 1024,-fdp 2,-fiop 1,-anhp 300,-strp 0,-uip 1\"", execution_path_key, configuration_key);
               
                Console.WriteLine("\n-- Commands Details --\n");
                
                Console.WriteLine("ReflectionPermission : -rp");
                Console.WriteLine("7-AllFlags");
                Console.WriteLine("2-MemberAccess");
                Console.WriteLine("0-NoFlags");
                Console.WriteLine("4-ReflectionEmit");
                Console.WriteLine("8-RestrictedMemberAccess");
                Console.WriteLine("1-TypeInformation\n");

                Console.WriteLine("SecurityPermission : -sp");
                Console.WriteLine("16383-AllFlags");
                Console.WriteLine("1-Assertion");
                Console.WriteLine("8192-BindingRedirects");
                Console.WriteLine("1024-ControlAppDomain");
                Console.WriteLine("256-ControlDomainPolicy");
                Console.WriteLine("32-ControlEvidence");
                Console.WriteLine("64-ControlPolicy");
                Console.WriteLine("512-ControlPrincipal");
                Console.WriteLine("16-ControlThread");
                Console.WriteLine("8-Execution");
                Console.WriteLine("4096-Infrastructure");
                Console.WriteLine("0-NoFlags");
                Console.WriteLine("2048-RemotingConfiguration");
                Console.WriteLine("4-SkipVerification");
                Console.WriteLine("2-UnmanagedCode\n");

                Console.WriteLine("FileDialogPermission : -fdp");
                Console.WriteLine("0-None");
                Console.WriteLine("1-Open");
                Console.WriteLine("3-OpenSave");
                Console.WriteLine("2-Save\n");

                Console.WriteLine("FileIOPermission : -fiop");
                Console.WriteLine("15-AllAccess");
                Console.WriteLine("4-Append");
                Console.WriteLine("0-NoAccess");
                Console.WriteLine("8-PathDiscovery");
                Console.WriteLine("1-Read");
                Console.WriteLine("2-Write\n");

                Console.WriteLine("AspNetHostingPermission : -anhp");
                Console.WriteLine("500-High");
                Console.WriteLine("300-Low");
                Console.WriteLine("400-Medium");
                Console.WriteLine("200-Minimal");
                Console.WriteLine("100-None");
                Console.WriteLine("600-Unrestricted\n");

                Console.WriteLine("StorePermission : -strp");
                Console.WriteLine("32-AddToStore");
                Console.WriteLine("247-AllFlags");
                Console.WriteLine("1-CreateStore");
                Console.WriteLine("2-DeleteStore");
                Console.WriteLine("128-EnumerateCertificates");
                Console.WriteLine("4-EnumerateStores");
                Console.WriteLine("0-NoFlags");
                Console.WriteLine("16-OpenStore");
                Console.WriteLine("64-RemoveFromStore\n");

                Console.WriteLine("UIPermission : -uip");
                Console.WriteLine("0-NoWindows");
                Console.WriteLine("1-SafeSubWindows");
                Console.WriteLine("3-AllWindows");
                Console.WriteLine("2-SafeTopLevelWindows");

            }
            else
            {
                int index = 1;
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Equals(execution_path_key))
                    {
                        string path = args[i + index];
                        Console.WriteLine("DEBUG -- , CommandExcution :: path : " + path + "\n");
                        execution_path = path;
                        execution_path.Replace("\"", "");
                        Console.WriteLine("DEBUG -- , CommandExcution :: execution_path : " + execution_path + "\n");
                    } 
                    else if (args[i].Equals(configuration_key))
                    {
                        configuration = args[i + 1];
                        if (configuration.Equals("default"))
                        {
                            permissionSet = sandBoxPermissions.getDefaultPermission(execution_path);
                            Console.WriteLine("DEBUG -- , CommandExcution :: sandBoxPermissions.getDefaultPermission(...)\n");
                        }
                        else
                        {
                            Console.WriteLine("DEBUG -- , CommandExcution :: configuration : " + configuration);
                            var str_permissions = new Dictionary<string, int>();
                            string[] arr = configuration.Split(',');
                            
                            foreach (string config in arr)
                            {
                                string[] value = config.Split(' ');
                                str_permissions.Add(value[0], Int32.Parse(value[1]));
                            }
                            foreach (var con in str_permissions)
                            {
                                Console.WriteLine("DEBUG -- , CommandExcution :: map key : " + con.Key + " map value : " + con.Value);
                            }
                            permissionSet = sandBoxPermissions.setPermissionsFromCommand(str_permissions, execution_path);
                        }
                    }
                }

                sandboxer.ExecuteUntrustedCodeFromSandBox(execution_path, permissionSet);

            }
        }
    }
}
