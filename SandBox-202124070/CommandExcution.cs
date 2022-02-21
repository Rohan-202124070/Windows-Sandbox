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
        
        Regex regex = new Regex("\"(.*?)\"");

        const string execution_path_key = "-exepath";
        const string configuration_key = "-config";

        string execution_path = "";
        string configuration = null;

        public CommandExcution()
        {
            Console.WriteLine("DEBUG -- , CommandExcution :: Sandbox Application Inprogress");
        }

        internal void excuteCommands(string[] args)
        {
            Sandboxer sandboxer = new Sandboxer();
            SandBoxPermissions sandBoxPermissions = new SandBoxPermissions();

            if (args.Length == 1 && args[0] == "--help")
            {
                Console.WriteLine("WelCome!!!, Trustworthy ACW1 SandBox Tool\n");
                Console.WriteLine("Usage --");
                Console.WriteLine("program.exe" + " {0} \"path\" " + "{1} default or <..config details..>" , execution_path_key, configuration_key);
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
