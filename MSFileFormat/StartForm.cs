/*
 * Copyright (C) 2006-2014 Robert Iwancz
 * 
 * Released under the GNU General Public License.  See LICENSE.TXT
 * 
 */ 
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace MSFileFormat
{
	/// <summary>
	/// Summary description for StartForm.
	/// </summary>
	public class StartForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox DataFilesGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox DirectoryText;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnXMaster;
        private System.Windows.Forms.Button btnEMaster;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StartForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.DataFilesGroup = new System.Windows.Forms.GroupBox();
            this.btnEMaster = new System.Windows.Forms.Button();
            this.btnXMaster = new System.Windows.Forms.Button();
            this.btnMaster = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.DirectoryText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DataFilesGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataFilesGroup
            // 
            this.DataFilesGroup.Controls.Add(this.btnEMaster);
            this.DataFilesGroup.Controls.Add(this.btnXMaster);
            this.DataFilesGroup.Controls.Add(this.btnMaster);
            this.DataFilesGroup.Controls.Add(this.BrowseButton);
            this.DataFilesGroup.Controls.Add(this.DirectoryText);
            this.DataFilesGroup.Controls.Add(this.label1);
            this.DataFilesGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.DataFilesGroup.Location = new System.Drawing.Point(16, 16);
            this.DataFilesGroup.Name = "DataFilesGroup";
            this.DataFilesGroup.Size = new System.Drawing.Size(632, 176);
            this.DataFilesGroup.TabIndex = 0;
            this.DataFilesGroup.TabStop = false;
            this.DataFilesGroup.Text = "Data Files";
            // 
            // btnEMaster
            // 
            this.btnEMaster.Enabled = false;
            this.btnEMaster.Location = new System.Drawing.Point(220, 96);
            this.btnEMaster.Name = "btnEMaster";
            this.btnEMaster.Size = new System.Drawing.Size(88, 56);
            this.btnEMaster.TabIndex = 5;
            this.btnEMaster.Text = "EMASTER";
            this.btnEMaster.Click += new System.EventHandler(this.btnEMaster_Click);
            // 
            // btnXMaster
            // 
            this.btnXMaster.Enabled = false;
            this.btnXMaster.Location = new System.Drawing.Point(424, 96);
            this.btnXMaster.Name = "btnXMaster";
            this.btnXMaster.Size = new System.Drawing.Size(88, 56);
            this.btnXMaster.TabIndex = 4;
            this.btnXMaster.Text = "XMASTER";
            this.btnXMaster.Click += new System.EventHandler(this.btnXMaster_Click);
            // 
            // btnMaster
            // 
            this.btnMaster.Enabled = false;
            this.btnMaster.Location = new System.Drawing.Point(16, 96);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Size = new System.Drawing.Size(88, 56);
            this.btnMaster.TabIndex = 3;
            this.btnMaster.Text = "MASTER";
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(528, 56);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(80, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // DirectoryText
            // 
            this.DirectoryText.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.DirectoryText.Location = new System.Drawing.Point(16, 56);
            this.DirectoryText.Name = "DirectoryText";
            this.DirectoryText.ReadOnly = true;
            this.DirectoryText.Size = new System.Drawing.Size(496, 22);
            this.DirectoryText.TabIndex = 1;
            this.DirectoryText.Text = "";
            this.DirectoryText.TextChanged += new System.EventHandler(this.DirectoryText_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directory:";
            // 
            // StartForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(672, 245);
            this.Controls.Add(this.DataFilesGroup);
            this.Font = new System.Drawing.Font("Bitstream Vera Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Name = "StartForm";
            this.Text = "MetaStock File Format Viewer";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.DataFilesGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        //[STAThread]
        //public static void Main() {
        //    Application.Run(new StartForm());
        //}

        private void DirectoryText_TextChanged(object sender, System.EventArgs e) {
            TextBox txt = (TextBox) sender;
            if (Directory.Exists(txt.Text)) {
                btnMaster.Enabled = (File.Exists(Path.Combine(txt.Text, "MASTER")));
                btnEMaster.Enabled = (File.Exists(Path.Combine(txt.Text, "EMASTER")));
                btnXMaster.Enabled = (File.Exists(Path.Combine(txt.Text, "XMASTER")));
            }
            else {
                 txt.Text = "";
            }
        }

        private void StartForm_Load(object sender, System.EventArgs e) {
            DirectoryText.Text = "C:\\Temp\\ASXGame\\";
        }

        private void BrowseButton_Click(object sender, System.EventArgs e) {
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.AddExtension = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                DirectoryText.Text = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
            }
        }

        private void btnMaster_Click(object sender, System.EventArgs e) {
            MasterForm form = new MasterForm(DirectoryText.Text);
            form.Show();
        }

        private void btnEMaster_Click(object sender, System.EventArgs e) {
            EMasterForm form = new EMasterForm(DirectoryText.Text);
            form.Show();        
        }

        private void btnXMaster_Click(object sender, System.EventArgs e) {
            XMasterForm form = new XMasterForm(DirectoryText.Text);
            form.Show();                
        }

	}
}
