using iTextSharp.text;
using iTextSharp.text.pdf;
using MTI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using MTI.Helpers;

namespace MTI.Controllers
{
    public class PDFController : Controller
    {
        private ApplicationDbContext _context;

        public PDFController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: PDF
        public ActionResult Index()
        {
            return View();
        }

        public FileResult CreatePdf()
        {
           
            MemoryStream workStream  = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            string strPDFFileName = string.Format("SamplePdf" + dTime.ToString("yyyyMMdd") + "-" + ".pdf");

            Document doc = new Document(PageSize.A4);

            doc.Open();


    PdfPTable aTable = new PdfPTable(7);
            aTable.HorizontalAlignment = Element.ALIGN_LEFT;
            aTable.WidthPercentage = 100;
          
           /* string url = Server.MapPath("~/content/image/pngtree-technology-background-png-image_2280734.png");
            Image jpg = Image.GetInstance(url);
            jpg.SetAbsolutePosition(0f, 0f);
            jpg.ScaleAbsolute(50f, 50f);
            doc.Add(jpg);*/



            doc.Add(aTable);
            //Create PDF Table  

            //file will created in this path  
            string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);


            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            //Add Content to PDF   
            doc.Add(Add_Content_To_PDF(aTable));

            // Closing the document  
            doc.Close();
     //       System.Diagnostics.Process.Start("C:/Users/msn/Downloads/Documents/SamplePdf20200706-.pdf");

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);

        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {

            float[] headers = { 50, 24, 45, 35, 50 ,50,40}; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            //Add Title to the PDF file at the top  

            List<Students> students = _context.students.Include(x=>x.Section).Include(x=>x.specialization).ToList();

            ////Add header  
           
            AddCellToHeader(tableLayout, "تليفون");
            AddCellToHeader(tableLayout, "تاريخ الميلاد");

            AddCellToHeader(tableLayout, "الرقم القومي");

            AddCellToHeader(tableLayout, "التخصص");

            AddCellToHeader(tableLayout, "الفرقة الدراسية");

            AddCellToHeader(tableLayout, "الاسم");

            AddCellToHeader(tableLayout, "الرقم العسكري");

            ////Add body  

            foreach (var stud in students)
            {
                AddCellToBody(tableLayout, stud.Mobile.ToString().ConvertNumeralsToArabic());
                AddCellToBody(tableLayout, stud.BirthDate.Value.ToString("yyyy/MM/dd").ConvertNumeralsToArabic());
                AddCellToBody(tableLayout, stud.SSN.ConvertNumeralsToArabic());
                AddCellToBody(tableLayout, stud.specialization.specialty);
                AddCellToBody(tableLayout, stud.Section.Level);
                AddCellToBody(tableLayout, stud.Name);
                AddCellToBody(tableLayout, stud.StudentNumber.ToString().ConvertNumeralsToArabic());

            }

            return tableLayout;
        }
        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            var tahomaFontFile = Path.Combine(
                                              Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Tahoma.ttf");
            var tahomaBaseFont = BaseFont.CreateFont(tahomaFontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var tahomaFont = new Font(tahomaBaseFont, 8, Font.NORMAL);

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText,tahomaFont))
            {
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            var tahomaFontFile = Path.Combine(
                                              Environment.GetFolderPath(Environment.SpecialFolder.Fonts),"Tahoma.ttf");
            var tahomaBaseFont = BaseFont.CreateFont(tahomaFontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            var tahomaFont = new Font(tahomaBaseFont, 8, Font.NORMAL);

            
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, tahomaFont))
             {
                RunDirection = PdfWriter.RUN_DIRECTION_RTL,
                HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
    });
        }
    }
}