using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace SandBox_202124070
{
    class SandBoxPermissions
    {

        PermissionSet permissions;

        public PermissionSet GetPermissionSet()
        {
            return permissions;
        }

        PermissionState permissionStateValue = PermissionState.None;
        ReflectionPermissionFlag reflectionPermissionFlag = ReflectionPermissionFlag.NoFlags;
        SecurityPermissionFlag securityPermissionFlag = SecurityPermissionFlag.AllFlags;
        FileDialogPermissionAccess fileDialogPermissionAccess = FileDialogPermissionAccess.None;
        FileIOPermissionAccess fileIOPermissionAccess = FileIOPermissionAccess.Read;
        EnvironmentPermissionAccess environmentPermissionAccess = EnvironmentPermissionAccess.Read;
        AspNetHostingPermissionLevel aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.None;
        StorePermissionFlags storePermissionFlags = StorePermissionFlags.AllFlags;
        UIPermissionWindow uIPermissionWindow = UIPermissionWindow.AllWindows;

        internal PermissionSet setPermissionsFromCommand(Dictionary<string, int> str_permissions, string pathToUntrusted)
        {
            try
            {
                foreach (var permission in str_permissions)
                {
                    if (!permission.Key.Equals("") && permission.Key.Equals("-rp"))
                    {
                        switch (permission.Value)
                        {
                            case 7:
                                reflectionPermissionFlag = ReflectionPermissionFlag.AllFlags;
                                break;

                            case 2:
                                reflectionPermissionFlag = ReflectionPermissionFlag.MemberAccess;
                                break;

                            case 0:
                                reflectionPermissionFlag = ReflectionPermissionFlag.NoFlags;
                                break;

                            case 4:
                                reflectionPermissionFlag = ReflectionPermissionFlag.ReflectionEmit;
                                break;

                            case 8:
                                reflectionPermissionFlag = ReflectionPermissionFlag.RestrictedMemberAccess;
                                break;

                            case 1:
                                reflectionPermissionFlag = ReflectionPermissionFlag.TypeInformation;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-sp"))
                    {
                        switch (permission.Value)
                        {
                            case 16383:
                                securityPermissionFlag = SecurityPermissionFlag.AllFlags;
                                break;

                            case 1:
                                securityPermissionFlag = SecurityPermissionFlag.Assertion;
                                break;

                            case 8192:
                                securityPermissionFlag = SecurityPermissionFlag.BindingRedirects;
                                break;

                            case 1024:
                                securityPermissionFlag = SecurityPermissionFlag.ControlAppDomain;
                                break;

                            case 256:
                                securityPermissionFlag = SecurityPermissionFlag.ControlDomainPolicy;
                                break;

                            case 32:
                                securityPermissionFlag = SecurityPermissionFlag.ControlEvidence;
                                break;

                            case 64:
                                securityPermissionFlag = SecurityPermissionFlag.ControlPolicy;
                                break;

                            case 512:
                                securityPermissionFlag = SecurityPermissionFlag.ControlPrincipal;
                                break;

                            case 16:
                                securityPermissionFlag = SecurityPermissionFlag.ControlThread;
                                break;

                            case 8:
                                securityPermissionFlag = SecurityPermissionFlag.Execution;
                                break;

                            case 4096:
                                securityPermissionFlag = SecurityPermissionFlag.Infrastructure;
                                break;

                            case 0:
                                securityPermissionFlag = SecurityPermissionFlag.NoFlags;
                                break;

                            case 2048:
                                securityPermissionFlag = SecurityPermissionFlag.RemotingConfiguration;
                                break;

                            case 4:
                                securityPermissionFlag = SecurityPermissionFlag.SkipVerification;
                                break;

                            case 2:
                                securityPermissionFlag = SecurityPermissionFlag.UnmanagedCode;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-fdp"))
                    {
                        switch (permission.Value)
                        {
                            case 0:
                                fileDialogPermissionAccess = FileDialogPermissionAccess.None;
                                break;

                            case 1:
                                fileDialogPermissionAccess = FileDialogPermissionAccess.Open;
                                break;

                            case 3:
                                fileDialogPermissionAccess = FileDialogPermissionAccess.OpenSave;
                                break;

                            case 2:
                                fileDialogPermissionAccess = FileDialogPermissionAccess.Save;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-fiop"))
                    {
                        switch (permission.Value)
                        {
                            case 15:
                                fileIOPermissionAccess = FileIOPermissionAccess.AllAccess;
                                break;

                            case 4:
                                fileIOPermissionAccess = FileIOPermissionAccess.Append;
                                break;

                            case 0:
                                fileIOPermissionAccess = FileIOPermissionAccess.NoAccess;
                                break;

                            case 8:
                                fileIOPermissionAccess = FileIOPermissionAccess.PathDiscovery;
                                break;

                            case 1:
                                fileIOPermissionAccess = FileIOPermissionAccess.Read;
                                break;

                            case 2:
                                fileIOPermissionAccess = FileIOPermissionAccess.Write;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-anhp"))
                    {
                        switch (permission.Value)
                        {
                            case 500:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.High;
                                break;

                            case 300:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.Low;
                                break;

                            case 400:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.Medium;
                                break;

                            case 200:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.Minimal;
                                break;

                            case 100:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.None;
                                break;

                            case 600:
                                aspNetHostingPermissionLevel = AspNetHostingPermissionLevel.Unrestricted;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-strp"))
                    {
                        switch (permission.Value)
                        {
                            case 32:
                                storePermissionFlags = StorePermissionFlags.AddToStore;
                                break;

                            case 247:
                                storePermissionFlags = StorePermissionFlags.AllFlags;
                                break;

                            case 1:
                                storePermissionFlags = StorePermissionFlags.CreateStore;
                                break;

                            case 2:
                                storePermissionFlags = StorePermissionFlags.DeleteStore;
                                break;

                            case 128:
                                storePermissionFlags = StorePermissionFlags.EnumerateCertificates;
                                break;

                            case 4:
                                storePermissionFlags = StorePermissionFlags.EnumerateStores;
                                break;

                            case 0:
                                storePermissionFlags = StorePermissionFlags.NoFlags;
                                break;

                            case 16:
                                storePermissionFlags = StorePermissionFlags.OpenStore;
                                break;

                            case 64:
                                storePermissionFlags = StorePermissionFlags.RemoveFromStore;
                                break;
                        }
                    }
                    else if (!permission.Key.Equals("") && permission.Key.Equals("-uip"))
                    {
                        switch (permission.Value)
                        {
                            case 3:
                                uIPermissionWindow = UIPermissionWindow.AllWindows;
                                break;

                            case 0:
                                uIPermissionWindow = UIPermissionWindow.NoWindows;
                                break;

                            case 1:
                                uIPermissionWindow = UIPermissionWindow.SafeSubWindows;
                                break;

                            case 2:
                                uIPermissionWindow = UIPermissionWindow.SafeTopLevelWindows;
                                break;
                        }
                    }
                }
                permissions = new PermissionSet(permissionStateValue);
                permissions.AddPermission(new ReflectionPermission(reflectionPermissionFlag));
                Console.WriteLine("ReflectionPermission : " + reflectionPermissionFlag.ToString());

                permissions.AddPermission(new SecurityPermission(securityPermissionFlag));
                Console.WriteLine("SecurityPermission : " + securityPermissionFlag.ToString());

                permissions.AddPermission(new FileDialogPermission(fileDialogPermissionAccess));
                Console.WriteLine("FileDialogPermission : " + fileDialogPermissionAccess.ToString());

                FileIOPermission fileIO;
                if (!fileIOPermissionAccess.Equals(FileIOPermissionAccess.NoAccess))
                {
                    fileIO = new FileIOPermission(PermissionState.Unrestricted);
                    fileIO.AllLocalFiles = fileIOPermissionAccess;
                }
                else
                {
                    fileIO = new FileIOPermission(PermissionState.None);
                    fileIO.AllLocalFiles = fileIOPermissionAccess;
                }

                permissions.AddPermission(fileIO);
                Console.WriteLine("FileIOPermission : " + fileIOPermissionAccess.ToString());

                permissions.AddPermission(new AspNetHostingPermission(aspNetHostingPermissionLevel));
                Console.WriteLine("AspNetHostingPermission : " + aspNetHostingPermissionLevel.ToString());

                permissions.AddPermission(new StorePermission(storePermissionFlags));
                Console.WriteLine("StorePermission : " + storePermissionFlags.ToString());

                permissions.AddPermission(new UIPermission(uIPermissionWindow));
                Console.WriteLine("UIPermission : " + uIPermissionWindow.ToString());

                permissions.Demand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
            return permissions;
        }

        public void setAllPermissions(string pathToUntrusted,
         string reflectionPermission, string securityPermission, string fileDialogPermission,
         string fileIOPermission, string environmentPermission, string pathList, string aspNetHostingPermission,
         string storePermission, string UIPermission)
        {
            try
            {
                //for the UI Permission
                if (null != environmentPermission && !environmentPermission.Equals(""))
                {
                    uIPermissionWindow = (UIPermissionWindow)Enum.Parse(typeof(UIPermissionWindow), UIPermission);
                }
                else
                {
                    MessageBox.Show("Please Select  UI Permission", "Error");
                }

                //for the Store Permission
                if (null != environmentPermission && !environmentPermission.Equals(""))
                {
                    storePermissionFlags = (StorePermissionFlags)Enum.Parse(typeof(StorePermissionFlags), storePermission);
                }
                else
                {
                    MessageBox.Show("Please Select AspNet Hosting Permission", "Error");
                }

                //for the Environment Permission Accesss
                if (null != environmentPermission && !environmentPermission.Equals(""))
                {
                    aspNetHostingPermissionLevel = (AspNetHostingPermissionLevel)Enum.Parse(typeof(AspNetHostingPermissionLevel), aspNetHostingPermission);
                }
                else
                {
                    MessageBox.Show("Please Select AspNet Hosting Permission", "Error");
                }

                //for the Environment Permission Accesss
                if (null != environmentPermission && !environmentPermission.Equals(""))
                {
                    environmentPermissionAccess = (EnvironmentPermissionAccess)Enum.Parse(typeof(EnvironmentPermissionAccess), environmentPermission);
                }
                else
                {
                    MessageBox.Show("Please Select File I/O Permission", "Error");
                }


                //for the SecurityPermission
                if (null != securityPermission && !securityPermission.Equals(""))
                {
                    securityPermissionFlag = (SecurityPermissionFlag)Enum.Parse(typeof(SecurityPermissionFlag), securityPermission);
                }
                else
                {
                    MessageBox.Show("Please Select  Security Permission", "Error");
                }

                //for the ReflectionPermissionFlag
                if (null != reflectionPermission && !reflectionPermission.Equals(""))
                {
                    reflectionPermissionFlag = (ReflectionPermissionFlag)Enum.Parse(typeof(ReflectionPermissionFlag), reflectionPermission);
                }
                else
                {
                    MessageBox.Show("Please Select Reflection Permission", "Error");
                }

                //for the FileDialogPermissionAccess
                if (null != fileDialogPermission && !fileDialogPermission.Equals(""))
                {
                    fileDialogPermissionAccess = (FileDialogPermissionAccess)Enum.Parse(typeof(FileDialogPermissionAccess), fileDialogPermission);
                }
                else
                {
                    MessageBox.Show("Please Select FileDialog Permission", "Error");
                }

                FileIOPermission file = new FileIOPermission(PermissionState.None);
                permissions = new PermissionSet(permissionStateValue);
             
                FileIOPermission fileIO;
                if (!fileIOPermission.Equals(FileIOPermissionAccess.NoAccess.ToString())) {
                    fileIO = new FileIOPermission(PermissionState.Unrestricted);
                    fileIO.AllLocalFiles = fileIOPermissionAccess;
                } else
                {
                    fileIO = new FileIOPermission(PermissionState.None);
                    fileIO.AllLocalFiles = fileIOPermissionAccess;
                }

                permissions.AddPermission(fileIO);
                permissions.AddPermission(new SecurityPermission(securityPermissionFlag));
                permissions.AddPermission(new ReflectionPermission(reflectionPermissionFlag));
                permissions.AddPermission(new FileDialogPermission(fileDialogPermissionAccess));
                permissions.AddPermission(new EnvironmentPermission(environmentPermissionAccess, pathList));
                permissions.AddPermission(new AspNetHostingPermission(aspNetHostingPermissionLevel));
                permissions.AddPermission(new StorePermission(storePermissionFlags));
                permissions.AddPermission(new UIPermission(uIPermissionWindow));
                permissions.Demand();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message, "Error");
            }
        }

        internal PermissionSet getDefaultPermission(string pathToUntrusted)
        {
            permissions = new PermissionSet(PermissionState.Unrestricted);
            permissions.AddPermission(new DnsPermission(permissionStateValue));
            permissions.AddPermission(new SqlClientPermission(permissionStateValue));
            permissions.AddPermission(new WebPermission(permissionStateValue));
            permissions.AddPermission(new TypeDescriptorPermission(permissionStateValue));
            permissions.AddPermission(new ReflectionPermission(reflectionPermissionFlag));
            permissions.AddPermission(new SecurityPermission(securityPermissionFlag));
            permissions.AddPermission(new FileDialogPermission(fileDialogPermissionAccess));

            FileIOPermission fileIO = new FileIOPermission(PermissionState.Unrestricted);
            fileIO.AllLocalFiles = FileIOPermissionAccess.AllAccess;

            permissions.AddPermission(fileIO);
            permissions.AddPermission(new EnvironmentPermission(environmentPermissionAccess, ""));
            permissions.AddPermission(new AspNetHostingPermission(aspNetHostingPermissionLevel));
            permissions.AddPermission(new StorePermission(storePermissionFlags));
            permissions.AddPermission(new UIPermission(uIPermissionWindow));
            permissions.Demand();
            return permissions;
        }
    }
}
