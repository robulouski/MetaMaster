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
using System.Reflection;


namespace MSFileFormat
{
    public class XMasterForm : MSFileFormat.BaseMaster {
        private System.ComponentModel.IContainer components = null;

        public XMasterForm(string dir) {  
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            string DataFileName = Path.Combine(dir, "XMASTER");
            if (File.Exists(DataFileName)) {
                this.Text = "XMASTER (" + DataFileName + ")";
                Cursor.Current = Cursors.WaitCursor;
                LoadXMasterFile(DataFileName);
                Cursor.Current = Cursors.Default;
            }
            else {
                MessageBox.Show("Unable to find an XMASTER file in directory " + dir, 
                                "File Does Not Exist", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private XMasterForm() {
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing ) {
            if( disposing ) {
                if (components != null) {
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
        private void InitializeComponent() {
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
            // XMasterForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(840, 701);
            this.Name = "XMasterForm";
            this.Text = "XMaster";

        }
        #endregion
        
        [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
        struct XMasterRec {                     // XMASTER file
            public byte StartByte;              // 0x01
            public string Symbol;               // 15 bytes
            public string Name;                 // 46 bytes
            public byte TimeFrame;              // Timeframe: I=Intraday, D=Daily, W=Weekly, M=Monthly 
            public string Fill1;                // 2 bytes
            public UInt16 FileNumber;             
            public string Fill2;                // 3 bytes
            public byte Del;                    // ASCII 127
            public string Fill3;                // 9 bytes
            public UInt32 Date1;           
            public UInt32 Mystery1;             
            public string Fill4;                // 16 bytes
            public UInt32 FirstDate1;             
            public UInt32 FirstDate2;             
            public string Fill5;                // 4 bytes
            public UInt32 LastDate;               
            public string Fill6;                // 30 bytes

            public string [] ToStringArray() {
                return new string [] {
                                         StartByte.ToString("X2"),
                                         Symbol,
                                         Name,
                                         new string((char) TimeFrame, 1),
                                         Fill1,
                                         FileNumber.ToString("D4"),
                                         Fill2,
                                         Del.ToString("X2"),
                                         Fill3,
                                         Date1.ToString(),
                                         Mystery1.ToString(),
                                         Fill4,
                                         FirstDate1.ToString(),
                                         FirstDate2.ToString(),
                                         Fill5,
                                         LastDate.ToString(),
                                         Fill6,
                };
            }
        };

        public void LoadXMasterFile(string filename) {
            this.SuspendLayout();
            StockView.Columns.Clear();

            Type t = typeof(XMasterRec);
            FieldInfo [] fields = t.GetFields (BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo fi in fields) {
                StockView.Columns.Add(fi.Name, (fi.FieldType == typeof(string)) ? -2 : -1, HorizontalAlignment.Left);
            }

            FileStream fs = null;
            BinaryReader br = null;

            try {
                byte[] tmpbuf = new byte[150];

                fs = new FileStream(filename, FileMode.Open);
                br = new BinaryReader(fs);
                
                
                StringBuilder sb = new StringBuilder();
                br.Read(tmpbuf, 0, 10);
                sb.Append(ConvertToFillString(tmpbuf, 10));
                sb.Append("\r\n");

                UInt32 num = br.ReadUInt16();
                UInt16 f1 = br.ReadUInt16();
                UInt32 max = br.ReadUInt16();
                UInt16 f2 = br.ReadUInt16();
                UInt32 next = br.ReadUInt16();
                UInt16 f3 = br.ReadUInt16();
                RecordsText.Text = num.ToString();
                MaxText.Text = max.ToString();
                sb.AppendFormat("Next: {0}\r\n", next);

                byte[] buffer = br.ReadBytes(128);
                sb.Append(ConvertToHex(buffer, 16));
                RemainText.Text = sb.ToString();

                ListViewItem lvi;
                XMasterRec rec; 

                for (UInt32 i = 0; i < num; i++) {
                    rec.StartByte = br.ReadByte(); 
                    rec.Symbol = ReadStringField(br, tmpbuf, 15);
                    rec.Name = ReadStringField(br, tmpbuf, 46);
                    rec.TimeFrame = br.ReadByte();
                    rec.Fill1 = ReadHexString(br, tmpbuf, 2);
                    rec.FileNumber = br.ReadUInt16();
                    rec.Fill2 = ReadHexString(br, tmpbuf, 3);
                    rec.Del = br.ReadByte();
                    rec.Fill3 = ReadFillString(br, tmpbuf, 9);                                    
                    rec.Date1 = br.ReadUInt32();
                    rec.Mystery1 = br.ReadUInt32();
                    rec.Fill4 = ReadFillString(br, tmpbuf, 16);                  
                    rec.FirstDate1 = br.ReadUInt32();
                    rec.FirstDate2 = br.ReadUInt32();
                    rec.Fill5 = ReadHexString(br, tmpbuf, 4);                  
                    rec.LastDate = br.ReadUInt32();
                    rec.Fill6 = ReadFillString(br, tmpbuf, 30);                  
                                            
                    lvi = new ListViewItem(rec.ToStringArray());
                    StockView.Items.Add(lvi);
                }

            }
            catch (IOException e) {
                MessageBox.Show(e.Message, "Error reading EMASTER file",
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
                const int iFileNumber = 5;
                const int iSymbol = 1;
                const int iName = 2;
                const int iFirstDate = 12;
                const int iLastDate = 15;

                foreach (ListViewItem lvi in StockView.Items){
                    if (filter && lvi.SubItems[1].Text.Length > 3)
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

