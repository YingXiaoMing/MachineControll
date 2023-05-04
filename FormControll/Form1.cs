using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private List<ItemInfo> LeftSingleList { get; set; } = new List<ItemInfo>();
        private List<ItemInfo> LeftDoubleList { get; set; } = new List<ItemInfo>();

        private MemoryStream ms1 { get; set; } = new MemoryStream();
        private MemoryStream ms2 { get; set; } = new MemoryStream();
        private MemoryStream ms3 { get; set; } = new MemoryStream();
        private MemoryStream ms4 { get; set; } = new MemoryStream();

        private int XOffset = 0;
        private int YOffset = 0;
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

        private void ScreenShotPanelView(Panel panelView, MemoryStream ms)
        {
            Bitmap bmp = new Bitmap(panelView.Width, panelView.Height);
            panelView.DrawToBitmap(bmp, panelView.ClientRectangle);
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        }

        private string HandleEmptyText(string txt)
        {
            return string.IsNullOrEmpty(txt) ? "0" : txt;
        }

        private void drawRightSingleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), XOffset, YOffset, int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result;
            nlist.ForEach(item =>
            {
                item.DrawX = item.PointY;
                item.DrawY = item.PointX;
            });
            RightSingleList = nlist;
            DrawListView(listView1, RightSingleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel1);
        }

        private void drawRightDoubleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), XOffset, YOffset, int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result;
            nlist.ForEach(item =>
            {
                item.DrawX = int.Parse(HandleEmptyText(boardHeight.Text)) - item.PointY - item.Width;
                item.DrawY = int.Parse(HandleEmptyText(boardWidth.Text)) - item.PointX - item.Length;
            });
            nlist.Reverse();
            RightDoubleList = nlist;
            DrawListView(listView2, RightDoubleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel2);
        }

        private void drawLeftSingleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), XOffset, YOffset, int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result;
            nlist.ForEach(item =>
            {
                item.DrawX = item.PointY;
                item.DrawY = item.PointX;
            });
            LeftSingleList = nlist.OrderByDescending(t => t.DrawX).ToList();
            DrawListView(listView3, LeftSingleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel3);
        }

        private void drawLeftDoubleBoard()
        {
            var result = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardWidth.Text)), int.Parse(HandleEmptyText(boardHeight.Text)), XOffset, YOffset, int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
            var nlist = result;
            nlist.ForEach(item =>
            {
                item.DrawX = int.Parse(HandleEmptyText(boardHeight.Text)) - item.PointY - item.Width;
                item.DrawY = int.Parse(HandleEmptyText(boardWidth.Text)) - item.PointX - item.Length;
            });
            nlist.Reverse();
            LeftDoubleList = nlist.OrderByDescending(t => t.DrawX).ToList();
            DrawListView(listView4, LeftDoubleList, int.Parse(boardWidth.Text), int.Parse(boardHeight.Text), panel4);
        }


        private string ReturnShowOffsetDistance(string txt)
        {
            if (string.IsNullOrWhiteSpace(txt) || int.Parse(txt) == 0)
            {
                return "";
            }
            return int.Parse(txt) > 0 ? $"+ {txt} mm" : $"{txt} mm";
           
        }

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            // 判断输入条件是否为空
            if (JudgeInputEmpty()) return;
            LengthOffset.Text = ReturnShowOffsetDistance(boardALeft.Text);
            WidthOffset.Text = ReturnShowOffsetDistance(boardATop.Text);
            // 判断地台板和箱子长度不能小于宽度
            //if (JudgeBoxLengthLessThanWidth()) return;
            //if (JudgeBoardLengthLessThanWidth()) return;
            // textbox 输入的数字 条件限制，<= min(箱子长的1/5 ，箱子宽的1/5）
            if (JudgeXYOffsetOverMinValue()) return;

            drawRightSingleBoard();
            drawRightDoubleBoard();
            drawLeftSingleBoard();
            drawLeftDoubleBoard();
        }

        private void DrawListView(ListView drawListView, List<ItemInfo> t, int board_length, int board_width, Panel panelView, bool isDouble = false)
        {
            // 更改版面的宽度
            // 高度是固定，变化的是页面的宽度=地台板的宽度
            var p_width = (int)(((decimal)panelView.Height / (decimal)board_length) * board_width);
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
                var draw_box_length = (decimal)p_width / ((decimal)board_width / (decimal)item.Width);
                var draw_box_width = (decimal)panelView.Height / ((decimal)board_length / (decimal)item.Length);
                var draw_box_pointX = (int)Math.Round(((decimal)item.DrawX / (decimal)board_width) * (decimal)p_width);
                var draw_box_pointY = (int)Math.Round(((decimal)item.DrawY / (decimal)board_length) * (decimal)panelView.Height);

                // 根据需求重新绘制对应的坐标点
                if (drawListView.Name.Equals("listView1") || drawListView.Name.Equals("listView4"))
                {
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
            ms1 = new MemoryStream();
            ms2 = new MemoryStream();
            ms3 = new MemoryStream();
            ms4 = new MemoryStream();

            // 右版单层
            ScreenShotPanelView(panel1, ms1);
            // 右版双层
            ScreenShotPanelView(panel2, ms2);
            // 左版单层
            ScreenShotPanelView(panel3, ms3);
            // 左版双层
            ScreenShotPanelView(panel4, ms4);
            string filePath = $"{this.GetType().Assembly.Location}box.pdf";
            pdfPrint(filePath);
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private bool JudgeInputEmpty()
        {
            if (isEmpty(boxWdith.Text, $"箱子长度") || isEmpty(boxHeight.Text, $"箱子宽度") || isEmpty(boardWidth.Text, "地台板长度") || isEmpty(boardHeight.Text, "地台板宽度"))
            {
                return true;
            }
            return false;
        }

        private bool JudgeXYOffsetOverMinValue()
        {
            var box_width = int.Parse(boxHeight.Text);
            var box_length = int.Parse(boxWdith.Text);
            var length_offset = int.Parse(HandleEmptyText(boardALeft.Text));
            var width_offset = int.Parse(HandleEmptyText(boardATop.Text));

            var minNum = box_width / 5 < box_length / 5 ? box_width / 5 : box_length / 5;

            //长边距离和短边距离 min(箱子长的1/5 ，箱子宽的1/5）
            if (length_offset > minNum)
            {
                ShowTips($"箱子允许超出地台板长边的距离不超过{minNum}");
                return true;
            }
            if (width_offset > minNum)
            {
                ShowTips($"箱子允许超出地台板长边的距离不超过{minNum}");
                return true;
            }
            XOffset = length_offset;
            YOffset = width_offset;
            return false;
        }

        private bool JudgeBoxLengthLessThanWidth()
        {
            var box_width = int.Parse(boxHeight.Text);
            var box_length = int.Parse(boxWdith.Text);
            if (box_length < box_width)
            {
                ShowTips("箱子的长度不能小于宽度");
                return true;
            }
            return false;
        }

        private bool JudgeBoardLengthLessThanWidth()
        {
            var board_width = int.Parse(boardHeight.Text);
            var board_length = int.Parse(boardWidth.Text);
            if (board_length < board_width)
            {
                ShowTips("地台板的长度不能小于宽度");
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
            this.font = new XFont("Arial", 12, XFontStyle.Bold);
            this.pen = new XPen(XColors.Black, 0.5);

            page.Size = PageSize.A4;
            this.gfx = XGraphics.FromPdfPage(page);
            XFont boldfont = new XFont("黑体", 12, XFontStyle.Regular);
            XFont regularfont = new XFont("华文宋体", 12, XFontStyle.Regular);
            int cur_x_1 = 0 + margin_left_right;
            int cur_y_1 = 0 + margin_top_bottom;
            this.gfx.DrawString("  地台板参数:", boldfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 80, 20), XStringFormats.TopLeft);
            cur_x_1 += 86;
            this.gfx.DrawString($"①长X宽X高: {boardWidth.Text}*{boardHeight.Text}*{HandleEmptyText(textBox5.Text)} (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            cur_y_1 += 20;
            this.gfx.DrawString($"②长边允许凸出距离:   {HandleEmptyText(boardALeft.Text)}   (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            cur_y_1 += 20;
            this.gfx.DrawString($"③短边允许凸出距离:  {HandleEmptyText(boardATop.Text)}    (mm)", regularfont, XBrushes.Black, new XRect(cur_x_1, cur_y_1, 120, 20), XStringFormats.TopLeft);
            int cur_x_2 = 0 + margin_left_right;
            int cur_y_2 = cur_y_1 + 25;
            this.gfx.DrawString("    纸箱参数:", boldfont, XBrushes.Black, new XRect(cur_x_2, cur_y_2, 80, 20), XStringFormats.TopLeft);
            cur_x_2 += 86;
            this.gfx.DrawString($"①长X宽X高: {boxWdith.Text}*{boxHeight.Text}*{HandleEmptyText(textBox3.Text)} (mm)", regularfont, XBrushes.Black, new XRect(cur_x_2, cur_y_2, 120, 20), XStringFormats.TopLeft);
            int cur_x_3 = 0 + margin_left_right;
            int cur_y_3 = cur_y_2 + 25;
            this.gfx.DrawString("摆放图示及坐标参数", boldfont, XBrushes.Black, new XRect(cur_x_3, cur_y_3, 80, 20), XStringFormats.TopLeft);
            var t1 = DrawXYPointList(ms1, "右板单层图示", "右板单层坐标参数", cur_y_3, RightSingleList);
            var c_t1 = CheckOverPageHeight(page, document, t1, RightDoubleList.Count);
            var t2 = DrawXYPointList(ms2, "右板双层图示", "右板双层坐标参数", c_t1, RightDoubleList);
            var c_t2 = CheckOverPageHeight(page, document, t2, LeftSingleList.Count);
            var t3 = DrawXYPointList(ms3, "左板单层图示", "左板单层坐标参数", c_t2, LeftSingleList);
            var c_t3 = CheckOverPageHeight(page, document, t3, LeftDoubleList.Count);
            DrawXYPointList(ms4, "左板双层图示", "左板双层坐标参数", c_t3, LeftDoubleList);
            document.Save(filePath);
        }

        private int CheckOverPageHeight(PdfPage page, PdfDocument document, int point_y, int count)
        {
            var calc_height = point_y + 45 + 20 * count;
            var pageHeight = page.Height.Point;

            if (calc_height > pageHeight)
            {
                PdfPage t_page = document.AddPage();
                this.gfx = XGraphics.FromPdfPage(t_page);
                return 30;
            }
            return point_y;
        }

        private int DrawXYPointList(MemoryStream mStream, string leftTitle, string rightTitle, int bottom_y, List<ItemInfo> viewList)
        {
            XFont boldfont = new XFont("黑体", 12, XFontStyle.Regular);
            XFont regularfont = new XFont("华文宋体", 12, XFontStyle.Regular);
            int maxWidth = 260;
            // 左侧图层标题展示 例：右板单层图示
            int cur_x = 45;
            int cur_y = bottom_y + 25;
            this.gfx.DrawString(leftTitle, boldfont, XBrushes.Black, new XRect(cur_x, cur_y, 80, 20), XStringFormats.TopLeft);
            // 显示图层
            XImage img = XImage.FromStream(mStream);
            var imgWidth = img.PixelWidth > maxWidth ? maxWidth : img.PixelWidth;
            this.gfx.DrawImage(img, cur_x, cur_y + 20, imgWidth, img.PixelHeight);
            cur_x += 280;
            this.gfx.DrawString(rightTitle, boldfont, XBrushes.Black, new XRect(cur_x, cur_y, 80, 20), XStringFormats.TopLeft);
            var box_x_point = cur_x;
            var line_y_point = cur_y + 20;
            // 箱子
            this.gfx.DrawString("箱子", regularfont, XBrushes.Black, new XRect(box_x_point, line_y_point, 40, 20), XStringFormats.TopCenter);
            var x_x_point = cur_x + 100;
            // 坐标轴X
            this.gfx.DrawString("坐标轴X", regularfont, XBrushes.Black, new XRect(x_x_point, line_y_point, 40, 20), XStringFormats.TopCenter);
            var y_x_point = cur_x + 200;
            // 坐标轴Y
            this.gfx.DrawString("坐标轴Y", regularfont, XBrushes.Black, new XRect(y_x_point, line_y_point, 40, 20), XStringFormats.TopCenter);
            XPen pen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 1);
            this.gfx.DrawLine(pen, box_x_point,line_y_point + 20, box_x_point+240, line_y_point + 20);


            foreach (var item in viewList)
            {
                line_y_point += 20;
                this.gfx.DrawString((viewList.IndexOf(item) + 1).ToString(), regularfont, XBrushes.Black, new XRect(box_x_point, line_y_point, 40, 20), XStringFormats.Center);
                this.gfx.DrawString(item.DrawCenterX.ToString(), regularfont, XBrushes.Black, new XRect(x_x_point, line_y_point, 40, 20), XStringFormats.Center);
                this.gfx.DrawString(item.DrawCenterY.ToString(), regularfont, XBrushes.Black, new XRect(y_x_point, line_y_point, 40, 20), XStringFormats.Center);
                XPen line_pen = new XPen(XColor.FromKnownColor(XKnownColor.Black), 1);
                this.gfx.DrawLine(line_pen, box_x_point, line_y_point + 20, box_x_point + 240, line_y_point + 20);


            }

            var p_y = line_y_point > (int)(cur_y + 20 + img.PointHeight)? line_y_point : (int)(cur_y + img.PixelHeight + 20);
            return p_y;
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

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void boardHeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void VerifyBoardTop()
        {
            if (JudgeInputEmpty()) return;

            var box_width = int.Parse(boxHeight.Text);
            var box_length = int.Parse(boxWdith.Text);
            var width_offset = int.Parse(HandleEmptyText(boardATop.Text));

            var minNum = box_width / 5 < box_length / 5 ? box_width / 5 : box_length / 5;
            if (width_offset > minNum)
            {
                ShowTips($"箱子允许超出地台板宽度的距离不超过{minNum}");
                WidthOffset.Text = string.Empty;
                boardATop.SelectAll();
                return;
            }
            YOffset = width_offset;
            WidthOffset.Text = ReturnShowOffsetDistance(boardATop.Text);
        }

        private void VerifyBoardLeft()
        {

            if (JudgeInputEmpty()) return;
          
            var box_width = int.Parse(boxHeight.Text);
            var box_length = int.Parse(boxWdith.Text);
            var length_offset = int.Parse(HandleEmptyText(boardALeft.Text));

            var minNum = box_width / 5 < box_length / 5 ? box_width / 5 : box_length / 5;

            //长边距离和短边距离 min(箱子长的1/5 ，箱子宽的1/5
            if (length_offset > minNum)
            {
                ShowTips($"箱子允许超出地台板长度的距离不超过{minNum}");
                LengthOffset.Text = string.Empty;
                boardALeft.SelectAll();
                return;
            }
            XOffset = length_offset;
            LengthOffset.Text = ReturnShowOffsetDistance(boardALeft.Text);
        }

        private void boardALeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerifyBoardLeft();
        }

        private void boardATop_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerifyBoardTop();
        }

        private void boardALeft_TextChanged(object sender, EventArgs e)
        {

        }
    }
}