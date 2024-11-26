namespace RPCNodeChecker
{
    partial class RPCN0deChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPCN0deChecker));
            panel1 = new Panel();
            PLTHeimArenaLBL = new Label();
            label3 = new Label();
            PLTOdinArenaLBL = new Label();
            label2 = new Label();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            APIHeimArenaLBL = new Label();
            label8 = new Label();
            APIOdinArenaLBL = new Label();
            label6 = new Label();
            ArenaCheckerWorker = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(PLTHeimArenaLBL);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(PLTOdinArenaLBL);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(890, 31);
            panel1.TabIndex = 0;
            // 
            // PLTHeimArenaLBL
            // 
            PLTHeimArenaLBL.AutoSize = true;
            PLTHeimArenaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PLTHeimArenaLBL.Location = new Point(494, 9);
            PLTHeimArenaLBL.Name = "PLTHeimArenaLBL";
            PLTHeimArenaLBL.Size = new Size(61, 15);
            PLTHeimArenaLBL.TabIndex = 9;
            PLTHeimArenaLBL.Text = "Unknown";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(344, 9);
            label3.Name = "label3";
            label3.Size = new Size(153, 15);
            label3.TabIndex = 8;
            label3.Text = "PlanetariumArenaHeimdall:";
            // 
            // PLTOdinArenaLBL
            // 
            PLTOdinArenaLBL.AutoSize = true;
            PLTOdinArenaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            PLTOdinArenaLBL.Location = new Point(245, 9);
            PLTOdinArenaLBL.Name = "PLTOdinArenaLBL";
            PLTOdinArenaLBL.Size = new Size(61, 15);
            PLTOdinArenaLBL.TabIndex = 7;
            PLTOdinArenaLBL.Text = "Unknown";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 9);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 3;
            label2.Text = "PlanetariumArenaOdin:";
            // 
            // button1
            // 
            button1.Location = new Point(3, 5);
            button1.Name = "button1";
            button1.Size = new Size(87, 23);
            button1.TabIndex = 2;
            button1.Text = "Reset Config";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Planetarium", "9CAPI" });
            comboBox1.Location = new Point(781, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(106, 23);
            comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(645, 8);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 0;
            label1.Text = "ArenaProviderOverride:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(890, 336);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(APIHeimArenaLBL);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(APIOdinArenaLBL);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(0, 360);
            panel2.Name = "panel2";
            panel2.Size = new Size(890, 30);
            panel2.TabIndex = 2;
            // 
            // APIHeimArenaLBL
            // 
            APIHeimArenaLBL.AutoSize = true;
            APIHeimArenaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            APIHeimArenaLBL.Location = new Point(494, 7);
            APIHeimArenaLBL.Name = "APIHeimArenaLBL";
            APIHeimArenaLBL.Size = new Size(61, 15);
            APIHeimArenaLBL.TabIndex = 10;
            APIHeimArenaLBL.Text = "Unknown";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(376, 7);
            label8.Name = "label8";
            label8.Size = new Size(121, 15);
            label8.TabIndex = 11;
            label8.Text = "9CAPIArenaHeimdall:";
            // 
            // APIOdinArenaLBL
            // 
            APIOdinArenaLBL.AutoSize = true;
            APIOdinArenaLBL.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            APIOdinArenaLBL.Location = new Point(245, 7);
            APIOdinArenaLBL.Name = "APIOdinArenaLBL";
            APIOdinArenaLBL.Size = new Size(61, 15);
            APIOdinArenaLBL.TabIndex = 10;
            APIOdinArenaLBL.Text = "Unknown";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(147, 7);
            label6.Name = "label6";
            label6.Size = new Size(99, 15);
            label6.TabIndex = 10;
            label6.Text = "9CAPIArenaOdin:";
            // 
            // ArenaCheckerWorker
            // 
            ArenaCheckerWorker.DoWork += ArenaCheckerWorker_DoWork;
            // 
            // RPCN0deChecker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(890, 389);
            Controls.Add(panel2);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RPCN0deChecker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RPC N0de Checker";
            WindowState = FormWindowState.Minimized;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private ComboBox comboBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label PLTHeimArenaLBL;
        private Label label3;
        private Label PLTOdinArenaLBL;
        private Panel panel2;
        private Label APIHeimArenaLBL;
        private Label label8;
        private Label APIOdinArenaLBL;
        private Label label6;
        private System.ComponentModel.BackgroundWorker ArenaCheckerWorker;
    }
}
