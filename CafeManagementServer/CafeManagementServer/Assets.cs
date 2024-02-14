using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static CafeManagementServer.Database;
using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Numerics;


namespace CafeManagementServer
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
        public string ExcelColumnFromNumber(int column)
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


        public string NapraviExcel(SqlDataReader reader, string exportPath, SQLManager objSql, string imeNaEkselot)
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

                int col = 1;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    ws.Cells[1, col].Value = reader.GetName(i);
                    col++;
                }
                int row = 2;
                while (reader.Read())
                {
                    col = 1;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        ws.Cells[row, col].Value = reader[i].ToString();
                        col++;
                    }
                    row++;
                };
                objSql.CloseConnection();

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

        public void PdfFile(string imeFile,string ispratnica,string slikaPath,string folderPath)
        {
            if (imeFile != "")
            {

                //Creating iTextSharp Table from the DataTable data
                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(ispratnica);

                iTextSharp.text.Image slika = iTextSharp.text.Image.GetInstance(slikaPath);
                //Resize image depend upon your need
                slika.ScaleToFit(540f, 420f);
                //Give space before image
                slika.SpacingBefore = 10f;
                //Give some space after the image
                slika.SpacingAfter = 1f;
                slika.Alignment = Element.ALIGN_LEFT;
                //Exporting to PDF

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    using (FileStream stream = new FileStream(folderPath + "\\" + "broj_na_faktura-" + imeFile + ".pdf", FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 50f, 50f, 50f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(p1);
                        pdfDoc.Add(slika);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                using (FileStream stream = new FileStream(folderPath + "broj_na_faktura-"+imeFile + ".pdf", FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(p1);
                    pdfDoc.Add(slika);
                    pdfDoc.Close();
                    stream.Close();
                }

            }
            else
            {
                MessageBox.Show("Внесете број на испратницата");
            }
        }

        public void PdfSmetka(string imeFile, string ispratnica, string slikaPath, string folderPath)
        {
            if (imeFile != "")
            {
                //Creating iTextSharp Table from the DataTable data
                iTextSharp.text.Paragraph p1 = new iTextSharp.text.Paragraph(ispratnica);

                iTextSharp.text.Image slika = iTextSharp.text.Image.GetInstance(slikaPath);
                //Resize image depend upon your need
                slika.ScaleToFit(340f, 220f);
                //Give space before image
                slika.SpacingBefore = 10f;
                //Give some space after the image
                slika.SpacingAfter = 1f;
                slika.Alignment = Element.ALIGN_LEFT;
                //Exporting to PDF

                iTextSharp.text.Image barcode = iTextSharp.text.Image.GetInstance("C:\\temp\\Project\\barcode.png");
                //Resize image depend upon your need
                slika.ScaleToFit(540f, 420f);
                //Give space before image
                slika.SpacingBefore = 10f;
                //Give some space after the image
                slika.SpacingAfter = 1f;
                slika.Alignment = Element.ALIGN_CENTER;

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    using (FileStream stream = new FileStream(folderPath + "\\"+ "broj_na_platena_smetka-" + imeFile + ".pdf", FileMode.Create))
                    {
                        iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 50f, 50f, 50f, 0f);
                        PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();
                        pdfDoc.Add(p1);
                        pdfDoc.Add(slika);
                        pdfDoc.Close();
                        stream.Close();
                    }
                }
                using (FileStream stream = new FileStream(folderPath + "broj_na_platena_smetka-" + imeFile + ".pdf", FileMode.Create))
                {
                    iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    pdfDoc.Add(slika);
                    pdfDoc.Add(p1);
                    pdfDoc.Add(barcode);
                    pdfDoc.Close();
                    stream.Close();
                }

            }
            else
            {
                MessageBox.Show("Внесете број на сметка");
            }
        }

        public double PremsetajDanok(int suma, double procent)
        {
            return Math.Round((procent / 100) * suma, 2);
        }

        public string RandomBrojNaFaktura()
        {
            string faktura = "";
            Random random = new Random();
            int randomFiveDigits = random.Next(10000, 100000);

            faktura = randomFiveDigits.ToString();
            
            return faktura;
        }
    }
}
