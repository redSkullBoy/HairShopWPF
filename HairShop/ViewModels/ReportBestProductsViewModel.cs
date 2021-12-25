using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;
using HairShop.View;
using HairShop.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using HairShop.Services;

namespace HairShop.ViewModels
{
    class ReportBestProductsViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private ReportBestProducts reportbestproducts;
        public ReportBestProductsViewModel(ReportBestProducts reportbestproducts)
        {
            this.reportbestproducts = reportbestproducts;

            db = new DBOperations();

            Report_DateBeg = DateTime.Now.Date;
            Report_DateEnd = DateTime.Now.Date;

        }

        private DateTime report_datebeg;
        public DateTime Report_DateBeg
        {
            get { return report_datebeg; }
            set { report_datebeg = value; }
        }

        private DateTime report_dateend;
        public DateTime Report_DateEnd
        {
            get { return report_dateend; }
            set { report_dateend = value; }
        }


        private ReCommand report_forming;
        public ReCommand Report_Forming
        {
            get
            {
                return report_forming ??
                  (report_forming = new ReCommand(obj =>
                  {
                      string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                      var baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                      var font = new Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);
                      font.Size = 10;
                      var document = new iTextSharp.text.Document();
                      string pdfName = "Отчет о наиболее востребованных товарах (с " + Report_DateBeg.ToShortDateString() + " по " + Report_DateEnd.ToShortDateString() + ").pdf";
                      using (var writer = PdfWriter.GetInstance(document, new FileStream(pdfName, FileMode.Create)))
                      {
                          document.Open();
                          writer.DirectContent.BeginText();
                          document.Add(new Paragraph("Отчет о наиболее востребованных товарах (с " + Report_DateBeg.ToShortDateString() + " по " + Report_DateEnd.ToShortDateString() + ")", font));
                          document.Add(new Paragraph(" ", font));

                          PdfPTable table = new PdfPTable(4);
                          table.WidthPercentage = 100;
                          PdfPCell cell = new PdfPCell(new Paragraph("Название", font));
                          cell.Colspan = 3;
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);
                          cell = new PdfPCell(new Paragraph("Количество продано", font));
                          cell.HorizontalAlignment = 1;
                          cell.Padding = 5;
                          table.AddCell(cell);

                          List<ProductReport> prods = db.GetReportBestProducts(Report_DateBeg, Report_DateEnd);
                          for (int ii = 0; ii < prods.Count; ii++)
                          {
                              cell = new PdfPCell(new Paragraph(prods[ii].Product_Name, font));
                              cell.Colspan = 3;
                              cell.Padding = 5;
                              table.AddCell(cell);
                              cell = new PdfPCell(new Paragraph(prods[ii].Product_Quantity.ToString("N0"), font));
                              cell.HorizontalAlignment = 1;
                              cell.Padding = 5;
                              table.AddCell(cell);
                          }

                          document.Add(table);

                          writer.DirectContent.EndText();

                          document.Close();
                          writer.Close();

                          Swapper.MessageShowText = pdfName + "' сохранен.";
                          MessageShow frm = new MessageShow();
                          frm.ShowDialog();
                          System.Diagnostics.Process.Start(pdfName);
                      }

                      reportbestproducts.Close();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
