namespace EPunch.Tubebend
{
    partial class TestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.importBtn = new System.Windows.Forms.ToolStripButton();
            this.mouseBtn = new System.Windows.Forms.ToolStripButton();
            this.moveBtn = new System.Windows.Forms.ToolStripButton();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveNodeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.singlePickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multiPickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hitTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sectionBtn = new System.Windows.Forms.ToolStripButton();
            this.transOnSelectBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnReorder = new System.Windows.Forms.Button();
            this.gbxVertex = new System.Windows.Forms.GroupBox();
            this.txtR = new System.Windows.Forms.TextBox();
            this.txtThick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExportXml = new System.Windows.Forms.Button();
            this.gbxBending = new System.Windows.Forms.GroupBox();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.btnBendAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReadXml2 = new System.Windows.Forms.Button();
            this.btnUnfold = new System.Windows.Forms.Button();
            this.dgvVertex = new System.Windows.Forms.DataGridView();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.dgvBending = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.gbxVertex.SuspendLayout();
            this.gbxBending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVertex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBending)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importBtn,
            this.mouseBtn,
            this.moveBtn,
            this.clearBtn,
            this.toolStripSeparator1,
            this.moveNodeBtn,
            this.toolStripDropDownButton1,
            this.sectionBtn,
            this.transOnSelectBtn});
            this.toolStrip1.Location = new System.Drawing.Point(4, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(425, 31);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // importBtn
            // 
            this.importBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.importBtn.Image = ((System.Drawing.Image)(resources.GetObject("importBtn.Image")));
            this.importBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(29, 28);
            this.importBtn.Text = "Import";
            this.importBtn.Click += new System.EventHandler(this.ImportToolStripMenuItem_Click);
            // 
            // mouseBtn
            // 
            this.mouseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mouseBtn.Image = ((System.Drawing.Image)(resources.GetObject("mouseBtn.Image")));
            this.mouseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mouseBtn.Name = "mouseBtn";
            this.mouseBtn.Size = new System.Drawing.Size(29, 28);
            this.mouseBtn.Text = "toolStripButton1";
            this.mouseBtn.Click += new System.EventHandler(this.MouseBtn_Click);
            // 
            // moveBtn
            // 
            this.moveBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moveBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveBtn.Image")));
            this.moveBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(29, 28);
            this.moveBtn.Text = "Move";
            this.moveBtn.Click += new System.EventHandler(this.PanToolStripMenuItem_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearBtn.Image")));
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(29, 28);
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // moveNodeBtn
            // 
            this.moveNodeBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.moveNodeBtn.Image = ((System.Drawing.Image)(resources.GetObject("moveNodeBtn.Image")));
            this.moveNodeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moveNodeBtn.Name = "moveNodeBtn";
            this.moveNodeBtn.Size = new System.Drawing.Size(55, 28);
            this.moveNodeBtn.Text = "Move";
            this.moveNodeBtn.Click += new System.EventHandler(this.MoveNodeBtn_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.singlePickToolStripMenuItem,
            this.multiPickToolStripMenuItem,
            this.hitTestToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(52, 28);
            this.toolStripDropDownButton1.Text = "Pick";
            // 
            // singlePickToolStripMenuItem
            // 
            this.singlePickToolStripMenuItem.Name = "singlePickToolStripMenuItem";
            this.singlePickToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.singlePickToolStripMenuItem.Text = "SinglePick";
            this.singlePickToolStripMenuItem.Click += new System.EventHandler(this.SinglePickToolStripMenuItem_Click);
            // 
            // multiPickToolStripMenuItem
            // 
            this.multiPickToolStripMenuItem.Name = "multiPickToolStripMenuItem";
            this.multiPickToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.multiPickToolStripMenuItem.Text = "MultiPick";
            this.multiPickToolStripMenuItem.Click += new System.EventHandler(this.MultiPickToolStripMenuItem_Click);
            // 
            // hitTestToolStripMenuItem
            // 
            this.hitTestToolStripMenuItem.Name = "hitTestToolStripMenuItem";
            this.hitTestToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
            this.hitTestToolStripMenuItem.Text = "Hit Test";
            this.hitTestToolStripMenuItem.Click += new System.EventHandler(this.HitTestToolStripMenuItem_Click);
            // 
            // sectionBtn
            // 
            this.sectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("sectionBtn.Image")));
            this.sectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sectionBtn.Name = "sectionBtn";
            this.sectionBtn.Size = new System.Drawing.Size(68, 28);
            this.sectionBtn.Text = "Section";
            this.sectionBtn.Click += new System.EventHandler(this.SectionBtn_Click);
            // 
            // transOnSelectBtn
            // 
            this.transOnSelectBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.transOnSelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("transOnSelectBtn.Image")));
            this.transOnSelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transOnSelectBtn.Name = "transOnSelectBtn";
            this.transOnSelectBtn.Size = new System.Drawing.Size(115, 28);
            this.transOnSelectBtn.Text = "transOnSelect";
            this.transOnSelectBtn.Click += new System.EventHandler(this.TransOnSelectBtn_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1362, 735);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1362, 766);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = " ";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1362, 735);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1354, 710);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "3D";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1348, 704);
            this.splitContainer1.SplitterDistance = 856;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 700);
            this.panel1.TabIndex = 0;
            this.panel1.SizeChanged += new System.EventHandler(this.Panel1_SizeChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Size = new System.Drawing.Size(491, 704);
            this.splitContainer2.SplitterDistance = 347;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 343);
            this.panel2.TabIndex = 0;
            this.panel2.SizeChanged += new System.EventHandler(this.Panel2_SizeChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(487, 352);
            this.panel3.TabIndex = 0;
            this.panel3.SizeChanged += new System.EventHandler(this.Panel3_SizeChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1354, 706);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unfold";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.AutoScroll = true;
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(1348, 700);
            this.splitContainer3.SplitterDistance = 489;
            this.splitContainer3.SplitterWidth = 1;
            this.splitContainer3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 696);
            this.panel4.TabIndex = 0;
            this.panel4.SizeChanged += new System.EventHandler(this.Panel4_SizeChanged);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.AutoScroll = true;
            this.splitContainer4.Panel1.Controls.Add(this.txtDir);
            this.splitContainer4.Panel1.Controls.Add(this.label7);
            this.splitContainer4.Panel1.Controls.Add(this.btnReorder);
            this.splitContainer4.Panel1.Controls.Add(this.gbxVertex);
            this.splitContainer4.Panel1.Controls.Add(this.btnExportXml);
            this.splitContainer4.Panel1.Controls.Add(this.gbxBending);
            this.splitContainer4.Panel1.Controls.Add(this.btnReadXml2);
            this.splitContainer4.Panel1.Controls.Add(this.btnUnfold);
            this.splitContainer4.Panel1.Controls.Add(this.dgvVertex);
            this.splitContainer4.Panel1.Controls.Add(this.btnNext);
            this.splitContainer4.Panel1.Controls.Add(this.btnLast);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.dgvBending);
            this.splitContainer4.Size = new System.Drawing.Size(854, 696);
            this.splitContainer4.SplitterDistance = 342;
            this.splitContainer4.TabIndex = 20;
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(101, 289);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(100, 25);
            this.txtDir.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 292);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "转料(B)";
            // 
            // btnReorder
            // 
            this.btnReorder.Location = new System.Drawing.Point(207, 143);
            this.btnReorder.Name = "btnReorder";
            this.btnReorder.Size = new System.Drawing.Size(75, 23);
            this.btnReorder.TabIndex = 19;
            this.btnReorder.Text = "Reorder";
            this.btnReorder.UseVisualStyleBackColor = true;
            // 
            // gbxVertex
            // 
            this.gbxVertex.AutoSize = true;
            this.gbxVertex.Controls.Add(this.txtR);
            this.gbxVertex.Controls.Add(this.txtThick);
            this.gbxVertex.Controls.Add(this.label4);
            this.gbxVertex.Controls.Add(this.btnDraw);
            this.gbxVertex.Controls.Add(this.label6);
            this.gbxVertex.Location = new System.Drawing.Point(16, 3);
            this.gbxVertex.Name = "gbxVertex";
            this.gbxVertex.Size = new System.Drawing.Size(289, 143);
            this.gbxVertex.TabIndex = 17;
            this.gbxVertex.TabStop = false;
            this.gbxVertex.Text = "Section";
            // 
            // txtR
            // 
            this.txtR.Location = new System.Drawing.Point(67, 24);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(100, 25);
            this.txtR.TabIndex = 0;
            // 
            // txtThick
            // 
            this.txtThick.Location = new System.Drawing.Point(67, 55);
            this.txtThick.Name = "txtThick";
            this.txtThick.Size = new System.Drawing.Size(100, 25);
            this.txtThick.TabIndex = 13;
            this.txtThick.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "R";
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(67, 96);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 2;
            this.btnDraw.Text = "Draw";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.BtnDraw_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "厚";
            // 
            // btnExportXml
            // 
            this.btnExportXml.Location = new System.Drawing.Point(16, 143);
            this.btnExportXml.Name = "btnExportXml";
            this.btnExportXml.Size = new System.Drawing.Size(75, 23);
            this.btnExportXml.TabIndex = 11;
            this.btnExportXml.Text = "Export";
            this.btnExportXml.UseVisualStyleBackColor = true;
            this.btnExportXml.Click += new System.EventHandler(this.BtnExportXml_Click);
            // 
            // gbxBending
            // 
            this.gbxBending.AutoSize = true;
            this.gbxBending.Controls.Add(this.txtAngle);
            this.gbxBending.Controls.Add(this.txtRadius);
            this.gbxBending.Controls.Add(this.txtLength);
            this.gbxBending.Controls.Add(this.btnBendAdd);
            this.gbxBending.Controls.Add(this.label1);
            this.gbxBending.Controls.Add(this.label2);
            this.gbxBending.Controls.Add(this.label3);
            this.gbxBending.Location = new System.Drawing.Point(16, 172);
            this.gbxBending.Name = "gbxBending";
            this.gbxBending.Size = new System.Drawing.Size(289, 135);
            this.gbxBending.TabIndex = 18;
            this.gbxBending.TabStop = false;
            this.gbxBending.Text = "Bending";
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(85, 24);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 25);
            this.txtAngle.TabIndex = 3;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(85, 55);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(100, 25);
            this.txtRadius.TabIndex = 4;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(85, 86);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 25);
            this.txtLength.TabIndex = 5;
            // 
            // btnBendAdd
            // 
            this.btnBendAdd.Location = new System.Drawing.Point(201, 37);
            this.btnBendAdd.Name = "btnBendAdd";
            this.btnBendAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBendAdd.TabIndex = 6;
            this.btnBendAdd.Text = "Add";
            this.btnBendAdd.UseVisualStyleBackColor = true;
            this.btnBendAdd.Click += new System.EventHandler(this.BtnBendAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "弯曲(C)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "模具半径R";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "送料(Y)";
            // 
            // btnReadXml2
            // 
            this.btnReadXml2.Location = new System.Drawing.Point(108, 143);
            this.btnReadXml2.Name = "btnReadXml2";
            this.btnReadXml2.Size = new System.Drawing.Size(75, 23);
            this.btnReadXml2.TabIndex = 12;
            this.btnReadXml2.Text = "Import";
            this.btnReadXml2.UseVisualStyleBackColor = true;
            this.btnReadXml2.Click += new System.EventHandler(this.BtnReadXml_Click);
            // 
            // btnUnfold
            // 
            this.btnUnfold.Location = new System.Drawing.Point(126, 313);
            this.btnUnfold.Name = "btnUnfold";
            this.btnUnfold.Size = new System.Drawing.Size(75, 23);
            this.btnUnfold.TabIndex = 13;
            this.btnUnfold.Text = "Unfold";
            this.btnUnfold.UseVisualStyleBackColor = true;
            // 
            // dgvVertex
            // 
            this.dgvVertex.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvVertex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVertex.Location = new System.Drawing.Point(591, 3);
            this.dgvVertex.Name = "dgvVertex";
            this.dgvVertex.RowHeadersWidth = 51;
            this.dgvVertex.RowTemplate.Height = 27;
            this.dgvVertex.Size = new System.Drawing.Size(260, 333);
            this.dgvVertex.TabIndex = 16;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(207, 313);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(45, 313);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(75, 23);
            this.btnLast.TabIndex = 15;
            this.btnLast.Text = "<";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // dgvBending
            // 
            this.dgvBending.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvBending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBending.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBending.Location = new System.Drawing.Point(0, 0);
            this.dgvBending.Name = "dgvBending";
            this.dgvBending.RowHeadersWidth = 51;
            this.dgvBending.RowTemplate.Height = 27;
            this.dgvBending.Size = new System.Drawing.Size(854, 350);
            this.dgvBending.TabIndex = 19;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 766);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.gbxVertex.ResumeLayout(false);
            this.gbxVertex.PerformLayout();
            this.gbxBending.ResumeLayout(false);
            this.gbxBending.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVertex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton importBtn;
        private System.Windows.Forms.ToolStripButton moveBtn;
        private System.Windows.Forms.ToolStripButton clearBtn;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton moveNodeBtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem singlePickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multiPickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hitTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton mouseBtn;
        private System.Windows.Forms.ToolStripButton sectionBtn;
        private System.Windows.Forms.ToolStripButton transOnSelectBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBendAdd;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Button btnReadXml2;
        private System.Windows.Forms.Button btnExportXml;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnUnfold;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvVertex;
        private System.Windows.Forms.GroupBox gbxBending;
        private System.Windows.Forms.GroupBox gbxVertex;
        private System.Windows.Forms.DataGridView dgvBending;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnReorder;
        private System.Windows.Forms.TextBox txtThick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Label label7;
    }
}