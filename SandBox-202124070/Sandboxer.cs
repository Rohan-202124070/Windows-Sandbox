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
            const string DomainName = "Sandbox";
            var setup = new AppDomainSetup()
            {
                ApplicationBase = Path.GetFullPath(pathToUntrusted),
                ApplicationName = DomainName,
                DisallowBindingRedirects = true,
                DisallowCodeDownload = true,
                DisallowPublisherPolicy = true
            };

            Assembly assembly = typeof(Utils).Assembly;
            StrongName fullTrustAssembly = assembly.Evidence.GetHostEvidence<StrongName>();
            var platform = Assembly.GetExecutingAssembly();
            var name = platform.FullName + ": Sandbox " + Guid.NewGuid();
            var setup1 = new AppDomainSetup { ApplicationBase = Path.GetDirectoryName(platform.Location) };

            var newDomain = AppDomain.CreateDomain(name, null, setup1, sandBoxPermissions);
            try
            {
                newDomain.ExecuteAssembly(pathToUntrusted);

                Console.WriteLine("DEBUG -- , Sandboxer :: ExecuteAssembly(...)\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message , "Error");
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
            var domain = AppDomain.CreateDomain(DomainName, null, setup, permissions,
                typeof(Sandboxer).Assembly.Evidence.GetHostEvidence<StrongName>());

            Activator.CreateInstanceFrom(domain, typeof(Sandboxer).Assembly.ManifestModule.FullyQualifiedName, typeof(Sandboxer).FullName).Unwrap();

            new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, assemblyPath).Assert();
            var assembly = Assembly.LoadFile(assemblyPath);
            CodeAccessPermission.RevertAssert();
            domain.Load(assembly.GetName());
            Type[] type = assembly.GetTypes();
            var instance = Activator.CreateInstance(type[0]);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message, "Error");
        }
    }
}
