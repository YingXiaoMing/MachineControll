//using PdfSharp;
//using PdfSharp.Drawing;
//using PdfSharp.Pdf;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FormControll
//{
//    public class PdfSharpUtilities
//    {
//        private double topMargin = 0;
//        private double leftMargin = 0;
//        private double rightMargin = 0;
//        private double bottomMargin = 0;
//        private double cm;

//        private PdfDocument document;
//        private PdfPage page;
//        private XGraphics gfx;
//        private XFont font;
//        private XPen pen;
//        private String outputPath;

//        public PdfSharpUtilities(String argOutputpath, Boolean argAddMarginGuides = false)
//        {
//            this.outputPath = argOutputpath;

//            //You’ll need a PDF document:
//            this.document = new PdfDocument();

//            //And you need a page:
//            this.page = document.AddPage();
//            this.page.Size = PageSize.Letter;

//            //Define how much a cm is in document's units
//            this.cm = new Interpolation().linearInterpolation(0, 0, 27.9, page.Height, 1);
//            Console.WriteLine("1 cm:" + cm);

//            //Drawing is done with an XGraphics object:

//            this.gfx = XGraphics.FromPdfPage(page);

//            this.font = new XFont("Arial", 12, XFontStyle.Bold);
//            this.pen = new XPen(XColors.Black, 0.5);

//            //Sugested margins

//            topMargin = 2.5 * cm;
//            leftMargin = 3 * cm;
//            rightMargin = page.Width - (3 * cm);
//            bottomMargin = page.Height - (2.5 * cm);

//            if (argAddMarginGuides)
//            {
//                gfx.DrawString("+", font, XBrushes.Black, rightMargin, topMargin);
//                gfx.DrawString("+", font, XBrushes.Black, leftMargin, topMargin);
//                gfx.DrawString("+", font, XBrushes.Black, rightMargin, bottomMargin);
//                gfx.DrawString("+", font, XBrushes.Black, leftMargin, bottomMargin);
//            }

//            Console.WriteLine("Page Width in cm:" + page.Width * cm);
//            Console.WriteLine("Page Height in cm:" + page.Height * cm);

//            Console.WriteLine("Top Margin in cm:" + topMargin);
//            Console.WriteLine("Left Margin in cm:" + leftMargin);
//            Console.WriteLine("Right Margin in cm:" + rightMargin);
//            Console.WriteLine("Bottom Margin in cm:" + bottomMargin);
//        }

//    }
//}