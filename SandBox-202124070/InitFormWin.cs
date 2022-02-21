using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SandBox_202124070
{
    class InitFormWin : Form
    {
        private Button buttonCancel;
        private ComboBox comboBoxPathFile;
        private Button buttonEnter;
        private Button btnBrowse;
        private Label label1;
        private ComboBox comboBoxPermissionState;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBoxReflectionPermission;
        private Label label5;
        private ComboBox comboBoxSecurityPermission;
        private Label label6;
        private ComboBox comboBoxFileDialogPermission;
        private Label label7;
        private ComboBox comboBoxFileIOPermission;
        private Label labelEnvironmentPermission;
        private ComboBox comboBoxEnvironmentPermission;
        private TextBox textBoxPathList;
        private Label label8;
        private Label label9;
        private ComboBox comboBoxAspNetHostingPermission;
        private Label label10;
        private ComboBox comboBoxStorePermission;
        private Label label11;
        private ComboBox comboBoxUIPermission;
        private Label label12;
        private Label label13;
        private ComboBox comboBoxNetworkAccess;
        private Label label14;
        private ComboBox comboBoxTransportType;
        private Label label15;
        private TextBox textBoxHostName;
        private TextBox textBoxPortNumber;
        private Label label16;
        private string filePath = "";

        public InitFormWin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxPathFile = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPermissionState = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxReflectionPermission = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSecurityPermission = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFileDialogPermission = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxFileIOPermission = new System.Windows.Forms.ComboBox();
            this.labelEnvironmentPermission = new System.Windows.Forms.Label();
            this.comboBoxEnvironmentPermission = new System.Windows.Forms.ComboBox();
            this.textBoxPathList = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxAspNetHostingPermission = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxStorePermission = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBoxUIPermission = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxNetworkAccess = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxTransportType = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxHostName = new System.Windows.Forms.TextBox();
            this.textBoxPortNumber = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(946, 607);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(89, 35);
            this.buttonEnter.TabIndex = 0;
            this.buttonEnter.Text = "Run";
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.RunButtonClick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(833, 607);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(98, 35);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Exit";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxPathFile
            // 
            this.comboBoxPathFile.FormattingEnabled = true;
            this.comboBoxPathFile.IntegralHeight = false;
            this.comboBoxPathFile.Location = new System.Drawing.Point(105, 40);
            this.comboBoxPathFile.Name = "comboBoxPathFile";
            this.comboBoxPathFile.Size = new System.Drawing.Size(826, 28);
            this.comboBoxPathFile.TabIndex = 2;
            this.comboBoxPathFile.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(945, 36);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Permission State : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboBoxPermissionState
            // 
            this.comboBoxPermissionState.DisplayMember = "(none)";
            this.comboBoxPermissionState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPermissionState.FormattingEnabled = true;
            this.comboBoxPermissionState.Items.AddRange(new object[] {
            "None",
            "Unrestricted"});
            this.comboBoxPermissionState.Location = new System.Drawing.Point(163, 115);
            this.comboBoxPermissionState.Name = "comboBoxPermissionState";
            this.comboBoxPermissionState.Size = new System.Drawing.Size(158, 28);
            this.comboBoxPermissionState.TabIndex = 6;
            this.comboBoxPermissionState.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select a file";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Please Select Below Peoperites";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Reflection Permission : ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboBoxReflectionPermission
            // 
            this.comboBoxReflectionPermission.DisplayMember = "(none)";
            this.comboBoxReflectionPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReflectionPermission.FormattingEnabled = true;
            this.comboBoxReflectionPermission.Items.AddRange(new object[] {
            "AllFlags",
            "MemberAccess",
            "NoFlags",
            "ReflectionEmit",
            "RestrictedMemberAccess",
            "TypeInformation"});
            this.comboBoxReflectionPermission.Location = new System.Drawing.Point(163, 154);
            this.comboBoxReflectionPermission.Name = "comboBoxReflectionPermission";
            this.comboBoxReflectionPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxReflectionPermission.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Security Permission : ";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // comboBoxSecurityPermission
            // 
            this.comboBoxSecurityPermission.DisplayMember = "(none)";
            this.comboBoxSecurityPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSecurityPermission.FormattingEnabled = true;
            this.comboBoxSecurityPermission.Items.AddRange(new object[] {
            "AllFlags",
            "Assertion",
            "BindingRedirects",
            "ControlAppDomain",
            "ControlDomainPolicy",
            "ControlEvidence",
            "ControlPolicy",
            "ControlPrincipal",
            "ControlThread",
            "Execution",
            "Infrastructure",
            "NoFlags",
            "RemotingConfiguration",
            "SerializationFormatter",
            "SkipVerification",
            "UnmanagedCode"});
            this.comboBoxSecurityPermission.Location = new System.Drawing.Point(163, 194);
            this.comboBoxSecurityPermission.Name = "comboBoxSecurityPermission";
            this.comboBoxSecurityPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxSecurityPermission.TabIndex = 12;
            this.comboBoxSecurityPermission.SelectedIndexChanged += new System.EventHandler(this.comboBoxSecurityPermission_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "File Dialog Permission : ";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // comboBoxFileDialogPermission
            // 
            this.comboBoxFileDialogPermission.DisplayMember = "(none)";
            this.comboBoxFileDialogPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileDialogPermission.FormattingEnabled = true;
            this.comboBoxFileDialogPermission.Items.AddRange(new object[] {
            "None",
            "Open",
            "OpenSave",
            "Save"});
            this.comboBoxFileDialogPermission.Location = new System.Drawing.Point(163, 233);
            this.comboBoxFileDialogPermission.Name = "comboBoxFileDialogPermission";
            this.comboBoxFileDialogPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxFileDialogPermission.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(152, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "File I/O Permission : ";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // comboBoxFileIOPermission
            // 
            this.comboBoxFileIOPermission.DisplayMember = "(none)";
            this.comboBoxFileIOPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileIOPermission.FormattingEnabled = true;
            this.comboBoxFileIOPermission.Items.AddRange(new object[] {
            "AllAccess",
            "Append",
            "NoAccess",
            "PathDiscovery",
            "Read",
            "Write"});
            this.comboBoxFileIOPermission.Location = new System.Drawing.Point(163, 273);
            this.comboBoxFileIOPermission.Name = "comboBoxFileIOPermission";
            this.comboBoxFileIOPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxFileIOPermission.TabIndex = 16;
            this.comboBoxFileIOPermission.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileIOPermission_SelectedIndexChanged);
            // 
            // labelEnvironmentPermission
            // 
            this.labelEnvironmentPermission.AutoSize = true;
            this.labelEnvironmentPermission.Location = new System.Drawing.Point(30, 313);
            this.labelEnvironmentPermission.Name = "labelEnvironmentPermission";
            this.labelEnvironmentPermission.Size = new System.Drawing.Size(191, 20);
            this.labelEnvironmentPermission.TabIndex = 17;
            this.labelEnvironmentPermission.Text = "Environment Permission : ";
            this.labelEnvironmentPermission.Click += new System.EventHandler(this.label8_Click);
            // 
            // comboBoxEnvironmentPermission
            // 
            this.comboBoxEnvironmentPermission.DisplayMember = "(none)";
            this.comboBoxEnvironmentPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEnvironmentPermission.FormattingEnabled = true;
            this.comboBoxEnvironmentPermission.Items.AddRange(new object[] {
            "AllAccess",
            "NoAccess",
            "Read",
            "Write"});
            this.comboBoxEnvironmentPermission.Location = new System.Drawing.Point(163, 310);
            this.comboBoxEnvironmentPermission.Name = "comboBoxEnvironmentPermission";
            this.comboBoxEnvironmentPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxEnvironmentPermission.TabIndex = 18;
            // 
            // textBoxPathList
            // 
            this.textBoxPathList.Location = new System.Drawing.Point(436, 313);
            this.textBoxPathList.Name = "textBoxPathList";
            this.textBoxPathList.Size = new System.Drawing.Size(282, 26);
            this.textBoxPathList.TabIndex = 19;
            this.textBoxPathList.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(373, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "Path List :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 352);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "AspNet Hosting Permission : ";
            // 
            // comboBoxAspNetHostingPermission
            // 
            this.comboBoxAspNetHostingPermission.DisplayMember = "(none)";
            this.comboBoxAspNetHostingPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAspNetHostingPermission.FormattingEnabled = true;
            this.comboBoxAspNetHostingPermission.Items.AddRange(new object[] {
            "Unrestricted",
            "None",
            "Minimal",
            "Medium",
            "Low",
            "High"});
            this.comboBoxAspNetHostingPermission.Location = new System.Drawing.Point(163, 349);
            this.comboBoxAspNetHostingPermission.Name = "comboBoxAspNetHostingPermission";
            this.comboBoxAspNetHostingPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxAspNetHostingPermission.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(30, 391);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Store Permission : ";
            // 
            // comboBoxStorePermission
            // 
            this.comboBoxStorePermission.DisplayMember = "(none)";
            this.comboBoxStorePermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStorePermission.FormattingEnabled = true;
            this.comboBoxStorePermission.Items.AddRange(new object[] {
            "AddToStore",
            "AllFlags",
            "CreateStore",
            "DeleteStore",
            "EnumerateCertificates",
            "EnumerateStores",
            "NoFlags",
            "OpenStore",
            "RemoveFromStore"});
            this.comboBoxStorePermission.Location = new System.Drawing.Point(163, 388);
            this.comboBoxStorePermission.Name = "comboBoxStorePermission";
            this.comboBoxStorePermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxStorePermission.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 431);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "UI Permission : ";
            // 
            // comboBoxUIPermission
            // 
            this.comboBoxUIPermission.DisplayMember = "(none)";
            this.comboBoxUIPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUIPermission.FormattingEnabled = true;
            this.comboBoxUIPermission.Items.AddRange(new object[] {
            "AllWindows",
            "NoWindows",
            "SafeSubWindows",
            "SafeTopLevelWindows"});
            this.comboBoxUIPermission.Location = new System.Drawing.Point(163, 428);
            this.comboBoxUIPermission.Name = "comboBoxUIPermission";
            this.comboBoxUIPermission.Size = new System.Drawing.Size(158, 28);
            this.comboBoxUIPermission.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 471);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Socket Permission : ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(209, 471);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Network Access ";
            // 
            // comboBoxNetworkAccess
            // 
            this.comboBoxNetworkAccess.DisplayMember = "(none)";
            this.comboBoxNetworkAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNetworkAccess.FormattingEnabled = true;
            this.comboBoxNetworkAccess.Items.AddRange(new object[] {
            "Accept",
            "Connect"});
            this.comboBoxNetworkAccess.Location = new System.Drawing.Point(190, 494);
            this.comboBoxNetworkAccess.Name = "comboBoxNetworkAccess";
            this.comboBoxNetworkAccess.Size = new System.Drawing.Size(158, 28);
            this.comboBoxNetworkAccess.TabIndex = 29;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(402, 471);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 20);
            this.label14.TabIndex = 30;
            this.label14.Text = "Transport Type";
            // 
            // comboBoxTransportType
            // 
            this.comboBoxTransportType.DisplayMember = "(none)";
            this.comboBoxTransportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransportType.FormattingEnabled = true;
            this.comboBoxTransportType.Items.AddRange(new object[] {
            "All",
            "Connectionless",
            "ConnectionOriented",
            "Tcp",
            "Udp"});
            this.comboBoxTransportType.Location = new System.Drawing.Point(377, 494);
            this.comboBoxTransportType.Name = "comboBoxTransportType";
            this.comboBoxTransportType.Size = new System.Drawing.Size(158, 28);
            this.comboBoxTransportType.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(603, 471);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "Host Name";
            // 
            // textBoxHostName
            // 
            this.textBoxHostName.Location = new System.Drawing.Point(571, 494);
            this.textBoxHostName.Name = "textBoxHostName";
            this.textBoxHostName.Size = new System.Drawing.Size(158, 26);
            this.textBoxHostName.TabIndex = 33;
            // 
            // textBoxPortNumber
            // 
            this.textBoxPortNumber.Location = new System.Drawing.Point(773, 494);
            this.textBoxPortNumber.Name = "textBoxPortNumber";
            this.textBoxPortNumber.Size = new System.Drawing.Size(158, 26);
            this.textBoxPortNumber.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(806, 471);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 20);
            this.label16.TabIndex = 35;
            this.label16.Text = "Port Number";
            // 
            // InitFormWin
            // 
            this.ClientSize = new System.Drawing.Size(1052, 670);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBoxPortNumber);
            this.Controls.Add(this.textBoxHostName);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBoxTransportType);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBoxNetworkAccess);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBoxUIPermission);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBoxStorePermission);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxAspNetHostingPermission);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxPathList);
            this.Controls.Add(this.comboBoxEnvironmentPermission);
            this.Controls.Add(this.labelEnvironmentPermission);
            this.Controls.Add(this.comboBoxFileIOPermission);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxFileDialogPermission);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxSecurityPermission);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxReflectionPermission);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxPermissionState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.comboBoxPathFile);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEnter);
            this.Name = "InitFormWin";
            this.Text = "SandBox-202124070";
            this.Load += new System.EventHandler(this.InitFormWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void RunButtonClick(object sender, EventArgs e)
        {
            //filePath = comboBoxPathFile.Text;
            Sandboxer sandboxer = new Sandboxer();
            SandBoxPermissions sandBoxPermissions = new SandBoxPermissions();
            if (null == filePath || filePath.Equals(""))
            {
                MessageBox.Show("Please Select File path", "Error");
            } else
            {
                sandBoxPermissions.setAllPermissions(filePath, (string)comboBoxPermissionState.SelectedItem,
                  (string)comboBoxReflectionPermission.SelectedItem, (string)comboBoxSecurityPermission.SelectedItem,
                  (string)comboBoxFileDialogPermission.SelectedItem, (string)comboBoxFileIOPermission.SelectedItem,
                 (string)comboBoxEnvironmentPermission.SelectedItem, textBoxPathList.Text, (string)comboBoxAspNetHostingPermission.SelectedItem,
                 (string)comboBoxStorePermission.SelectedItem, (string)comboBoxUIPermission.SelectedItem, (string)comboBoxNetworkAccess.SelectedItem,
                 (string)comboBoxTransportType.SelectedItem, textBoxHostName.Text, textBoxPortNumber.Text);

                sandboxer.ExecuteUntrustedCodeFromSandBox(filePath, sandBoxPermissions.GetPermissionSet());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
           // var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    //var fileStream = openFileDialog.OpenFile();

                   // using (StreamReader reader = new StreamReader(fileStream))
                    //{
                     //   fileContent = reader.ReadToEnd();
                    //}


                }

                comboBoxPathFile.Text = filePath;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxSecurityPermission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxFileIOPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void InitFormWin_Load(object sender, EventArgs e)
        {
            comboBoxPermissionState.SelectedIndex = 1;
            comboBoxReflectionPermission.SelectedIndex = 2;
            comboBoxSecurityPermission.SelectedIndex = 11;
            comboBoxFileDialogPermission.SelectedIndex = 1;
            comboBoxFileIOPermission.SelectedIndex = 0;
            comboBoxEnvironmentPermission.SelectedIndex = 0;
            comboBoxAspNetHostingPermission.SelectedIndex = 0;
            comboBoxStorePermission.SelectedIndex = 1;
            comboBoxUIPermission.SelectedIndex = 0;
            comboBoxNetworkAccess.SelectedIndex = 1;
            comboBoxTransportType.SelectedIndex = 0;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
