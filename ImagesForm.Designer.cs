namespace Notes
{
    partial class ImagesForm
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
            pbImage = new PictureBox();
            btnNext = new Button();
            btnBack = new Button();
            lblImageCount = new Label();
            ((System.ComponentModel.ISupportInitialize)pbImage).BeginInit();
            SuspendLayout();
            // 
            // pbImage
            // 
            pbImage.BackgroundImageLayout = ImageLayout.None;
            pbImage.Location = new Point(12, 12);
            pbImage.Name = "pbImage";
            pbImage.Size = new Size(628, 653);
            pbImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbImage.TabIndex = 0;
            pbImage.TabStop = false;
            // 
            // btnNext
            // 
            btnNext.Enabled = false;
            btnNext.Font = new Font("Verdana", 12F);
            btnNext.Location = new Point(474, 671);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(166, 46);
            btnNext.TabIndex = 2;
            btnNext.Text = "Siguiente";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += BackNextClick;
            // 
            // btnBack
            // 
            btnBack.Enabled = false;
            btnBack.Font = new Font("Verdana", 12F);
            btnBack.Location = new Point(12, 671);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(166, 46);
            btnBack.TabIndex = 3;
            btnBack.Text = "Anterior";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += BackNextClick;
            // 
            // lblImageCount
            // 
            lblImageCount.Font = new Font("Verdana", 12F);
            lblImageCount.Location = new Point(184, 671);
            lblImageCount.Name = "lblImageCount";
            lblImageCount.Size = new Size(284, 46);
            lblImageCount.TabIndex = 4;
            lblImageCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImagesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 729);
            Controls.Add(lblImageCount);
            Controls.Add(btnBack);
            Controls.Add(btnNext);
            Controls.Add(pbImage);
            Name = "ImagesForm";
            Text = "Imágenes adjuntas";
            Load += ImagesForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbImage;
        private Button btnNext;
        private Button btnBack;
        private Label lblImageCount;
    }
}