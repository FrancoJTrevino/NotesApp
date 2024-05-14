namespace Notes
{
    partial class NotebookForm
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
            txtNote = new TextBox();
            btnSave = new Button();
            btnImgForm = new Button();
            btnAddImg = new Button();
            SuspendLayout();
            // 
            // txtNote
            // 
            txtNote.Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNote.Location = new Point(12, 12);
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.Size = new Size(456, 705);
            txtNote.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Verdana", 12F);
            btnSave.Location = new Point(474, 12);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(166, 46);
            btnSave.TabIndex = 1;
            btnSave.Text = "Guardar Nota";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnImgForm
            // 
            btnImgForm.Font = new Font("Verdana", 11F);
            btnImgForm.Location = new Point(474, 671);
            btnImgForm.Name = "btnImgForm";
            btnImgForm.Size = new Size(166, 46);
            btnImgForm.TabIndex = 2;
            btnImgForm.Text = "Ver Imágenes Adjuntas";
            btnImgForm.UseVisualStyleBackColor = true;
            btnImgForm.Click += btnImgForm_Click;
            // 
            // btnAddImg
            // 
            btnAddImg.Font = new Font("Verdana", 12F);
            btnAddImg.Location = new Point(474, 619);
            btnAddImg.Name = "btnAddImg";
            btnAddImg.Size = new Size(166, 46);
            btnAddImg.TabIndex = 3;
            btnAddImg.Text = "Agregar Imagen";
            btnAddImg.UseVisualStyleBackColor = true;
            btnAddImg.Click += btnAddImg_Click;
            // 
            // NotebookForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 729);
            Controls.Add(btnAddImg);
            Controls.Add(btnImgForm);
            Controls.Add(btnSave);
            Controls.Add(txtNote);
            Name = "NotebookForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notebook";
            FormClosing += Notebook_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNote;
        private Button btnSave;
        private Button btnImgForm;
        private Button btnAddImg;
    }
}
