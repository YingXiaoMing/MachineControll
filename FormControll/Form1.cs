using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormControll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class DPoint
        {
            public double x { get; set; }
            public double y { get; set; }

            public DPoint(double x, double y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private double topMargin = 0;
        private double leftMargin = 0;
        private double rightMargin = 0;
        private double bottomMargin = 0;
        private double cm;
        private XFont font;
        private XPen pen;

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

        private List<ItemInfo> RightSingleList { get; set; } = new List<ItemInfo>();
        private List<ItemInfo> RightDoubleList { get; set; } = new List<ItemInfo>();
        private List<ItemInfo> BList { get; set; } = new List<ItemInfo>();

        private XGraphics gfx;

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

        private string HandleEmptyText(string txt)
        {
            return string.IsNullOrEmpty(txt) ? "0" : txt;
        }

        private void drawRightSingleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), int.Parse(HandleEmptyText(boardALeft.Text)), int.Parse(HandleEmptyText(boardATop.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result.OrderBy(t => t.PointX).ToList();
            nlist.ForEach(item =>
            {
                item.DrawX = item.PointX;
                item.DrawY = item.PointY;
            });
            RightSingleList = nlist;
            DrawListView(listView1, RightSingleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel1);
        }

        private void drawRightDoubleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), int.Parse(HandleEmptyText(boardALeft.Text)), int.Parse(HandleEmptyText(boardATop.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result.OrderBy(t => t.PointX).ToList();
            nlist.ForEach(item =>
            {
                item.DrawX = int.Parse(HandleEmptyText(boardWidth.Text)) - item.PointX - item.Length;
                item.DrawY = int.Parse(HandleEmptyText(boardHeight.Text)) - item.PointY - item.Width;
            });
            RightDoubleList = nlist.OrderBy(t => t.DrawY).OrderBy(t => t.DrawX).ToList();
            DrawListView(listView2, RightDoubleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel2);
        }

        private void drawLeftSingleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), int.Parse(HandleEmptyText(boardALeft.Text)), int.Parse(HandleEmptyText(boardATop.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result.OrderByDescending(t => t.PointX).ToList();
            nlist.ForEach(item =>
            {
                item.DrawX = item.PointX;
                item.DrawY = item.PointY;
            });
            RightSingleList = nlist;
            DrawListView(listView3, RightSingleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel3);
        }

        private void drawLeftDoubleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), int.Parse(HandleEmptyText(boardALeft.Text)), int.Parse(HandleEmptyText(boardATop.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result.OrderByDescending(t => t.PointX).ToList();
            nlist.ForEach(item =>
            {
                item.DrawX = int.Parse(HandleEmptyText(boardWidth.Text)) - item.PointX - item.Length;
                item.DrawY = int.Parse(HandleEmptyText(boardHeight.Text)) - item.PointY - item.Width;
            });
            RightDoubleList = nlist;
            DrawListView(listView4, RightDoubleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel4);
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            // 判断输入条件是否为空
            if (JudgeBoxInputEmpty()) return;

            if (string.IsNullOrWhiteSpace(boardWidth.Text) == false && string.IsNullOrWhiteSpace(boardHeight.Text) == false)
            {
                drawRightSingleBoard();
                drawRightDoubleBoard();
                drawLeftSingleBoard();
                drawLeftDoubleBoard();
            }
            else
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                panel2.Controls.Clear();
                panel1.Controls.Clear();
            }
        }

        private void DrawListView(ListView drawListView, List<ItemInfo> t, int board_length, int board_width, Panel panelView, bool isDouble = false)
        {
            // 更改版面的宽度
            var p_width = (int)(((decimal)panelView.Height / (decimal)board_width) * board_length);
            var save_board_width = panelView.Width;
            var disparityWidth = save_board_width - p_width; //缩减的宽度差
            panelView.Width = p_width;
            if (drawListView.Name.Equals("listView1"))
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X - disparityWidth, pictureBox3.Location.Y);
                pictureBox5.Location = new Point(pictureBox5.Location.X - disparityWidth, pictureBox5.Location.Y);
                label15.Location = new Point(label15.Location.X - disparityWidth, label15.Location.Y);
                label13.Location = new Point(label13.Location.X - disparityWidth, label13.Location.Y);
                label14.Location = new Point(label14.Location.X - disparityWidth, label14.Location.Y);
            }
            else if (drawListView.Name.Equals("listView2"))
            {
                pictureBox6.Location = new Point(pictureBox6.Location.X - disparityWidth, pictureBox6.Location.Y);
                pictureBox7.Location = new Point(pictureBox7.Location.X - disparityWidth, pictureBox7.Location.Y);
                label34.Location = new Point(label34.Location.X - disparityWidth, label34.Location.Y);
                label11.Location = new Point(label11.Location.X - disparityWidth, label11.Location.Y);
                label12.Location = new Point(label12.Location.X - disparityWidth, label12.Location.Y);
            }
            drawListView.Items.Clear();
            panelView.Controls.Clear();
            foreach (var item in t)
            {
                var draw_box_length = (decimal)p_width / ((decimal)board_length / (decimal)item.Length);
                var draw_box_width = (decimal)panelView.Height / ((decimal)board_width / (decimal)item.Width);
                var draw_box_pointX = (int)Math.Round(((decimal)item.DrawX / (decimal)board_length) * (decimal)p_width);
                var draw_box_pointY = (int)Math.Round(((decimal)item.DrawY / (decimal)board_width) * (decimal)panelView.Height);
                if (drawListView.Name.Equals("listView1") || drawListView.Name.Equals("listView4"))
                {
                    // 根据需求重新绘制对应的坐标点
                    item.DrawCenterX = board_length - item.CenterX;
                    item.DrawCenterY = board_width - item.CenterY;
                }
                else
                {
                    item.DrawCenterX = item.CenterX;
                    item.DrawCenterY = item.CenterY;
                }

                ListViewItem lvi = new ListViewItem();
                lvi.Text = (drawListView.Items.Count + 1) + "";

                lvi.SubItems.Add(item.DrawCenterX.ToString());
                lvi.SubItems.Add(item.DrawCenterY.ToString());
                drawListView.BeginUpdate();
                drawListView.Items.Add(lvi);
                drawListView.EndUpdate();

                // 绘制
                Label txtBox = new Label();
                txtBox.BorderStyle = BorderStyle.FixedSingle;
                txtBox.Text = (t.IndexOf(item) + 1) + "";
                txtBox.TextAlign = ContentAlignment.MiddleCenter;
                txtBox.SetBounds(draw_box_pointX, draw_box_pointY, (int)draw_box_length, (int)draw_box_width);
                panelView.Controls.Add(txtBox);
            }
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            string filePath = $"{this.GetType().Assembly.Location}box.pdf";
            pdfPrint(filePath);

            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private bool JudgeBoxInputEmpty()
        {
            if (isEmpty(boxWdith.Text, $"箱子长度") || isEmpty(boxHeight.Text, $"箱子宽度"))
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

        public void drawLine(DPoint fromXyPosition, DPoint toXyPosition)
        {
            this.gfx.DrawLine(this.pen, leftMargin + (fromXyPosition.x * cm), topMargin + (fromXyPosition.y * cm), leftMargin + (toXyPosition.x * cm), topMargin + (toXyPosition.y * cm));
        }

        private void drawTable(double initialPosX, double initialPosY, double width, double height, XBrush xbrush, List<String[]> contents = null)
        {
            drawSquare(new DPoint(initialPosX, initialPosY), width, height, xbrush);

            if (contents == null)
            {
                contents = new List<String[]>();

                contents.Add(new string[] { "Type", "Size", "Weight", "Stock", "Tax", "Price" });
                contents.Add(new string[] { "Obo", "1", "45", "56", "16.00", "6.50" });
                contents.Add(new string[] { "Crotolamo", "2", "72", "63", "16.00", "19.00" });
            }

            int columns = contents[0].Length;
            int rows = contents.Count;

            double distanceBetweenRows = height / rows;
            double distanceBetweenColumns = width / columns;

            /*******************************************************************/
            // Draw the row lines
            /*******************************************************************/

            DPoint pointA = new DPoint(initialPosX, initialPosY);
            DPoint pointB = new DPoint(initialPosX + width, initialPosY);

            for (int i = 0; i <= rows; i++)
            {
                drawLine(pointA, pointB);

                pointA.y = pointA.y + distanceBetweenRows;
                pointB.y = pointB.y + distanceBetweenRows;
            }
            pointA = new DPoint(initialPosX, initialPosY);
            pointB = new DPoint(initialPosX, initialPosY + height);

            for (int i = 0; i <= columns; i++)
            {
                drawLine(pointA, pointB);

                pointA.x = pointA.x + distanceBetweenColumns;
                pointB.x = pointB.x + distanceBetweenColumns;
            }

            pointA = new DPoint(initialPosX, initialPosY);

            foreach (String[] rowDataArray in contents)
            {
                foreach (String cellText in rowDataArray)
                {
                    this.gfx.DrawString(cellText, this.font, XBrushes.Black, new XRect(leftMargin + (pointA.x * cm), topMargin + (pointA.y * cm), distanceBetweenColumns * cm, distanceBetweenRows * cm), XStringFormats.Center);

                    pointA.x = pointA.x + distanceBetweenColumns;
                }

                pointA.x = initialPosX;
                pointA.y = pointA.y + distanceBetweenRows;
            }
        }

        private void drawSquare(DPoint xyStartingPosition, double width, double height, XBrush xbrush)
        {
            Console.WriteLine("Drawing square starting at: " + xyStartingPosition.x + "," + xyStartingPosition.y + " width: " + width + " height: " + height);
            this.gfx.DrawRectangle(xbrush, new XRect(leftMargin + (xyStartingPosition.x * cm), topMargin + (xyStartingPosition.y * cm), (width * cm), (height * cm)));
        }

        private void pdfPrint(string filePath)
        {
            int margin_left_right = 30;//左右边距
            int margin_top_bottom = 30;//上下边距
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            this.font = new XFont("Arial", 12, XFontStyle.Bold);
            this.pen = new XPen(XColors.Black, 0.5);

            page.Size = PageSize.A4;
            XGraphics gfx = XGraphics.FromPdfPage(page);
            this.gfx = gfx;
            XFont boldfont = new XFont("华文宋体", 14, XFontStyle.Bold);
            XFont regularfont = new XFont("华文宋体", 14, XFontStyle.Regular);
            int cur_x_1 = 0 + margin_left_right;
            int cur_y_1 = 0 + margin_top_bottom;
            gfx.DrawString("地台板参数:", boldfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 80, 20), XStringFormats.TopLeft);
            cur_x_1 += 86;
            gfx.DrawString("①长X宽X高: 1300*1100*50 (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            cur_y_1 += 20;
            gfx.DrawString("②长边允许凸出距离:   50   (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            cur_y_1 += 20;
            gfx.DrawString("③短边允许凸出距离:  -30   (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            int cur_x_2 = 0 + margin_left_right;
            int cur_y_2 = cur_y_1 + 25;
            gfx.DrawString("    纸箱参数:", boldfont, XBrushes.Black, new XRect(cur_x_2, cur_y_2, 80, 20), XStringFormats.TopLeft);
            cur_x_2 += 86;
            gfx.DrawString("①长X宽X高: 25*16*17 (mm)", regularfont, XBrushes.Black, new XRect(cur_x_2, cur_y_2, 120, 20), XStringFormats.TopLeft);
            int cur_x_3 = 0 + margin_left_right;
            int cur_y_3 = cur_y_2 + 25;
            gfx.DrawString("摆放图示及坐标参数", boldfont, XBrushes.Black, new XRect(cur_x_3, cur_y_3, 80, 20), XStringFormats.TopLeft);
            int cur_x_4 = cur_x_3 + 15;
            int cur_y_4 = cur_y_3 + 25;
            gfx.DrawString("右板单层图示", boldfont, XBrushes.Black, new XRect(cur_x_4, cur_y_4, 80, 20), XStringFormats.TopLeft);
            cur_x_4 += 280;
            gfx.DrawString("右板单层坐标参数", boldfont, XBrushes.Black, new XRect(cur_x_4, cur_y_4, 80, 20), XStringFormats.TopLeft);

            ////一条横线
            //var line_x = 0 + margin_left_right;
            //var line_y = cur_y + 40;
            //XPen pen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 1);
            //gfx.DrawLine(pen, line_x, line_y, page.Width - line_x, line_y + 2);
            //if (AList.Any() == true)
            //{
            //    cur_x = 0 + margin_left_right;
            //    cur_y = line_y + 20;
            //    font = new XFont("华文宋体", 20, XFontStyle.Regular);
            //    gfx.DrawString("地台板A:", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
            //    // 箱子
            //    var box_x = 0 + margin_left_right;
            //    cur_y = cur_y + 40;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("箱子", font, XBrushes.Black, new XRect(box_x, cur_y, 100, 60), XStringFormats.TopLeft);
            //    // 坐标轴X
            //    var point_x_x = 0 + margin_left_right + 40;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("坐标轴X", font, XBrushes.Black, new XRect(point_x_x, cur_y, 120, 60), XStringFormats.TopLeft);
            //    //坐标轴Y
            //    var point_y_x = 0 + margin_left_right + 100;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("坐标轴Y", font, XBrushes.Black, new XRect(point_y_x, cur_y, 120, 60), XStringFormats.TopLeft);
            //    foreach (var item in AList)
            //    {
            //        cur_y = cur_y + 20;
            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString((AList.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString(item.DrawCenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString(item.DrawCenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
            //    }
            //}
            //if (BList.Any() == true)
            //{
            //    cur_x = 0 + margin_left_right + 240;
            //    cur_y = line_y + 20;
            //    font = new XFont("华文宋体", 20, XFontStyle.Regular);
            //    gfx.DrawString("地台板B:", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
            //    // 箱子
            //    var box_x = 0 + margin_left_right + 240;
            //    cur_y = cur_y + 40;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("箱子", font, XBrushes.Black, new XRect(box_x, cur_y, 100, 60), XStringFormats.TopLeft);
            //    // 坐标轴X
            //    var point_x_x = 0 + margin_left_right + 40 + 240;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("坐标轴X", font, XBrushes.Black, new XRect(point_x_x, cur_y, 120, 60), XStringFormats.TopLeft);
            //    //坐标轴Y
            //    var point_y_x = 0 + margin_left_right + 100 + 240;
            //    font = new XFont("华文宋体", 14, XFontStyle.Regular);
            //    gfx.DrawString("坐标轴Y", font, XBrushes.Black, new XRect(point_y_x, cur_y, 120, 60), XStringFormats.TopLeft);
            //    foreach (var item in BList)
            //    {
            //        cur_y = cur_y + 20;
            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString((BList.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString(item.DrawCenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

            //        font = new XFont("华文宋体", 12, XFontStyle.Regular);
            //        gfx.DrawString(item.DrawCenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
            //    }
            //}

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

        private void boxWdith_TextChanged(object sender, EventArgs e)
        {
        }

        private void groupBoxA_Enter(object sender, EventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw3DBoxContainer(e);
            //Draw3DBoardContainer(e);
        }

        private void Draw3DBoxContainer(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Rectangle A = new Rectangle(80, 80, 100, 100);
            Rectangle B = new Rectangle(60, 60, 100, 100);
            Point[] points = new Point[8];
            points[0] = new Point(A.Left, A.Top);
            points[1] = new Point(B.Left, B.Top);
            points[2] = new Point(A.Right, A.Top);
            points[3] = new Point(B.Right, B.Top);
            points[4] = new Point(A.Left, A.Bottom);
            points[5] = new Point(B.Left, B.Bottom);
            points[6] = new Point(A.Right, A.Bottom);
            points[7] = new Point(B.Right, B.Bottom);
            graph.DrawRectangle(Pens.Black, A);
            graph.DrawRectangle(Pens.Black, B);
            graph.DrawLine(Pens.Black, points[0], points[1]);
            graph.DrawLine(Pens.Black, points[2], points[3]);
            graph.DrawLine(Pens.Black, points[4], points[5]);
            graph.DrawLine(Pens.Black, points[6], points[7]);
        }

        private void Draw3DBoardContainer(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Rectangle A = new Rectangle(60, 400, 120, 30);
            Rectangle B = new Rectangle(40, 450, 120, 30);
            Point[] points = new Point[8];
            points[0] = new Point(A.Left, A.Top);
            points[1] = new Point(B.Left, B.Top);
            points[2] = new Point(A.Right, A.Top);
            points[3] = new Point(B.Right, B.Top);
            points[4] = new Point(A.Left, A.Bottom);
            points[5] = new Point(B.Left, B.Bottom);
            points[6] = new Point(A.Right, A.Bottom);
            points[7] = new Point(B.Right, B.Bottom);
            graph.DrawRectangle(Pens.Black, A);
            graph.DrawRectangle(Pens.Black, B);
            graph.DrawLine(Pens.Black, points[0], points[1]);
            graph.DrawLine(Pens.Black, points[2], points[3]);
            graph.DrawLine(Pens.Black, points[4], points[5]);
            graph.DrawLine(Pens.Black, points[6], points[7]);
        }

        private void label23_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click_3(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
        }
    }
}