using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace CafeManagement
{
    internal class Assets
    {
        private Excel.Application ExcelObj = null;
        public List<string> razdeli(string str)
        {
            List<string> list = new List<string>();
            string prazenStr = "";
            string split = "#";
            for (int a = 0; a < str.Length; a++)
            {
                foreach (char s in split)
                {
                    if (str[a] != s)
                    {
                        prazenStr += str[a];
                        if (a == str.Length - 1)
                        {
                            list.Add(prazenStr);
                        }
                    }
                    else
                    {
                        list.Add(prazenStr); ;
                        prazenStr = "";
                    }
                }
            }
            return list;
        }
        public List<string> split(string str,string split)
        {
            List<string> list = new List<string>();
            string prazenStr = "";
            for (int a = 0; a < str.Length; a++)
            {
                foreach (char s in split)
                {
                    if (str[a] != s)
                    {
                        prazenStr += str[a];
                        if (a == str.Length - 1)
                        {
                            list.Add(prazenStr);
                        }
                    }
                    else
                    {
                        list.Add(prazenStr); ;
                        prazenStr = "";
                    }
                }
            }
            return list;
        }

        public string[] ConvertToStringArray(System.Array values)
        {
            // create a new string array  
            string[] theArray = new string[values.Length];
            // loop through the 2-D System.Array and populate the 1-D String Array  
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }
            return theArray;
        }

        public  string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        public string NapraviExcelOdListView(string exportPath, ListView listview1, string imeNaEkselot)
        {
            ExcelObj = new Excel.Application();

            if (ExcelObj == null)
            {
                MessageBox.Show("ERROR: EXCEL couldn't be started!");
                System.Windows.Forms.Application.Exit();
            }

            ExcelObj.Visible = true;

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Dadoteka|*.xlsx", ValidateNames = true })
            {

                Excel.Workbook wb = ExcelObj.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
                Excel.Worksheet ws = (Excel.Worksheet)ExcelObj.ActiveSheet;
                ExcelObj.Visible = true;
                int a = 1;
                int k = 1;
                int i = 2;

                foreach (ColumnHeader header in listview1.Columns)
                {
                    //  MessageBox.Show(header.Text);
                    ws.Cells[a, k] = header.Text;
                    k++;
                }
                foreach (ListViewItem item in listview1.Items)
                {
                    int v = 1;
                    for (int j = 0; j < item.SubItems.Count; j++)
                    {
                        ws.Cells[i, v] = item.SubItems[j].Text;
                        v++;
                    }
                    i++;
                    v = 0;
                }


                string debugDirectory1 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                exportPath = Path.Combine(debugDirectory1, imeNaEkselot + ".xlsx");
                if (File.Exists(exportPath))//ovaa raboti
                {
                    File.Delete(exportPath);
                }
                wb.SaveAs(exportPath);
                ExcelObj.Quit();
            }
            return exportPath;

        }

        public void KreirajWordDokument(string vreme,string fiskalna)
        {

            // Create a new instance of Microsoft Word application
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

            // Create a new document
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Add();

            // Add content to the document
            Microsoft.Office.Interop.Word.Paragraph para = doc.Paragraphs.Add();

            para.Range.Text = fiskalna;

            // Add image to the document
            object missing = System.Reflection.Missing.Value;

            // Specify the path to your image
            string imagePath = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagementServer\\CafeManagementServer\\sliki\\barcode.png";

            // Insert the image
            Microsoft.Office.Interop.Word.InlineShape inlineShape = para.Range.InlineShapes.AddPicture(imagePath, ref missing, ref missing, ref missing);

            // Optionally, you can set the size of the image
            inlineShape.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoFalse;
            inlineShape.Width = 100; // Set the width in points
            inlineShape.Height = 100; // Set the height in points

            try
            {
                string filePath = "C:\\Users\\Vladimir Piki\\mikrosamProekti\\Project\\CafeManagement\\CafeManagement\\fiskalni\\fiskalni-" + vreme + ".docx";
                if (!File.Exists(filePath))
                {
                    doc.SaveAs2(filePath);
                    doc.Close();
                    wordApp.Quit();
                }

                Microsoft.Office.Interop.Word.Application wordAppOpen = new Microsoft.Office.Interop.Word.Application();
         
                Microsoft.Office.Interop.Word.Document docOpen = wordAppOpen.Documents.Open(filePath);
                wordAppOpen.Visible = true;
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordAppOpen);
            }
            catch
            {
                MessageBox.Show("Dadoteka ne mozi da se zacuva");
            }
        }

        public double PremsetajDanok(int suma, double procent)
        {
            return Math.Round((procent / 100) * suma, 2);
        }


    }
}
