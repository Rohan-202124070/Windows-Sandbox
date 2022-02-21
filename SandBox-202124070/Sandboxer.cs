using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;
using System.Reflection;
using System.Runtime.Remoting;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Windows.Forms;
using SandBox_202124070;
using System.Web;
using System.Net;
using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

//The Sandboxer class needs to derive from MarshalByRefObject so that we can create it in another
// AppDomain and refer to it from the default AppDomain.


[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Medium)]
class Sandboxer : MarshalByRefObject
{
    const string untrustedAssembly = @"C:\Users\rnire\source\repos\SandBox-202124070\SandBox-202124070\SandBox_202124070_Untrusted.snk";
    const string untrustedClass = "SandBox_202124070.UntrustedClass.cs";
    const string entryPoint = "IsFibonacci";
    private static Object[] parameters = { "main" };

    public void ExecuteUntrustedCodeFromSandBox(string pathToUntrusted, PermissionSet sandBoxPermissions)
    {
        try
        {
            Console.WriteLine("DEBUG -- , Sandboxer :: ExecuteUntrustedCodeFromSandBox(...)\n");

            /*string pluginFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "plugins");
            string plugInPath = Path.Combine(pluginFolder, "winrar-x64-610.exe");*/

            //UntrustedClass untrustedClass = new UntrustedClass();
            //untrustedClass.AssignFileName(pathToUntrusted);

            //Type fileType = typeof(UntrustedClass);
            const string DomainName = "Sandbox";

            var setup = new AppDomainSetup()
            {
                ApplicationBase = Path.GetFullPath(pathToUntrusted),
                ApplicationName = DomainName,
                DisallowBindingRedirects = true,
                DisallowCodeDownload = true,
                DisallowPublisherPolicy = true
            };

            StrongName fullTrustAssembly = typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>();

            Assembly utilAssembly = typeof(Utils).Assembly;
            StrongName utils = utilAssembly.Evidence.GetHostEvidence<StrongName>();

            AppDomain newDomain = AppDomain.CreateDomain("Sandbox", AppDomain.CurrentDomain.Evidence, setup, sandBoxPermissions, utils);
           
            // String[] args= null;
            try
            {
                
                // SetFolderPermission(pathToUntrusted);
                var assembly = Assembly.LoadFile(pathToUntrusted);
                newDomain.ExecuteAssembly(assembly.Location);

                Console.WriteLine("DEBUG -- , Sandboxer :: ExecuteAssembly(...)\n");

                //newDomain.ExecuteAssembly(plugInPath);

                /* ObjectHandle handle = Activator.CreateInstanceFrom(
                     newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName, 
                     typeof(Sandboxer).FullName);

                 Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();
                 newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, parameters);*/


                // System.Diagnostics.Process runProcess = new System.Diagnostics.Process();

                //runProcess.StartInfo.FileName = pathToUntrusted;
                // runProcess.StartInfo.Arguments = "args";

                //runProcess.Start();
                //runProcess.WaitForExit();

                // Thread.Sleep(20000);

                //runProcess.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                AppDomain.Unload(newDomain);
                Console.WriteLine("DEBUG -- , Sandboxer :: Unload(...)\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message, "Error");
        }




        //Use CreateInstanceFrom to load an instance of the Sandboxer class into the
        //new AppDomain.
        /* ObjectHandle handle = Activator.CreateInstanceFrom(
             newDomain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName,
             typeof(Sandboxer).FullName
             );
         //Unwrap the new domain instance into a reference in this domain and use it to execute the
         //untrusted code.
         Sandboxer newDomainInstance = (Sandboxer)handle.Unwrap();
         newDomainInstance.ExecuteUntrustedCode(untrustedAssembly, untrustedClass, entryPoint, parameters);*/
    }


    public static void SetFolderPermission(string folderPath)
    {
        var directoryInfo = new DirectoryInfo(folderPath);
        var directorySecurity = directoryInfo.GetAccessControl();
        var currentUserIdentity = WindowsIdentity.GetCurrent();
        var fileSystemRule = new FileSystemAccessRule(currentUserIdentity.Name,
                                                  FileSystemRights.Read,
                                                  InheritanceFlags.ObjectInherit |
                                                  InheritanceFlags.ContainerInherit,
                                                  PropagationFlags.None,
                                                  AccessControlType.Allow);

        directorySecurity.AddAccessRule(fileSystemRule);
        directoryInfo.SetAccessControl(directorySecurity);
    }


    public void ExecuteUntrustedCode(string assemblyName, string typeName, string entryPoint, Object[] parameters)
    {
        //Load the MethodInfo for a method in the new Assembly. This might be a method you know, or
        //you can use Assembly.EntryPoint to get to the main function in an executable.
        MethodInfo target = Assembly.LoadFile(assemblyName).GetType(typeName).GetMethod(entryPoint);
        try
        {
            //Now invoke the method.
            bool retVal = (bool)target.Invoke(null, parameters);
        }
        catch (Exception ex)
        {
            // When we print informations from a SecurityException extra information can be printed if we are
            //calling it with a full-trust stack.
            new PermissionSet(PermissionState.Unrestricted).Assert();
            Console.WriteLine("SecurityException caught:\n{0}", ex.ToString());
            CodeAccessPermission.RevertAssert();
            Console.ReadLine();
        }
    }

    public void RunAppDomain(string assemblyPath, string[] args)
    {
        const string BaseDirectory = "Untrusted";
        const string DomainName = "Sandbox";
        try
        {
            var setup = new AppDomainSetup()
            {
                ApplicationBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BaseDirectory),
                ApplicationName = DomainName,
                DisallowBindingRedirects = true,
                DisallowCodeDownload = true,
                DisallowPublisherPolicy = true
            };

            var permissions = new PermissionSet(PermissionState.None);
            // permissions.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess));
            //permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

            var domain = AppDomain.CreateDomain(DomainName, null, setup, permissions,
                typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>());

            Activator.CreateInstanceFrom(domain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName, typeof(Sandboxer).FullName).Unwrap();

            new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, assemblyPath).Assert();
            var assembly = Assembly.LoadFile(assemblyPath);
            CodeAccessPermission.RevertAssert();


            domain.Load(assembly.GetName());

            Type[] type = assembly.GetTypes();


            var instance = Activator.CreateInstance(type[0]);

            //AppDomain.Unload(domain);


            //type[0].GetMethod("").Invoke(instance, parameters);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message, "Error");
        }
    }
}
