/*
 *  Copyright (C) 2006-2014 Robert Iwancz
 * 
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace MSFileFormat
{
	public class MasterForm : MSFileFormat.BaseMaster
	{
		private System.ComponentModel.IContainer components = null;

        public MasterForm(string dir) {  
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            string DataFileName = Path.Combine(dir, "MASTER");
            if (File.Exists(DataFileName)) {
                this.Text = "MASTER (" + DataFileName + ")";
                LoadMasterFile(DataFileName);
            }
            else {
                MessageBox.Show("Unable to find a MASTER file in directory " + dir, 
                                "File Does Not Exist",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private MasterForm()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            // 
            // RecordsText
            // 
            this.RecordsText.Name = "RecordsText";
            // 
            // MaxText
            // 
            this.MaxText.Name = "MaxText";
            // 
            // RemainText
            // 
            this.RemainText.Name = "RemainText";
            // 
            // StockView
            // 
            this.StockView.Name = "StockView";
            // 
            // MasterForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(784, 701);
            this.Name = "MasterForm";
            this.Text = "MASTER File";
            this.Load += new System.EventHandler(this.MasterForm_Load);

        }
		#endregion

        struct MasterRec {
            public byte FileNumber;
            public byte FileType1, FileType2;   // CT file type = 0'e' (5 or 7 flds)
            public byte RecLen;                 //record length in bytes (4 x NumFields)
            public byte NumFields;
            public byte Reserved1;
            public byte CenturyIndicator;       // (Or reserved???)
            public string Name;                 // 16 bytes
            public byte Reserved2;
            public byte CTFlag;                 // ????? if CT ver. 2.8, 'Y'; o.w., anything else
            public uint FirstDate;              // 4 bytes MBF
            public uint LastDate;               // 4 bytes MBF
            public byte TimeInterval;           // (D,W,M) 1 Char
            public ushort IDATimeBase;          // Intraday time base (Or reserved??)
            public string Symbol;               // 14 bytes
            public byte Reserved3;              // Must be a space for MS???
            public byte Flag;                   // ' ' or '*' for autorun
            public byte Reserved4;
            
            public string [] ToStringArray() {
                string file_type = String.Format("{0:X2} {1:X2}", FileType1, FileType2);
                return new string [] {
                                         FileNumber.ToString("D4"),
                                         file_type,
                                         RecLen.ToString(),
                                         NumFields.ToString(),
                                         Reserved1.ToString("X2"),
                                         CenturyIndicator.ToString("X2"),
                                         Name,
                                         Reserved2.ToString("X2"),
                                         CTFlag.ToString("X2"),
                                         ConvertDateToString(FirstDate),
                                         ConvertDateToString(LastDate),
                                         new string((char) TimeInterval, 1),
                                         IDATimeBase.ToString(),
                                         Symbol,
                                         Reserved3.ToString("X2"),
                                         Flag.ToString("X2"),
                                         Reserved4.ToString("X2")
                                     };
            }
            
            private static string ConvertDateToString(uint msbin_date) {
                float ieee_date = 0;
                ConvertToIeeeFloat(msbin_date, ref ieee_date);
                uint date = ((uint) ieee_date) + 19000000;
                return date.ToString();
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

                c.a = 0; // to eliminate compiler warnings
                c.b = src;

                if (c.b > 0) {      
                    man = (UInt16) (c.b >> 16);
                    exp = (UInt16) ((man & 0xff00u) - 0x0200u);
                    //if (exp & 0x8000 != man & 0x8000)
                    //    return 1;   // exponent overflow 
                    man = (UInt16) (man & 0x7fu | (man << 8) & 0x8000u);   // move sign 
                    man |= (UInt16) (exp >> 1);
                    c.b = (c.b & 0xffffu); 
                    c.b |= (UInt32) (man << 16);
                }

                dest = c.a;

                return 0;
            }

        };

        private void MasterForm_Load(object sender, System.EventArgs e) {
            
        }

        public void LoadMasterFile(string filename) {
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

            try {
                fs = new FileStream(filename, FileMode.Open);
                br = new BinaryReader(fs);
                int num = br.ReadInt16();
                int max = br.ReadInt16();
                byte[] buffer = br.ReadBytes(49);
                RecordsText.Text = num.ToString();
                MaxText.Text = max.ToString();
                RemainText.Text = ConvertToHex(buffer, 16);

                byte[] tmpbuf = new byte[60];
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

                    rec.Name = ReadStringField(br, tmpbuf, 16).Trim();

                    rec.Reserved2 = br.ReadByte();
                    rec.CTFlag = br.ReadByte();
                    rec.FirstDate = br.ReadUInt32();
                    rec.LastDate = br.ReadUInt32();
                    rec.TimeInterval = br.ReadByte();
                    rec.IDATimeBase = br.ReadUInt16();
                    
                    rec.Symbol = ReadStringField(br, tmpbuf, 14).Trim();
                    
                    rec.Reserved3 = br.ReadByte();
                    rec.Flag = br.ReadByte();
                    rec.Reserved4 = br.ReadByte();
                        
                    lvi = new ListViewItem(rec.ToStringArray());
                    StockView.Items.Add(lvi);
                }

            }
            catch (IOException e) {
                MessageBox.Show(e.Message, "Error reading MASTER file", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally {
                if (br != null)
                    br.Close();
                if (fs != null)
                    fs.Close();
            }
            
            this.ResumeLayout();
        }

        protected override void ExportData(string filename, bool filter) {
            using (StreamWriter sw = new StreamWriter(filename)) {
                const int iFileNumber = 0;
                const int iSymbol = 13;
                const int iName = 6;
                const int iFirstDate = 9;
                const int iLastDate = 10;
                
                foreach (ListViewItem lvi in StockView.Items){
                    if (filter && lvi.SubItems[iSymbol].Text.Length > 3)
                        continue;
                    sw.Write(lvi.SubItems[iFileNumber].Text);
                    sw.Write(',');
                    sw.Write(lvi.SubItems[iSymbol].Text);
                    sw.Write(',');
                    if (lvi.SubItems[iName].Text.IndexOf(',') >= 0) {
                        sw.Write("\"");
                        sw.Write(lvi.SubItems[iName].Text);
                        sw.Write("\"");
                    }
                    else {
                        sw.Write(lvi.SubItems[iName].Text);
                    }
                    sw.Write(',');

                    sw.Write(lvi.SubItems[iFirstDate].Text);
                    sw.Write(',');
                    sw.Write(lvi.SubItems[iLastDate].Text);

                    sw.WriteLine();
                }                
            }
        }

    }
}
