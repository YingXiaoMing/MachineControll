
namespace FormControll
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.boxWidthText = new System.Windows.Forms.Label();
            this.boxWdith = new System.Windows.Forms.TextBox();
            this.boxContainer = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.boxHeight = new System.Windows.Forms.TextBox();
            this.boxHeightText = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxA = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.boardALeft = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.boardATop = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.boardAHeight = new System.Windows.Forms.TextBox();
            this.boardAHeightText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.boardAWidth = new System.Windows.Forms.TextBox();
            this.boardAWidthText = new System.Windows.Forms.Label();
            this.groupBoxB = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.boardBRight = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.boardBBottom = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.boardBHeight = new System.Windows.Forms.TextBox();
            this.boardBHeightText = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.boardBWidth = new System.Windows.Forms.TextBox();
            this.boardBWidthText = new System.Windows.Forms.Label();
            this.drawBtn = new System.Windows.Forms.Button();
            this.listViewA = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CenterX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CenterY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewB = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.printBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.boxContainer.SuspendLayout();
            this.groupBoxA.SuspendLayout();
            this.groupBoxB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // boxWidthText
            // 
            this.boxWidthText.AutoSize = true;
            this.boxWidthText.Font = new System.Drawing.Font("宋体", 14F);
            this.boxWidthText.Location = new System.Drawing.Point(12, 31);
            this.boxWidthText.Name = "boxWidthText";
            this.boxWidthText.Size = new System.Drawing.Size(57, 19);
            this.boxWidthText.TabIndex = 1;
            this.boxWidthText.Text = "长度:";
            this.boxWidthText.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // boxWdith
            // 
            this.boxWdith.Font = new System.Drawing.Font("宋体", 14F);
            this.boxWdith.Location = new System.Drawing.Point(75, 26);
            this.boxWdith.Name = "boxWdith";
            this.boxWdith.Size = new System.Drawing.Size(100, 29);
            this.boxWdith.TabIndex = 2;
            this.boxWdith.TextChanged += new System.EventHandler(this.boxWdith_TextChanged);
            // 
            // boxContainer
            // 
            this.boxContainer.Controls.Add(this.label4);
            this.boxContainer.Controls.Add(this.textBox2);
            this.boxContainer.Controls.Add(this.label5);
            this.boxContainer.Controls.Add(this.label2);
            this.boxContainer.Controls.Add(this.boxHeight);
            this.boxContainer.Controls.Add(this.boxHeightText);
            this.boxContainer.Controls.Add(this.label1);
            this.boxContainer.Controls.Add(this.boxWdith);
            this.boxContainer.Controls.Add(this.boxWidthText);
            this.boxContainer.Font = new System.Drawing.Font("宋体", 13F);
            this.boxContainer.Location = new System.Drawing.Point(23, 28);
            this.boxContainer.Name = "boxContainer";
            this.boxContainer.Size = new System.Drawing.Size(236, 173);
            this.boxContainer.TabIndex = 3;
            this.boxContainer.TabStop = false;
            this.boxContainer.Text = "箱子";
            this.boxContainer.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(185, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "MM";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox2.Location = new System.Drawing.Point(75, 121);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 29);
            this.textBox2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "高度:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(185, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "MM";
            // 
            // boxHeight
            // 
            this.boxHeight.Font = new System.Drawing.Font("宋体", 14F);
            this.boxHeight.Location = new System.Drawing.Point(75, 74);
            this.boxHeight.Name = "boxHeight";
            this.boxHeight.Size = new System.Drawing.Size(100, 29);
            this.boxHeight.TabIndex = 6;
            // 
            // boxHeightText
            // 
            this.boxHeightText.AutoSize = true;
            this.boxHeightText.Font = new System.Drawing.Font("宋体", 14F);
            this.boxHeightText.Location = new System.Drawing.Point(12, 79);
            this.boxHeightText.Name = "boxHeightText";
            this.boxHeightText.Size = new System.Drawing.Size(57, 19);
            this.boxHeightText.TabIndex = 5;
            this.boxHeightText.Text = "宽度:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(185, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "MM";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // groupBoxA
            // 
            this.groupBoxA.Controls.Add(this.label13);
            this.groupBoxA.Controls.Add(this.boardALeft);
            this.groupBoxA.Controls.Add(this.label12);
            this.groupBoxA.Controls.Add(this.boardATop);
            this.groupBoxA.Controls.Add(this.label10);
            this.groupBoxA.Controls.Add(this.textBox4);
            this.groupBoxA.Controls.Add(this.label11);
            this.groupBoxA.Controls.Add(this.label8);
            this.groupBoxA.Controls.Add(this.boardAHeight);
            this.groupBoxA.Controls.Add(this.boardAHeightText);
            this.groupBoxA.Controls.Add(this.label6);
            this.groupBoxA.Controls.Add(this.panel1);
            this.groupBoxA.Controls.Add(this.boardAWidth);
            this.groupBoxA.Controls.Add(this.boardAWidthText);
            this.groupBoxA.Location = new System.Drawing.Point(299, 28);
            this.groupBoxA.Name = "groupBoxA";
            this.groupBoxA.Size = new System.Drawing.Size(718, 312);
            this.groupBoxA.TabIndex = 4;
            this.groupBoxA.TabStop = false;
            this.groupBoxA.Text = "地台板A";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(293, 154);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "MM";
            // 
            // boardALeft
            // 
            this.boardALeft.Location = new System.Drawing.Point(241, 150);
            this.boardALeft.Name = "boardALeft";
            this.boardALeft.Size = new System.Drawing.Size(46, 21);
            this.boardALeft.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(489, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "MM";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // boardATop
            // 
            this.boardATop.Location = new System.Drawing.Point(437, 38);
            this.boardATop.Name = "boardATop";
            this.boardATop.Size = new System.Drawing.Size(46, 21);
            this.boardATop.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 14F);
            this.label10.Location = new System.Drawing.Point(189, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "MM";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox4.Location = new System.Drawing.Point(79, 126);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 29);
            this.textBox4.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 14F);
            this.label11.Location = new System.Drawing.Point(16, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "高度:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14F);
            this.label8.Location = new System.Drawing.Point(189, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "MM";
            // 
            // boardAHeight
            // 
            this.boardAHeight.Font = new System.Drawing.Font("宋体", 14F);
            this.boardAHeight.Location = new System.Drawing.Point(79, 79);
            this.boardAHeight.Name = "boardAHeight";
            this.boardAHeight.Size = new System.Drawing.Size(100, 29);
            this.boardAHeight.TabIndex = 15;
            // 
            // boardAHeightText
            // 
            this.boardAHeightText.AutoSize = true;
            this.boardAHeightText.Font = new System.Drawing.Font("宋体", 14F);
            this.boardAHeightText.Location = new System.Drawing.Point(16, 84);
            this.boardAHeightText.Name = "boardAHeightText";
            this.boardAHeightText.Size = new System.Drawing.Size(57, 19);
            this.boardAHeightText.TabIndex = 14;
            this.boardAHeightText.Text = "宽度:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(189, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "MM";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(314, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 189);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // boardAWidth
            // 
            this.boardAWidth.Font = new System.Drawing.Font("宋体", 14F);
            this.boardAWidth.Location = new System.Drawing.Point(79, 31);
            this.boardAWidth.Name = "boardAWidth";
            this.boardAWidth.Size = new System.Drawing.Size(100, 29);
            this.boardAWidth.TabIndex = 12;
            this.boardAWidth.TextChanged += new System.EventHandler(this.boardAWidth_TextChanged);
            // 
            // boardAWidthText
            // 
            this.boardAWidthText.AutoSize = true;
            this.boardAWidthText.Font = new System.Drawing.Font("宋体", 14F);
            this.boardAWidthText.Location = new System.Drawing.Point(16, 36);
            this.boardAWidthText.Name = "boardAWidthText";
            this.boardAWidthText.Size = new System.Drawing.Size(57, 19);
            this.boardAWidthText.TabIndex = 11;
            this.boardAWidthText.Text = "长度:";
            // 
            // groupBoxB
            // 
            this.groupBoxB.Controls.Add(this.label16);
            this.groupBoxB.Controls.Add(this.boardBRight);
            this.groupBoxB.Controls.Add(this.label17);
            this.groupBoxB.Controls.Add(this.boardBBottom);
            this.groupBoxB.Controls.Add(this.label20);
            this.groupBoxB.Controls.Add(this.textBox11);
            this.groupBoxB.Controls.Add(this.label21);
            this.groupBoxB.Controls.Add(this.label22);
            this.groupBoxB.Controls.Add(this.boardBHeight);
            this.groupBoxB.Controls.Add(this.boardBHeightText);
            this.groupBoxB.Controls.Add(this.label24);
            this.groupBoxB.Controls.Add(this.panel2);
            this.groupBoxB.Controls.Add(this.boardBWidth);
            this.groupBoxB.Controls.Add(this.boardBWidthText);
            this.groupBoxB.Location = new System.Drawing.Point(299, 402);
            this.groupBoxB.Name = "groupBoxB";
            this.groupBoxB.Size = new System.Drawing.Size(718, 312);
            this.groupBoxB.TabIndex = 28;
            this.groupBoxB.TabStop = false;
            this.groupBoxB.Text = "地台板B";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(692, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 27;
            this.label16.Text = "MM";
            // 
            // boardBRight
            // 
            this.boardBRight.Location = new System.Drawing.Point(640, 153);
            this.boardBRight.Name = "boardBRight";
            this.boardBRight.Size = new System.Drawing.Size(46, 21);
            this.boardBRight.TabIndex = 26;
            this.boardBRight.TextChanged += new System.EventHandler(this.boardBRight_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(489, 268);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "MM";
            // 
            // boardBBottom
            // 
            this.boardBBottom.Location = new System.Drawing.Point(437, 264);
            this.boardBBottom.Name = "boardBBottom";
            this.boardBBottom.Size = new System.Drawing.Size(46, 21);
            this.boardBBottom.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 14F);
            this.label20.Location = new System.Drawing.Point(189, 131);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 19);
            this.label20.TabIndex = 19;
            this.label20.Text = "MM";
            // 
            // textBox11
            // 
            this.textBox11.Font = new System.Drawing.Font("宋体", 14F);
            this.textBox11.Location = new System.Drawing.Point(79, 126);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 29);
            this.textBox11.TabIndex = 18;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 14F);
            this.label21.Location = new System.Drawing.Point(16, 131);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 19);
            this.label21.TabIndex = 17;
            this.label21.Text = "高度:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 14F);
            this.label22.Location = new System.Drawing.Point(189, 84);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 19);
            this.label22.TabIndex = 16;
            this.label22.Text = "MM";
            // 
            // boardBHeight
            // 
            this.boardBHeight.Font = new System.Drawing.Font("宋体", 14F);
            this.boardBHeight.Location = new System.Drawing.Point(79, 79);
            this.boardBHeight.Name = "boardBHeight";
            this.boardBHeight.Size = new System.Drawing.Size(100, 29);
            this.boardBHeight.TabIndex = 15;
            // 
            // boardBHeightText
            // 
            this.boardBHeightText.AutoSize = true;
            this.boardBHeightText.Font = new System.Drawing.Font("宋体", 14F);
            this.boardBHeightText.Location = new System.Drawing.Point(16, 84);
            this.boardBHeightText.Name = "boardBHeightText";
            this.boardBHeightText.Size = new System.Drawing.Size(57, 19);
            this.boardBHeightText.TabIndex = 14;
            this.boardBHeightText.Text = "宽度:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 14F);
            this.label24.Location = new System.Drawing.Point(189, 36);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 19);
            this.label24.TabIndex = 13;
            this.label24.Text = "MM";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(314, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 189);
            this.panel2.TabIndex = 0;
            // 
            // boardBWidth
            // 
            this.boardBWidth.Font = new System.Drawing.Font("宋体", 14F);
            this.boardBWidth.Location = new System.Drawing.Point(79, 31);
            this.boardBWidth.Name = "boardBWidth";
            this.boardBWidth.Size = new System.Drawing.Size(100, 29);
            this.boardBWidth.TabIndex = 12;
            // 
            // boardBWidthText
            // 
            this.boardBWidthText.AutoSize = true;
            this.boardBWidthText.Font = new System.Drawing.Font("宋体", 14F);
            this.boardBWidthText.Location = new System.Drawing.Point(16, 36);
            this.boardBWidthText.Name = "boardBWidthText";
            this.boardBWidthText.Size = new System.Drawing.Size(57, 19);
            this.boardBWidthText.TabIndex = 11;
            this.boardBWidthText.Text = "长度:";
            // 
            // drawBtn
            // 
            this.drawBtn.Location = new System.Drawing.Point(1093, 739);
            this.drawBtn.Name = "drawBtn";
            this.drawBtn.Size = new System.Drawing.Size(75, 23);
            this.drawBtn.TabIndex = 29;
            this.drawBtn.Text = "绘制";
            this.drawBtn.UseVisualStyleBackColor = true;
            this.drawBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // listViewA
            // 
            this.listViewA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.CenterX,
            this.CenterY});
            this.listViewA.FullRowSelect = true;
            this.listViewA.GridLines = true;
            this.listViewA.HideSelection = false;
            this.listViewA.Location = new System.Drawing.Point(1023, 34);
            this.listViewA.Name = "listViewA";
            this.listViewA.Size = new System.Drawing.Size(226, 306);
            this.listViewA.TabIndex = 31;
            this.listViewA.UseCompatibleStateImageBehavior = false;
            this.listViewA.View = System.Windows.Forms.View.Details;
            this.listViewA.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // No
            // 
            this.No.Text = "箱子";
            // 
            // CenterX
            // 
            this.CenterX.Text = "X轴坐标";
            // 
            // CenterY
            // 
            this.CenterY.Text = "Y轴坐标";
            // 
            // listViewB
            // 
            this.listViewB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewB.FullRowSelect = true;
            this.listViewB.GridLines = true;
            this.listViewB.HideSelection = false;
            this.listViewB.Location = new System.Drawing.Point(1023, 408);
            this.listViewB.Name = "listViewB";
            this.listViewB.Size = new System.Drawing.Size(226, 306);
            this.listViewB.TabIndex = 32;
            this.listViewB.UseCompatibleStateImageBehavior = false;
            this.listViewB.View = System.Windows.Forms.View.Details;
            this.listViewB.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "箱子";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "X轴坐标";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Y轴坐标";
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(1174, 739);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(75, 23);
            this.printBtn.TabIndex = 30;
            this.printBtn.Text = "打印";
            this.printBtn.UseVisualStyleBackColor = true;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BackgroundImage = global::FormControll.Properties.Resources.机械臂_copy;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(691, 346);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 60);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 774);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listViewB);
            this.Controls.Add(this.listViewA);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.drawBtn);
            this.Controls.Add(this.groupBoxB);
            this.Controls.Add(this.groupBoxA);
            this.Controls.Add(this.boxContainer);
            this.Name = "Form1";
            this.Text = "地台板计算工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.boxContainer.ResumeLayout(false);
            this.boxContainer.PerformLayout();
            this.groupBoxA.ResumeLayout(false);
            this.groupBoxA.PerformLayout();
            this.groupBoxB.ResumeLayout(false);
            this.groupBoxB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label boxWidthText;
        private System.Windows.Forms.TextBox boxWdith;
        private System.Windows.Forms.GroupBox boxContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox boxHeight;
        private System.Windows.Forms.Label boxHeightText;
        private System.Windows.Forms.GroupBox groupBoxA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox boardATop;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox boardAHeight;
        private System.Windows.Forms.Label boardAHeightText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox boardAWidth;
        private System.Windows.Forms.Label boardAWidthText;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox boardALeft;
        private System.Windows.Forms.GroupBox groupBoxB;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox boardBRight;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox boardBBottom;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox boardBHeight;
        private System.Windows.Forms.Label boardBHeightText;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox boardBWidth;
        private System.Windows.Forms.Label boardBWidthText;
        private System.Windows.Forms.Button drawBtn;
        private System.Windows.Forms.ListView listViewA;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader CenterX;
        private System.Windows.Forms.ColumnHeader CenterY;
        private System.Windows.Forms.ListView listViewB;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

