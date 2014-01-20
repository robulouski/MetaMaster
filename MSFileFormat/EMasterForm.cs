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


namespace MSFileFormat
{
	public class EMasterForm : MSFileFormat.BaseMaster
	{
		private System.ComponentModel.IContainer components = null;

        public EMasterForm(string dir) {  
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            string DataFileName = Path.Combine(dir, "EMASTER");
            if (File.Exists(DataFileName)) {
                this.Text = "EMASTER (" + DataFileName + ")";
                LoadEMasterFile(DataFileName);
            }
            else {
                MessageBox.Show("Unable to find an EMASTER file in directory " + dir, 
                                "File Does Not Exist",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private EMasterForm()
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
            // EMasterForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(784, 701);
            this.Name = "EMasterForm";
            this.Text = "EMASTER";

        }
		#endregion


        struct EMasterRec {                     // EMASTER file
            public byte asc1, asc2;             // 2 digits ascii number???
            public byte FileNumber;             
            public string Fill1;                // 3 bytes
            public byte NumFields;              
            public byte Del;
            public byte FB1;
            public byte Space;
            public byte FB2;
            public string Symbol;               // 14 bytes
            public string Fill2;                // 7 bytes
            public string Name;                 // 16 bytes
            public string Fill3;                // 12 bytes
            public byte TimeFrame;              // Timeframe: I=Intraday, D=Daily, W=Weekly, M=Monthly 
            public string Fill4;                // 3 bytes (& Time Interval)
            public float FirstDate;             // 4 bytes MBF
            public float BeginTradeTime;        // 4 bytes MBF
            public float LastDate;              // 4 bytes MBF
            public float EndTradeTime;          // 4 bytes MBF
            public float StartTimeRange;        // 4 bytes MBF
            public float EndTimeRange;          // 4 bytes MBF
            public string Fill5;                // 38 bytes
            public string MysteryData;          // 4 bytes
            public string Fill6;                // 9 bytes
            public string ExtName;              
            public string Remainder;            // 53 bytes minus whatever ExtName used
            
            public string [] ToStringArray() {
                string asc_str = String.Format("{0}{1}", (char) asc1, (char) asc2);

                return new string [] {
                                         asc_str.ToString(),
                                         FileNumber.ToString("D4"),
                                         Fill1,
                                         NumFields.ToString(),
                                         Del.ToString("X2"),
                                         FB1.ToString("X"),
                                         Space.ToString("X2"),
                                         FB2.ToString("X"),
                                         Symbol,
                                         Fill2,
                                         Name,
                                         Fill3,
                                         new string((char) TimeFrame, 1),
                                         Fill4,
                                         ConvertDateToString(FirstDate),
                                         ConvertDateToString(BeginTradeTime),
                                         ConvertDateToString(LastDate),
                                         ConvertDateToString(EndTradeTime),
                                         ConvertDateToString(StartTimeRange),
                                         ConvertDateToString(EndTimeRange),
                                         Fill5,
                                         MysteryData,
                                         Fill6,
                                         ExtName,
                                         Remainder
                                     };
            }

            private static string ConvertDateToString(float ieee_date) {
                uint date = 0;
                if (ieee_date > 0) 
                    date = ((uint) ieee_date) + 19000000;
                return date.ToString();
            }

        };

        public void LoadEMasterFile(string filename) {
            this.SuspendLayout();
            StockView.Columns.Clear();
            StockView.Columns.Add("ASC", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Num", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill1", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("NumFields", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Del", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("FB1", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Space", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("FB2", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Symbol", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill2", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Name", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill3", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("TimeFrame", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill4", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("FirstDate", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("BegTrade", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("LastDate", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("EndTrade", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("StartTime", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("EndTime", -1, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill5", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("MysteryData", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Fill6", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("ExtName", -2, HorizontalAlignment.Left);
            StockView.Columns.Add("Remainder", -2, HorizontalAlignment.Left);

            FileStream fs = null;
            BinaryReader br = null;

            try {
                byte[] tmpbuf = new byte[200];
                byte[] rembuf = new byte[60];

                fs = new FileStream(filename, FileMode.Open);
                br = new BinaryReader(fs);
                int num = br.ReadInt16();
                int max = br.ReadInt16();
                RecordsText.Text = num.ToString();
                MaxText.Text = max.ToString();
                
                StringBuilder sb = new StringBuilder();
                br.Read(tmpbuf, 0, 45);
                sb.Append(ConvertToFillString(tmpbuf, 45));
                sb.Append("\r\n");
                br.Read(tmpbuf, 0, 4);
                sb.Append(ConvertToFillString(tmpbuf, 4));
                sb.Append("\r\n");
                byte[] buffer = br.ReadBytes(139);
                sb.Append(ConvertToHex(buffer, 16));
                RemainText.Text = sb.ToString();

                ListViewItem lvi;
                EMasterRec rec; 

                for (int i = 0; i < num; i++) {
                    rec.asc1 = br.ReadByte(); 
                    rec.asc2 = br.ReadByte(); 

                    rec.FileNumber = br.ReadByte();
                    
                    rec.Fill1 = ReadHexString(br, tmpbuf, 3);

                    rec.NumFields = br.ReadByte();
                    rec.Del = br.ReadByte();
                    rec.FB1 = br.ReadByte();
                    rec.Space = br.ReadByte();
                    rec.FB2 = br.ReadByte();
                    
                    rec.Symbol = ReadStringField(br, tmpbuf, 14);
                    
                    rec.Fill2 = ReadHexString(br, tmpbuf, 7);
                    
                    rec.Name = ReadStringField(br, tmpbuf, 16);
                    
                    rec.Fill3 = ReadHexString(br, tmpbuf, 12);

                    rec.TimeFrame = br.ReadByte();
                    
                    rec.Fill4 = ReadHexString(br, tmpbuf, 3);

                    rec.FirstDate = br.ReadSingle();
                    rec.BeginTradeTime = br.ReadSingle();
                    rec.LastDate = br.ReadSingle();
                    rec.EndTradeTime = br.ReadSingle();
                    rec.StartTimeRange = br.ReadSingle();
                    rec.EndTimeRange = br.ReadSingle();

                    rec.Fill5 = ReadFillString(br, tmpbuf, 38);

                    rec.MysteryData = ReadHexString(br, tmpbuf, 4);

                    rec.Fill6 = ReadFillString(br, tmpbuf, 9);
                    
                    rec.ExtName = ReadStringField(br, tmpbuf, 53);
                    Array.Copy(tmpbuf, rec.ExtName.Length, rembuf, 0, 53 - rec.ExtName.Length);
                    rec.Remainder = ConvertToFillString(rembuf, 53 - rec.ExtName.Length);
                    
                    lvi = new ListViewItem(rec.ToStringArray());
                    StockView.Items.Add(lvi);
                }

            }
            catch (IOException e) {
                MessageBox.Show(e.Message, "Error reading EMASTER file", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e) {
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
                const int iFileNumber = 1;
                const int iSymbol = 8;
                const int iName = 10;
                const int iFirstDate = 14;
                const int iLastDate = 16;
                const int iExtName = 23;

                string name;
                
                foreach (ListViewItem lvi in StockView.Items){
                    if (filter && lvi.SubItems[iSymbol].Text.Length > 3)
                        continue;
                    sw.Write(lvi.SubItems[iFileNumber].Text);
                    sw.Write(',');
                    sw.Write(lvi.SubItems[iSymbol].Text);
                    sw.Write(',');

                    if (lvi.SubItems[iExtName].Text.Length > 0)
                        name = lvi.SubItems[iExtName].Text;
                    else
                        name = lvi.SubItems[iName].Text;

                    if (name.IndexOf(',') >= 0) {
                        sw.Write("\"");
                        sw.Write(name);
                        sw.Write("\"");
                    }
                    else {
                        sw.Write(name);
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
