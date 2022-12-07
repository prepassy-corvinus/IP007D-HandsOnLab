using Excel2 = Microsoft.Office.Interop.Excel;
using System.Reflection;
namespace Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        Excel2.Application xlApp;
        Excel2.Workbook xlWB;
        Excel2.Worksheet xlSheet;

        private void button1_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }

        private void CreateExcel()
        {
            try
            {
                xlApp = new Excel2.Application();
                xlWB = xlApp.Workbooks.Add(Missing.Value);
                xlSheet = xlWB.ActiveSheet;
                CreateTable();
                xlApp.Visible = true;
                xlApp.UserControl = true;

            }
            catch (Exception ex)
            {
                string msg = string.Format("Error: {0}\nLine: {1}", ex.Message, ex.Source);
                MessageBox.Show(msg, "Error");

                xlWB.Close(false, Type.Missing, Type.Missing);
                xlApp.Quit();
                xlWB = null;
                xlApp = null;
            }
        }

        void CreateTable()
        {
            string[] fejl�cek = new string[] {
            "K�rd�s",
            "1. v�lasz",
            "2. v�lasz",
            "3. v�lasz",
            "Helyes v�lasz",
            "k�p"};
            
            for (int i = 0; i < fejl�cek.Length; i++)
            {
                xlSheet.Cells[1, i+1] = fejl�cek[i];
            }

            Models.HajosContext hajosContext = new Models.HajosContext();
            var mindenKerdes = hajosContext.Questions.ToList();

            object[,] adatTomb = new object[mindenKerdes.Count(), fejl�cek.Count()];

            for (int i = 0; i < mindenKerdes.Count(); i++)
            {
                adatTomb[i, 0] = mindenKerdes[i].Question1;
                adatTomb[i, 1] = mindenKerdes[i].Answer1;
                adatTomb[i, 2] = mindenKerdes[i].Answer2;
                adatTomb[i, 3] = mindenKerdes[i].Answer3;
                adatTomb[i, 4] = mindenKerdes[i].CorrectAnswer;
                adatTomb[i, 5] = mindenKerdes[i].Image;
            }

            int sorokSz�ma = adatTomb.GetLength(0);
            int oszlopokSz�ma = adatTomb.GetLength(1);

            Excel2.Range adatRange = xlSheet.get_Range("A2", Type.Missing).get_Resize(sorokSz�ma, oszlopokSz�ma);
            adatRange.Value2 = adatTomb;

            adatRange.Columns.AutoFit();

            Excel2.Range fejll�cRange = xlSheet.get_Range("A1", Type.Missing).get_Resize(1, 6);
            fejll�cRange.Font.Bold = true;
            fejll�cRange.VerticalAlignment = Excel2.XlVAlign.xlVAlignCenter;
            fejll�cRange.HorizontalAlignment = Excel2.XlHAlign.xlHAlignCenter;
            fejll�cRange.EntireColumn.AutoFit();
            fejll�cRange.RowHeight = 40;
            fejll�cRange.Interior.Color = Color.LightGreen;
            fejll�cRange.BorderAround2(Excel2.XlLineStyle.xlContinuous, Excel2.XlBorderWeight.xlThick);

            int lastRowID = xlSheet.UsedRange.Rows.Count;

        }
    }
}