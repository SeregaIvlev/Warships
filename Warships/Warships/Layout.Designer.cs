namespace Warships
{
    partial class Layout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Layout));
            LoadButton = new Button();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            RotateButton = new Button();
            button9 = new Button();
            select_1_ship = new RadioButton();
            select_2_ship = new RadioButton();
            select_3_ship = new RadioButton();
            select_4_ship = new RadioButton();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // LoadButton
            // 
            LoadButton.Location = new Point(29, 571);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(164, 29);
            LoadButton.TabIndex = 0;
            LoadButton.Text = "Load pattern";
            LoadButton.UseVisualStyleBackColor = true;
            LoadButton.Click += LoadButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(29, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(500, 500);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // button1
            // 
            button1.Location = new Point(199, 571);
            button1.Name = "button1";
            button1.Size = new Size(164, 29);
            button1.TabIndex = 2;
            button1.Text = "Save pattern";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // RotateButton
            // 
            RotateButton.BackgroundImage = (Image)resources.GetObject("RotateButton.BackgroundImage");
            RotateButton.BackgroundImageLayout = ImageLayout.Zoom;
            RotateButton.Location = new Point(558, 29);
            RotateButton.Name = "RotateButton";
            RotateButton.Size = new Size(60, 60);
            RotateButton.TabIndex = 3;
            RotateButton.UseVisualStyleBackColor = true;
            RotateButton.Click += RotateButton_Click;
            // 
            // button9
            // 
            button9.Location = new Point(365, 571);
            button9.Name = "button9";
            button9.Size = new Size(164, 29);
            button9.TabIndex = 11;
            button9.Text = "Im ready!";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // select_1_ship
            // 
            select_1_ship.AutoSize = true;
            select_1_ship.Checked = true;
            select_1_ship.Location = new Point(681, 31);
            select_1_ship.Name = "select_1_ship";
            select_1_ship.Size = new Size(45, 24);
            select_1_ship.TabIndex = 12;
            select_1_ship.TabStop = true;
            select_1_ship.Text = ": 4";
            select_1_ship.UseVisualStyleBackColor = true;
            // 
            // select_2_ship
            // 
            select_2_ship.AutoSize = true;
            select_2_ship.Location = new Point(681, 61);
            select_2_ship.Name = "select_2_ship";
            select_2_ship.Size = new Size(45, 24);
            select_2_ship.TabIndex = 13;
            select_2_ship.Text = ": 3";
            select_2_ship.UseVisualStyleBackColor = true;
            // 
            // select_3_ship
            // 
            select_3_ship.AutoSize = true;
            select_3_ship.Location = new Point(681, 91);
            select_3_ship.Name = "select_3_ship";
            select_3_ship.Size = new Size(45, 24);
            select_3_ship.TabIndex = 14;
            select_3_ship.Text = ": 2";
            select_3_ship.UseVisualStyleBackColor = true;
            // 
            // select_4_ship
            // 
            select_4_ship.AutoSize = true;
            select_4_ship.Location = new Point(681, 121);
            select_4_ship.Name = "select_4_ship";
            select_4_ship.Size = new Size(45, 24);
            select_4_ship.TabIndex = 15;
            select_4_ship.Text = ": 1";
            select_4_ship.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(29, 535);
            button2.Name = "button2";
            button2.Size = new Size(164, 29);
            button2.TabIndex = 16;
            button2.Text = "Load pattern";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Layout
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 621);
            Controls.Add(button2);
            Controls.Add(select_4_ship);
            Controls.Add(select_3_ship);
            Controls.Add(select_2_ship);
            Controls.Add(select_1_ship);
            Controls.Add(button9);
            Controls.Add(RotateButton);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(LoadButton);
            Name = "Layout";
            Text = "Layout";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadButton;
        private PictureBox pictureBox1;
        private Button button1;
        private Button RotateButton;
        private Button button9;
        private RadioButton select_1_ship;
        private RadioButton select_2_ship;
        private RadioButton select_3_ship;
        private RadioButton select_4_ship;
        private Button button2;
    }
}