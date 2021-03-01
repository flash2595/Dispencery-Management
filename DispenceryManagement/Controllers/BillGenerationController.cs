using DispenceryManagement.Models;
using DispenceryManagement.ViewModel;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DispenceryManagement.Controllers
{
    public class BillGenerationController : Controller
    {
        private ApplicationDbContext dbContext;

        public BillGenerationController()
        {
            dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {            
            dbContext.Dispose();
        }

        // GET: BillGeneration
        public ActionResult Index()
        {
            var PurchaserDetails = dbContext.PurchaseDetails                
                .GroupBy(m => m.BillNo)
                .Select(m => m.FirstOrDefault())
                .ToList();

            foreach(var query in PurchaserDetails)
            {
                query.Patients = dbContext.Patient.Where(m => m.Id == query.PatientId).FirstOrDefault();
            }

            return View(PurchaserDetails);
        }

        public FileResult CreatePdf(string id)
        {
            MemoryStream workStream = new MemoryStream();
            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created 
            string strPDFFileName = string.Format("Bill_" + dTime.ToString("yyyyMMddmm") + "-" + ".pdf");
            Document doc = new Document();
            doc.SetMargins(20f, 20f, 0f, 0f);
            //Create PDF Table with 5 columns
            PdfPTable tableLayout = new PdfPTable(5);
            doc.SetMargins(0f, 0f, 0f, 0f);
            //Create PDF Table

            //file will created in this path
            string strAttachment = Server.MapPath("~/Downloadss/" + strPDFFileName);

            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();

            // Closing the document
            try
            {
                Paragraph paragraph = new Paragraph("GOODWILL DISPENCERY");

                string imageURL = @"D:\NewDispencery\DispenceryManagement\DispenceryManagement\images\logo.png";
                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                //Resize image depend upon your need
                jpg.ScaleToFit(140f, 120f);

                //Give space before image
                jpg.SpacingBefore = 10f;

                //Give some space after the image
                jpg.SpacingAfter = 1f;
                jpg.Alignment = Element.ALIGN_CENTER;
                paragraph.SpacingAfter = 30f;
                paragraph.SpacingBefore = 1f;
                paragraph.Alignment = Element.ALIGN_CENTER;

                doc.Add(jpg);
                doc.Add(paragraph);

                Paragraph TodayDate = new Paragraph("Date: " + DateTime.Now.ToString("dd MMMM yyyy       "));
                TodayDate.SpacingAfter = 5f;
                TodayDate.Alignment = Element.ALIGN_RIGHT;
                TodayDate.Font.Size = 10f;
                doc.Add(TodayDate);

                iTextSharp.text.pdf.draw.LineSeparator line = new LineSeparator(2f, 95f, new iTextSharp.text.BaseColor(71, 71, 71), Element.ALIGN_MIDDLE, 1);
                doc.Add(line);
            }
            catch (Exception ex)
            {
                Paragraph paragraph = new Paragraph(ex.ToString());
            }
            finally
            {
                //Add Content to PDF 
                doc.Add(Add_Content_To_PDF(tableLayout, id));

                doc.Close();
            }

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", strPDFFileName);
        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout, string BillNum)
        {
            float[] headers = { 40, 50, 55, 24, 35 };  //Header Widths
            tableLayout.SetWidths(headers);        //Set the pdf headers
            tableLayout.WidthPercentage = 80;       //Set the PDF File witdh percentage
            tableLayout.HeaderRows = 2;

            var PurchaseDispencery = dbContext.PurchaseDetails.Where(b => b.BillNo == BillNum).Select(m => m.DispenceryItems).ToList();
            var PurchaserPatient = dbContext.PurchaseDetails.Where(b => b.BillNo == BillNum).Select(m => m.Patients).FirstOrDefault();
            var purchaserDiscount = dbContext.MembershipType.Where(b => b.Id == PurchaserPatient.MembershipTypeId).Select(m => m.DiscountRate).Single();
            //string PurchaserPatientName = dbContext.Patient.Where(b => b.Name == PurchaserPatient.Name).Select(m=>m.Name).Single();
            //Add Title to the PDF file at the top

            tableLayout
                .AddCell(new PdfPCell(new Phrase(" "
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout
                .AddCell(new PdfPCell(new Phrase(" "
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout
                .AddCell(new PdfPCell(new Phrase("Bill Generation For Dispencery Patients"
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 15, 1, new iTextSharp.text.BaseColor(71, 71, 71))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });
            tableLayout
              .AddCell(new PdfPCell(new Phrase(" "
              , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
              { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });
             tableLayout
                .AddCell(new PdfPCell(new Phrase(" "
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            PdfPCell cellWithRowspan = new PdfPCell(new Phrase(PurchaserPatient.Name));//Patient_Name
            cellWithRowspan.Colspan = 4;

            ////Add header
            AddCellToHeader(tableLayout, "Patient Name");
            tableLayout.AddCell(cellWithRowspan);
            ///
            AddCellToHeader(tableLayout, "Bill Number");
            AddCellToHeader(tableLayout, "Dispencery Item Name");
            AddCellToHeader(tableLayout, "Dispencery Item Quantity");
            AddCellToHeader(tableLayout, "Per Price");
            AddCellToHeader(tableLayout, "Total Price");
            ///
            var Record = PurchaseDispencery.ToList();

            PdfPCell BillcellWithRowspan = new PdfPCell(new Phrase(BillNum));
            BillcellWithRowspan.Rowspan = Record.Count();//count_of_list

            PdfPCell BlankcellWithRowspan = new PdfPCell(new Phrase(""));
            BlankcellWithRowspan.Colspan = 3;
            ///
            tableLayout.AddCell(BillcellWithRowspan);
            ////Add body
            var TotalItemPrice = 0;
            var TotalBillPrice = 0;
            var TotalItemQuantity = 0;


            foreach (var emp in Record)
            {
                var RowItemTotalPrice = 0;
                RowItemTotalPrice = RowItemTotalPrice + (emp.DispenceryItemPrice * dbContext.PurchaseDetails
                                        .Where(b => (b.BillNo == BillNum) && (b.DispenceryItems.Id == emp.Id))
                                        .Select(b => b.DispenceryItemQuantityPurchase)
                                        .SingleOrDefault());
                TotalItemPrice = RowItemTotalPrice;
                TotalBillPrice = TotalBillPrice + TotalItemPrice;
                TotalItemQuantity = TotalItemQuantity + dbContext.PurchaseDetails
                                        .Where(b => (b.BillNo == BillNum) && (b.DispenceryItems.Id == emp.Id))
                                        .Select(b => b.DispenceryItemQuantityPurchase)
                                        .SingleOrDefault();

                AddCellToBody(tableLayout, emp.DispenceryItemName);
                AddCellToBody(tableLayout, dbContext.PurchaseDetails
                                        .Where(b => (b.BillNo == BillNum) && (b.DispenceryItems.Id == emp.Id))
                                        .Select(b => b.DispenceryItemQuantityPurchase)
                                        .SingleOrDefault()
                                        .ToString());

                AddCellToBody(tableLayout, emp.DispenceryItemPrice.ToString());
                AddCellToBody(tableLayout, RowItemTotalPrice.ToString());
            }
            var TotalDiscount = TotalBillPrice * purchaserDiscount / 100;//Discount_By_Membership_table
            var TotalPaidAmount = TotalBillPrice - TotalDiscount;
            ///
            AddCellToBody(tableLayout, "Total");
            AddCellToBody(tableLayout, Record.Count().ToString());
            AddCellToBody(tableLayout, TotalItemQuantity.ToString());
            AddCellToBody(tableLayout, "");
            AddCellToBody(tableLayout, TotalBillPrice.ToString());
            ///
            //AddCellToBody(tableLayout, TotalBillPrice.ToString());
            AddCellToBody(tableLayout, "Discount " + purchaserDiscount + "%");//Discount_By_Membership_table
            tableLayout.AddCell(BlankcellWithRowspan);
            AddCellToBody(tableLayout, TotalDiscount.ToString());
            ///
            AddCellToBody(tableLayout, "Paid Amount");
            tableLayout.AddCell(BlankcellWithRowspan);
            AddCellToFooter(tableLayout, TotalPaidAmount.ToString());
            ///
            tableLayout
                .AddCell(new PdfPCell(new Phrase(" "
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout
                .AddCell(new PdfPCell(new Phrase(" "
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout
                .AddCell(new PdfPCell(new Phrase("For Queies:- CONTACT ( +91 22 1234 5678 / +91 79 7748 4138)"
                , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 12, 1, new iTextSharp.text.BaseColor(0, 0, 0))))
                { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });

            tableLayout
               .AddCell(new PdfPCell(new Phrase("!..THANK YOU FOR VISIT..! "
               , new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 30, 1, new iTextSharp.text.BaseColor(71, 71, 71))))
               { Colspan = 12, Border = 0, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER });


            return tableLayout;
        }



        // Method to add single cell to the Header
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0) });
        }

        // Method to add single cell to the body
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255) });
        }

        private static void AddCellToFooter(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW))) { HorizontalAlignment = Element.ALIGN_LEFT, Padding = 5, BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0) });
        }

    }
}