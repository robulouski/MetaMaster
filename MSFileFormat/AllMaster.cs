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
using System.Text;
using System.Runtime.InteropServices;

// <!--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd"> -->


namespace MSFileFormat
{
	/// <summary>
	/// Summary description for Master.
	/// </summary>
	public class AllMaster : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox HeaderGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RecordsText;
        private System.Windows.Forms.TextBox MaxText;
        private System.Windows.Forms.TextBox RemainText;
        private System.Windows.Forms.ColumnHeader RecNumHeader;
        private System.Windows.Forms.ColumnHeader SymbolHeader;
        private System.Windows.Forms.ColumnHeader NameHeader;
        private System.Windows.Forms.ListView StockView;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel Toppanel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AllMaster()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			LoadMasterFile();
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
            this.HeaderGroupBox = new System.Windows.Forms.GroupBox();
            this.RemainText = new System.Windows.Forms.TextBox();
            this.MaxText = new System.Windows.Forms.TextBox();
            this.RecordsText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StockView = new System.Windows.Forms.ListView();
            this.RecNumHeader = new System.Windows.Forms.ColumnHeader();
            this.SymbolHeader = new System.Windows.Forms.ColumnHeader();
            this.NameHeader = new System.Windows.Forms.ColumnHeader();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.Toppanel = new System.Windows.Forms.Panel();
            this.HeaderGroupBox.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.Toppanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderGroupBox
            // 
            this.HeaderGroupBox.Controls.Add(this.RemainText);
            this.HeaderGroupBox.Controls.Add(this.MaxText);
            this.HeaderGroupBox.Controls.Add(this.RecordsText);
            this.HeaderGroupBox.Controls.Add(this.label3);
            this.HeaderGroupBox.Controls.Add(this.label2);
            this.HeaderGroupBox.Controls.Add(this.label1);
            this.HeaderGroupBox.Location = new System.Drawing.Point(24, 16);
            this.HeaderGroupBox.Name = "HeaderGroupBox";
            this.HeaderGroupBox.Size = new System.Drawing.Size(728, 104);
            this.HeaderGroupBox.TabIndex = 0;
            this.HeaderGroupBox.TabStop = false;
            this.HeaderGroupBox.Text = "Header";
            // 
            // RemainText
            // 
            this.RemainText.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.RemainText.Location = new System.Drawing.Point(264, 16);
            this.RemainText.Multiline = true;
            this.RemainText.Name = "RemainText";
            this.RemainText.ReadOnly = true;
            this.RemainText.Size = new System.Drawing.Size(432, 72);
            this.RemainText.TabIndex = 5;
            this.RemainText.Text = "";
            // 
            // MaxText
            // 
            this.MaxText.Location = new System.Drawing.Point(96, 64);
            this.MaxText.Name = "MaxText";
            this.MaxText.ReadOnly = true;
            this.MaxText.Size = new System.Drawing.Size(80, 20);
            this.MaxText.TabIndex = 4;
            this.MaxText.Text = "";
            // 
            // RecordsText
            // 
            this.RecordsText.Location = new System.Drawing.Point(96, 32);
            this.RecordsText.Name = "RecordsText";
            this.RecordsText.ReadOnly = true;
            this.RecordsText.Size = new System.Drawing.Size(80, 20);
            this.RecordsText.TabIndex = 3;
            this.RecordsText.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(192, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "All the rest:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max Record:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Records:";
            // 
            // StockView
            // 
            this.StockView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.RecNumHeader,
                                                                                        this.SymbolHeader,
                                                                                        this.NameHeader});
            this.StockView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockView.FullRowSelect = true;
            this.StockView.Location = new System.Drawing.Point(0, 0);
            this.StockView.Name = "StockView";
            this.StockView.Size = new System.Drawing.Size(784, 533);
            this.StockView.TabIndex = 1;
            this.StockView.View = System.Windows.Forms.View.Details;
            // 
            // RecNumHeader
            // 
            this.RecNumHeader.Text = "Rec";
            // 
            // SymbolHeader
            // 
            this.SymbolHeader.Text = "Symbol";
            // 
            // NameHeader
            // 
            this.NameHeader.Text = "Name";
            this.NameHeader.Width = 271;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.StockView);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomPanel.Location = new System.Drawing.Point(0, 168);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(784, 533);
            this.BottomPanel.TabIndex = 2;
            // 
            // Toppanel
            // 
            this.Toppanel.Controls.Add(this.HeaderGroupBox);
            this.Toppanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Toppanel.Location = new System.Drawing.Point(0, 0);
            this.Toppanel.Name = "Toppanel";
            this.Toppanel.Size = new System.Drawing.Size(784, 168);
            this.Toppanel.TabIndex = 3;
            // 
            // AllMaster
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(784, 701);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.Toppanel);
            this.Name = "AllMaster";
            this.Text = "Master";
            this.HeaderGroupBox.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.Toppanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

        
        struct MasterRec {
            public byte FileNumber;
            public byte FileType1, FileType2;  // CT file type = 0'e' (5 or 7 flds)
            public byte RecLen;                //record length in bytes (4 x NumFields)
            public byte NumFields;
            public byte Reserved1;
            public byte CenturyIndicator;      // (Or reserved???)
            public string Name;                // 16 bytes
            public byte Reserved2;
            public byte CTFlag;                // ????? if CT ver. 2.8, 'Y'; o.w., anything else
            public uint FirstDate;            // 4 bytes MBF
            public uint LastDate;             // 4 bytes MBF
            public byte TimeInterval;          // (D,W,M) 1 Char
            public ushort IDATimeBase;         // Intraday time base (Or reserved??)
            public string Symbol;              // 14 bytes
            public byte Reserved3;             // Must be a space for Metastock???
            public byte Flag;                  // ' ' or '*' for autorun
            public byte Reserved4;
            
            public string [] ToStringArray() {
                string file_type = String.Format("{0:X2} {1:X2}", FileType1, FileType2);
                float first_date = 0, last_date = 0;
                ConvertToIeeeFloat(FirstDate, ref first_date);
                ConvertToIeeeFloat(LastDate, ref last_date);
                return new string [] {
                    FileNumber.ToString(),
                    file_type,
                    RecLen.ToString(),
                    NumFields.ToString(),
                    Reserved1.ToString("X2"),
                    CenturyIndicator.ToString("X2"),
                    Name,
                    Reserved2.ToString("X2"),
                    CTFlag.ToString("X2"),
                    first_date.ToString(),
                    last_date.ToString(),
                    new string((char) TimeInterval, 1),
                    IDATimeBase.ToString(),
                    Symbol,
                    Reserved3.ToString("X2"),
                    Flag.ToString("X2"),
                    Reserved4.ToString("X2")
                                     };
            }
        };



        public void LoadMasterFile() {
            this.SuspendLayout();
            StockView.Columns.Clear();
            StockView.Columns.Add("Num", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("FileType", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("RecLen", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("NumFields", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Res1", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("CI", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Name", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("Res2", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("CT", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("FirstDate", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("LastDate", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("TimeInt", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("IDTB", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Symbol", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("Res3", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Flag", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Res4", -2, HorizontalAlignment.Left);


            FileStream fs = null;
            BinaryReader br = null;
            //using (FileStream fs = new FileStream("C:\\Temp\\ASXGame\\Master", FileMode.Open)) 
            try {
                fs = new FileStream("C:\\Temp\\ASXGame\\Master", FileMode.Open);
                br = new BinaryReader(fs);
                int num = br.ReadInt16();
                int max = br.ReadInt16();
                byte[] buffer = br.ReadBytes(49);
                RecordsText.Text = num.ToString();
                MaxText.Text = max.ToString();
                RemainText.Text = ConvertToHex(buffer, 16);

                //byte[] tempbuf = new byte[200];
                char[] namebuf = new char[20];
                char[] symbuf = new char [20];
                ListViewItem lvi;
                MasterRec rec;

                for (int i = 0; i < num; i++) {
                    rec.FileNumber = br.ReadByte();    
                    rec.FileType1 = br.ReadByte();
                    rec.FileType2 = br.ReadByte();
                    rec.RecLen = br.ReadByte();
                    rec.NumFields = br.ReadByte();
                    rec.Reserved1 = br.ReadByte();
                    rec.CenturyIndicator = br.ReadByte();
                    br.Read(namebuf, 0, 16);
                    rec.Name = new string(namebuf);
                    rec.Reserved2 = br.ReadByte();
                    rec.CTFlag = br.ReadByte();
                    rec.FirstDate = br.ReadUInt32();
                    rec.LastDate = br.ReadUInt32();
                    rec.TimeInterval = br.ReadByte();
                    rec.IDATimeBase = br.ReadUInt16();
                    br.Read(symbuf, 0, 14);
                    rec.Symbol = new string(symbuf);
                    rec.Reserved3 = br.ReadByte();
                    rec.Flag = br.ReadByte();
                    rec.Reserved4 = br.ReadByte();
                        
                    lvi = new ListViewItem(rec.ToStringArray());
                    StockView.Items.Add(lvi);
                }

            }
            catch (IOException e) {
                MessageBox.Show(e.Message, "Error reading MASTER file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
            
            this.ResumeLayout();
        }

        private static string ConvertToHex(byte[] ba) {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in ba)
                sb.AppendFormat("{0:X} ", b);

            return sb.ToString();
        }

        private static string ConvertToHex(byte[] ba, int row_len) {
            StringBuilder sb = new StringBuilder();
            int col = 0;

            foreach (byte b in ba) {
                sb.AppendFormat("{0:X2} ", b);
                col++;
                if (col >= row_len) {
                    col = 0;
                    sb.Append("\r\n");
                }
                else if (col % 8 == 0) {
                    sb.Append("  ");
                }
            }

            return sb.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct msbin2ieeVariant {
            [FieldOffset (0)] public float a;
            [FieldOffset (0)] public UInt32 b;
        }

        /* Microsoft Basic floating point format to IEEE floating point format */
        private static int ConvertToIeeeFloat(uint src, ref float dest) {
            msbin2ieeVariant c;
            UInt16 man;
            UInt16 exp;
            //float testF = 0; 

            c.a = 0; // to eliminate compiler warnings
            c.b = src;
            //testF = 0.75f;

            if (c.b > 0) {      
                man = (UInt16) (c.b >> 16);
                exp = (UInt16) ((man & 0xff00u) - 0x0200u);
                //if (exp & 0x8000 != man & 0x8000)
                //    return 1;   /* exponent overflow */
                man = (UInt16) (man & 0x7fu | (man << 8) & 0x8000u);   /* move sign */
                man |= (UInt16) (exp >> 1);
                c.b = (c.b & 0xffffu); 
                c.b |= (UInt32) (man << 16);
            }

            dest = c.a;

            return 0;
        }
	}
}
