using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Drawing;
using System.Drawing.Printing;

using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp;
using CefSharp.WinForms;

namespace FormControll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private class BoxCorrdinate
        {
            public decimal X { get; set; }
            public decimal Y { get; set; }
            public decimal CenterX { get; set; }
            public decimal CenterY { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int PointX { get; set; }
            public int PointY { get; set; }

            public BoxCorrdinate(decimal x, decimal y, decimal centerX, decimal centerY, int width, int height, int pointX, int pointY)
            {
                X = x;
                Y = y;
                CenterX = centerX;
                CenterY = centerY;
                Width = width;
                Height = height;
                PointX = pointX;
                PointY = pointY;
            }
        }

        private List<BoxCorrdinate> ViewAListData { get; set; } = new List<BoxCorrdinate>();
        private List<BoxCorrdinate> ViewBListData { get; set; } = new List<BoxCorrdinate>();

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void label1_Click_2(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void boardAWidth_TextChanged(object sender, EventArgs e)
        {
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            // 判断输入条件是否为空
            if (JudgeBoxInputEmpty()) return;

            if (string.IsNullOrWhiteSpace(boardAWidth.Text) == false && string.IsNullOrWhiteSpace(boardAHeight.Text) == false)
            {
                ViewAListData = DrawBoardAListView(boardAWidth, boardAHeight, boardATop, boardALeft, boardABottom, boardARight, listViewA, panel1);
            }

            if (string.IsNullOrWhiteSpace(boardBWidth.Text) == false &&
                string.IsNullOrWhiteSpace(boardBHeight.Text) == false)
            {
                ViewBListData = DrawBoardAListView(boardBWidth, boardBHeight, boardBTop, boardBLeft, boardBBottom, boardBRight, listViewB, panel2);
            }

            // how to draw view?
        }

        private decimal ConvertTexBoxLabelToDecimal(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text) == false)
            {
                return decimal.Parse(textBox.Text);
            }
            return 0;
        }

        private List<BoxCorrdinate> DrawBoardAListView(TextBox boardBoxAWidth, TextBox boardBoxAHeight, TextBox boardBoxATop, TextBox boardBoxALeft, TextBox boardBoxABottom, TextBox boardBoxARight, ListView drawListView, Panel panelView)
        {
            try
            {
                // 判断地台板竖放能存放的最大个数(正常情况下的计算)-地台板的长度除以箱子的长度
                var aWidth = decimal.Parse(boardBoxAWidth.Text) + ConvertTexBoxLabelToDecimal(boardBoxALeft) + ConvertTexBoxLabelToDecimal(boardBoxARight);
                var aHeight = decimal.Parse(boardBoxAHeight.Text) + ConvertTexBoxLabelToDecimal(boardBoxATop) + ConvertTexBoxLabelToDecimal(boardBoxABottom);
                var box_Width = decimal.Parse(boxWdith.Text);
                var box_Height = decimal.Parse(boxHeight.Text);

                // 判断地台板横放能存放的最大个数(正常情况下的计算)-地台板的长度除以箱子的长度
                var x1Total = Math.Floor(aWidth / box_Width);
                var y1Total = Math.Floor(aHeight / box_Height);
                var calc_horizontal_total = x1Total * y1Total;
                // 判断地台板竖放能存放的最大个数(正常情况下的计算)-地台板的长度除以箱子的宽度
                var x2Total = Math.Floor(aWidth / box_Height);
                var y2Total = Math.Floor(aHeight / box_Width);
                var calc_vertical_total = x2Total * y2Total;

                var t = new List<BoxCorrdinate>();

                //得出每个箱体的XY轴（起点），再计算出中心点
                if (calc_horizontal_total < calc_vertical_total)
                {
                    // 竖放 panel1的宽度是固定的
                    var b_c_width = (int)(panelView.Width / x2Total);
                    var b_c_height = (int)(panelView.Height / y2Total);
                    t = CalcBoxList(calc_vertical_total, x2Total, y2Total, box_Height, box_Width, b_c_width, b_c_height);
                }
                else
                {
                    // 横放 panel1的宽度是固定的
                    var b_c_width = (int)(panelView.Width / x1Total);
                    var b_c_height = (int)(panelView.Height / y1Total);
                    t = CalcBoxList(calc_horizontal_total, x1Total, y1Total, box_Width, box_Height, b_c_width, b_c_height);
                }
                drawListView.Items.Clear();
                panelView.Controls.Clear();
                foreach (var item in t)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = (drawListView.Items.Count + 1) + "";
                    lvi.SubItems.Add(item.CenterX.ToString());
                    lvi.SubItems.Add(item.CenterY.ToString());
                    drawListView.BeginUpdate();
                    drawListView.Items.Add(lvi);
                    drawListView.EndUpdate();
                    // 绘制
                    Panel newView = new Panel();
                    newView.BorderStyle = BorderStyle.FixedSingle;
                    newView.BackgroundImage = Image.FromFile(@"C:\Users\ljl\source\repos\FormControll\FormControll\box.png");
                    newView.BackgroundImageLayout = ImageLayout.Zoom;
                    newView.SetBounds((int)item.PointX, (int)item.PointY, item.Width, item.Height);
                    panelView.Controls.Add(newView);
                }

                return t;
            }
            catch (Exception e)
            {
                ShowTips("输入地台板的长度和宽度不符合要求，请重新输入");
                return new List<BoxCorrdinate>();
                Console.WriteLine(e);
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\ljl\source\repos\FormControll\FormControll\box.pdf";
            pdfPrint(filePath);

            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="total"></param>
        /// <param name="w">横放的个数</param>
        /// <param name="h">竖放的个数</param>
        /// <param name="b_w">箱子的长度</param>
        /// <param name="b_h">箱子的宽度</param>
        /// <param name="box_w">页面显示箱子的长度</param>
        /// <param name="box_h">页面显示箱子的宽度</param>
        /// <returns></returns>
        private List<BoxCorrdinate> CalcBoxList(decimal total, decimal w, decimal h, decimal b_w, decimal b_h, int box_w, int box_h)
        {
            var t = new List<BoxCorrdinate>();

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    var x_position = (i % w) * b_w;
                    var y_position = (j % h) * b_h;
                    var center_x = x_position + (b_w / 2);
                    var center_y = y_position + (b_h / 2);
                    var x_point = (int)((x_position / b_w) * box_w);
                    var y_point = (int)((y_position / b_h) * box_h);
                    t.Add(new BoxCorrdinate(x_position, y_position, center_x, center_y, box_w, box_h, x_point, y_point));
                }
            }
            return t;
        }

        private bool JudgeBoxInputEmpty()
        {
            if (isEmpty(boxWdith.Text, $"{boxContainer.Text}{boxWidthText.Text}") || isEmpty(boxHeight.Text, $"{boxContainer.Text}{boxHeightText.Text}"))
            {
                return true;
            }
            return false;
        }

        private bool isEmpty(string value, string boxText)
        {
            if (string.IsNullOrEmpty(value))
            {
                ShowTips($"{boxText}不能为空");
                return true;
            }

            return false;
        }

        private void pdfPrint(string filePath)
        {
            int margin_left_right = 30;//左右边距
            int margin_top_bottom = 30;//上下边距
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            page.Size = PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("华文宋体", 28, XFontStyle.Bold);
            int cur_x = 0 + margin_left_right;
            int cur_y = 0 + margin_top_bottom;
            gfx.DrawString("机器手坐标", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
            //一条横线
            var line_x = 0 + margin_left_right;
            var line_y = cur_y + 40;
            XPen pen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 1);
            gfx.DrawLine(pen, line_x, line_y, page.Width - line_x, line_y + 2);
            if (ViewAListData.Any() == true)
            {
                cur_x = 0 + margin_left_right;
                cur_y = line_y + 20;
                font = new XFont("华文宋体", 20, XFontStyle.Regular);
                gfx.DrawString("地台板A:", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
                // 箱子
                var box_x = 0 + margin_left_right;
                cur_y = cur_y + 40;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("箱子", font, XBrushes.Black, new XRect(box_x, cur_y, 100, 60), XStringFormats.TopLeft);
                // 坐标轴X
                var point_x_x = 0 + margin_left_right + 40;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴X", font, XBrushes.Black, new XRect(point_x_x, cur_y, 120, 60), XStringFormats.TopLeft);
                //坐标轴Y
                var point_y_x = 0 + margin_left_right + 100;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴Y", font, XBrushes.Black, new XRect(point_y_x, cur_y, 120, 60), XStringFormats.TopLeft);
                foreach (var item in ViewAListData)
                {
                    cur_y = cur_y + 20;
                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString((ViewAListData.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.CenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.CenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
                }
            }
            if (ViewBListData.Any() == true)
            {
                cur_x = 0 + margin_left_right + 160;
                cur_y = line_y + 20;
                font = new XFont("华文宋体", 20, XFontStyle.Regular);
                gfx.DrawString("地台板B:", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
                // 箱子
                var box_x = 0 + margin_left_right + 160;
                cur_y = cur_y + 40;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("箱子", font, XBrushes.Black, new XRect(box_x, cur_y, 100, 60), XStringFormats.TopLeft);
                // 坐标轴X
                var point_x_x = 0 + margin_left_right + 40 + 160;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴X", font, XBrushes.Black, new XRect(point_x_x, cur_y, 120, 60), XStringFormats.TopLeft);
                //坐标轴Y
                var point_y_x = 0 + margin_left_right + 100 + 160;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴Y", font, XBrushes.Black, new XRect(point_y_x, cur_y, 120, 60), XStringFormats.TopLeft);
                foreach (var item in ViewAListData)
                {
                    cur_y = cur_y + 20;
                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString((ViewAListData.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.CenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.CenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
                }
            }

            document.Save(filePath);
        }

        private static DialogResult ShowTips(string message)
        {
            return MessageBox.Show(message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void boardBRight_TextChanged(object sender, EventArgs e)
        {
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void printPreviewDialog1_Load_1(object sender, EventArgs e)
        {
        }
    }
}