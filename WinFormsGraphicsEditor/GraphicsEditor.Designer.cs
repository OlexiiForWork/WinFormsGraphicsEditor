namespace WinFormsGraphicsEditor
{
    partial class GraphicsEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsEditor));
            panel1 = new Panel();
            panel2 = new Panel();
            statusStrip1 = new StatusStrip();
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripButton4 = new ToolStripButton();
            menuStrip1 = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            LoadToolStripMenuItem = new ToolStripMenuItem();
            CanselDownToolStripMenuItem = new ToolStripMenuItem();
            CanselUpToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            BackgroundToolStripMenuItem = new ToolStripMenuItem();
            PenColorToolStripMenuItem = new ToolStripMenuItem();
            SizeLineToolStripMenuItem = new ToolStripMenuItem();
            ClearToolStripMenuItem = new ToolStripMenuItem();
            ColorInversionToolStripMenuItem = new ToolStripMenuItem();
            colorDialog1 = new ColorDialog();
            openFileDialog1 = new OpenFileDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(toolStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 422);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(statusStrip1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(30, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(770, 422);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            panel2.MouseDown += panel2_MouseDown;
            panel2.MouseMove += panel2_MouseMove;
            panel2.MouseUp += panel2_MouseUp;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 398);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(770, 24);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            statusStrip1.ClientSizeChanged += statusStrip1_ClientSizeChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Left;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripButton4 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(30, 422);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(27, 24);
            toolStripButton1.Text = "toolStripButton1";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(27, 24);
            toolStripButton2.Text = "toolStripButton2";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton3.Image = (Image)resources.GetObject("toolStripButton3.Image");
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(27, 24);
            toolStripButton3.Text = "toolStripButton3";
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton4.Image = (Image)resources.GetObject("toolStripButton4.Image");
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(27, 24);
            toolStripButton4.Text = "toolStripButton4";
            toolStripButton4.Click += toolStripButton4_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem, CanselDownToolStripMenuItem, CanselUpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SaveToolStripMenuItem, LoadToolStripMenuItem });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(63, 24);
            менюToolStripMenuItem.Text = "меню";
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(266, 26);
            SaveToolStripMenuItem.Text = "Сохранить изображения";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // LoadToolStripMenuItem
            // 
            LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
            LoadToolStripMenuItem.Size = new Size(266, 26);
            LoadToolStripMenuItem.Text = "Загрузить изображение";
            LoadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
            // 
            // CanselDownToolStripMenuItem
            // 
            CanselDownToolStripMenuItem.Name = "CanselDownToolStripMenuItem";
            CanselDownToolStripMenuItem.Size = new Size(141, 24);
            CanselDownToolStripMenuItem.Text = "Отменить(назад)";
            CanselDownToolStripMenuItem.Click += CanselDownToolStripMenuItem_Click;
            // 
            // CanselUpToolStripMenuItem
            // 
            CanselUpToolStripMenuItem.Name = "CanselUpToolStripMenuItem";
            CanselUpToolStripMenuItem.Size = new Size(151, 24);
            CanselUpToolStripMenuItem.Text = "Отменить(вперед)";
            CanselUpToolStripMenuItem.Click += CanselUpToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { BackgroundToolStripMenuItem, PenColorToolStripMenuItem, SizeLineToolStripMenuItem, ClearToolStripMenuItem, ColorInversionToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(230, 124);
            contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;
            // 
            // BackgroundToolStripMenuItem
            // 
            BackgroundToolStripMenuItem.Name = "BackgroundToolStripMenuItem";
            BackgroundToolStripMenuItem.Size = new Size(229, 24);
            BackgroundToolStripMenuItem.Text = "Цвет фона ";
            BackgroundToolStripMenuItem.Click += BackgroundToolStripMenuItem_Click;
            // 
            // PenColorToolStripMenuItem
            // 
            PenColorToolStripMenuItem.Name = "PenColorToolStripMenuItem";
            PenColorToolStripMenuItem.Size = new Size(229, 24);
            PenColorToolStripMenuItem.Text = "Цвет пера";
            PenColorToolStripMenuItem.Click += PenColorToolStripMenuItem_Click;
            // 
            // SizeLineToolStripMenuItem
            // 
            SizeLineToolStripMenuItem.Name = "SizeLineToolStripMenuItem";
            SizeLineToolStripMenuItem.Size = new Size(229, 24);
            SizeLineToolStripMenuItem.Text = "Толщина линии";
            SizeLineToolStripMenuItem.Click += SizeLineToolStripMenuItem_Click;
            // 
            // ClearToolStripMenuItem
            // 
            ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            ClearToolStripMenuItem.Size = new Size(229, 24);
            ClearToolStripMenuItem.Text = "Очистить весь фон";
            ClearToolStripMenuItem.Click += ClearToolStripMenuItem_Click;
            // 
            // ColorInversionToolStripMenuItem
            // 
            ColorInversionToolStripMenuItem.Name = "ColorInversionToolStripMenuItem";
            ColorInversionToolStripMenuItem.Size = new Size(229, 24);
            ColorInversionToolStripMenuItem.Text = "Инвертировать цвета";
            ColorInversionToolStripMenuItem.Click += ColorInversionToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // GraphicsEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "GraphicsEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStrip toolStrip1;
        private Panel panel2;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripButton toolStripButton4;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem BackgroundToolStripMenuItem;
        private ToolStripMenuItem PenColorToolStripMenuItem;
        private ToolStripMenuItem SizeLineToolStripMenuItem;
        private ColorDialog colorDialog1;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem LoadToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem CanselDownToolStripMenuItem;
        private ToolStripMenuItem CanselUpToolStripMenuItem;
        private ToolStripMenuItem ClearToolStripMenuItem;
        private ToolStripMenuItem ColorInversionToolStripMenuItem;
        private StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
    }
}