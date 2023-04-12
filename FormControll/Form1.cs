﻿using PdfSharp;
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

        private List<ItemInfo> AList { get; set; } = new List<ItemInfo>();
        private List<ItemInfo> BList { get; set; } = new List<ItemInfo>();

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

        private void DrawBtn_Click(object sender, EventArgs e)
        {
            // 判断输入条件是否为空
            if (JudgeBoxInputEmpty()) return;

            if (string.IsNullOrWhiteSpace(boardAWidth.Text) == false && string.IsNullOrWhiteSpace(boardAHeight.Text) == false)
            {
                AList = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardAWidth.Text)), int.Parse(HandleEmptyText(boardAHeight.Text)), int.Parse(HandleEmptyText(boardALeft.Text)), int.Parse(HandleEmptyText(boardATop.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
                var newList = AList.OrderBy(t => t.PointX).ToList();
                DrawListView(listViewA, newList, int.Parse(boardAWidth.Text), int.Parse(boardAHeight.Text), panel1);
            }
            else
            {
                listViewA.Items.Clear();
                panel1.Controls.Clear();
            }

            if (string.IsNullOrWhiteSpace(boardBWidth.Text) == false &&
                string.IsNullOrWhiteSpace(boardBHeight.Text) == false)
            {
                BList = CoordinateCalculation.GetItemInfos(int.Parse(HandleEmptyText(boardBWidth.Text)), int.Parse(HandleEmptyText(boardBHeight.Text)), int.Parse(HandleEmptyText(boardBRight.Text)), int.Parse(HandleEmptyText(boardBBottom.Text)), int.Parse(HandleEmptyText(boxWdith.Text)), int.Parse(HandleEmptyText(boxHeight.Text)));
                var newList = BList.OrderByDescending(t => t.PointX).ToList();
                DrawListView(listViewB, newList, int.Parse(boardBWidth.Text), int.Parse(boardBHeight.Text), panel2);
            }
            else
            {
                listViewB.Items.Clear();
                panel2.Controls.Clear();
            }
        }

        private void DrawListView(ListView drawListView, List<ItemInfo> t, int board_length, int board_width, Panel panelView)
        {
            // 更改版面的宽度
            var p_width = (int)(((decimal)panelView.Height / (decimal)board_width) * board_length);
            var save_board_width = panelView.Width;
            var disparityWidth = save_board_width - p_width; //缩减的宽度差
            panelView.Width = p_width;
            if (drawListView.Name.Equals("listViewA"))
            {
                pictureBox3.Location = new Point(pictureBox3.Location.X - disparityWidth, pictureBox3.Location.Y);
                pictureBox5.Location = new Point(pictureBox5.Location.X - disparityWidth, pictureBox5.Location.Y);
                label15.Location = new Point(label15.Location.X - disparityWidth, label15.Location.Y);
            }
            drawListView.Items.Clear();
            panelView.Controls.Clear();
            foreach (var item in t)
            {
                var draw_box_length = (decimal)p_width / ((decimal)board_length / (decimal)item.Length);
                var draw_box_width = (decimal)panelView.Height / ((decimal)board_width / (decimal)item.Width);

                //var draw_box_length = (decimal)p_width * ((decimal)item.Length / (decimal)board_length);
                //var draw_box_width = (decimal)panelView.Height * ((decimal)item.Width / (decimal)board_width);
                var draw_box_pointX = (int)(((decimal)item.PointX / (decimal)board_length) * (decimal)p_width);
                var draw_box_pointY = (int)(((decimal)item.PointY / (decimal)board_width) * (decimal)panelView.Height);

                if (drawListView.Name.Equals("listViewA"))
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
            if (AList.Any() == true)
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
                foreach (var item in AList)
                {
                    cur_y = cur_y + 20;
                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString((AList.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.DrawCenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.DrawCenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
                }
            }
            if (BList.Any() == true)
            {
                cur_x = 0 + margin_left_right + 240;
                cur_y = line_y + 20;
                font = new XFont("华文宋体", 20, XFontStyle.Regular);
                gfx.DrawString("地台板B:", font, XBrushes.Black, new XRect(cur_x, cur_y, page.Width - 2 * cur_x, 40), XStringFormats.TopLeft);
                // 箱子
                var box_x = 0 + margin_left_right + 240;
                cur_y = cur_y + 40;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("箱子", font, XBrushes.Black, new XRect(box_x, cur_y, 100, 60), XStringFormats.TopLeft);
                // 坐标轴X
                var point_x_x = 0 + margin_left_right + 40 + 240;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴X", font, XBrushes.Black, new XRect(point_x_x, cur_y, 120, 60), XStringFormats.TopLeft);
                //坐标轴Y
                var point_y_x = 0 + margin_left_right + 100 + 240;
                font = new XFont("华文宋体", 14, XFontStyle.Regular);
                gfx.DrawString("坐标轴Y", font, XBrushes.Black, new XRect(point_y_x, cur_y, 120, 60), XStringFormats.TopLeft);
                foreach (var item in BList)
                {
                    cur_y = cur_y + 20;
                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString((BList.IndexOf(item) + 1).ToString(), font, XBrushes.Black, new XRect(box_x + 10, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.DrawCenterX.ToString(), font, XBrushes.Black, new XRect(point_x_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);

                    font = new XFont("华文宋体", 12, XFontStyle.Regular);
                    gfx.DrawString(item.DrawCenterY.ToString(), font, XBrushes.Black, new XRect(point_y_x + 20, cur_y, 60, 40), XStringFormats.TopLeft);
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
    }
}