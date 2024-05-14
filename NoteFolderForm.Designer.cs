namespace Notes
{
    partial class NoteFolderForm
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
            btnAdd = new Button();
            lvNotes = new ListView();
            FileName = new ColumnHeader();
            DateAdd = new ColumnHeader();
            DateMod = new ColumnHeader();
            btnMod = new Button();
            btnDel = new Button();
            btnDefaultFolder = new Button();
            btnImg = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Verdana", 12F);
            btnAdd.Location = new Point(474, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(166, 46);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Crear Nueva Nota";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lvNotes
            // 
            lvNotes.Columns.AddRange(new ColumnHeader[] { FileName, DateAdd, DateMod });
            lvNotes.Location = new Point(12, 12);
            lvNotes.Name = "lvNotes";
            lvNotes.Size = new Size(456, 705);
            lvNotes.TabIndex = 7;
            lvNotes.UseCompatibleStateImageBehavior = false;
            lvNotes.View = View.Details;
            // 
            // FileName
            // 
            FileName.Tag = "FileName";
            FileName.Text = "Archivo";
            FileName.Width = 195;
            // 
            // DateAdd
            // 
            DateAdd.Tag = "DateAdd";
            DateAdd.Text = "Fecha Creación";
            DateAdd.TextAlign = HorizontalAlignment.Center;
            DateAdd.Width = 120;
            // 
            // DateMod
            // 
            DateMod.Tag = "DateMod";
            DateMod.Text = "Fecha Modificación";
            DateMod.TextAlign = HorizontalAlignment.Center;
            DateMod.Width = 120;
            // 
            // btnMod
            // 
            btnMod.Font = new Font("Verdana", 12F);
            btnMod.Location = new Point(474, 64);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(166, 46);
            btnMod.TabIndex = 8;
            btnMod.Text = "Modificar Nota";
            btnMod.UseVisualStyleBackColor = true;
            btnMod.Click += btnMod_Click;
            // 
            // btnDel
            // 
            btnDel.Font = new Font("Verdana", 12F);
            btnDel.Location = new Point(474, 116);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(166, 46);
            btnDel.TabIndex = 9;
            btnDel.Text = "Eliminar Nota/s";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnDefaultFolder
            // 
            btnDefaultFolder.Font = new Font("Verdana", 11F);
            btnDefaultFolder.Location = new Point(474, 671);
            btnDefaultFolder.Name = "btnDefaultFolder";
            btnDefaultFolder.Size = new Size(166, 46);
            btnDefaultFolder.TabIndex = 10;
            btnDefaultFolder.Text = "Modificar Carpeta de Notas";
            btnDefaultFolder.UseVisualStyleBackColor = true;
            btnDefaultFolder.Click += btnDefaultFolder_Click;
            // 
            // btnImg
            // 
            btnImg.Font = new Font("Verdana", 11F);
            btnImg.Location = new Point(474, 168);
            btnImg.Name = "btnImg";
            btnImg.Size = new Size(166, 46);
            btnImg.TabIndex = 13;
            btnImg.Text = "Ver Imágenes Adjuntas";
            btnImg.UseVisualStyleBackColor = true;
            btnImg.Click += btnImg_Click;
            // 
            // NoteFolderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(652, 729);
            Controls.Add(btnImg);
            Controls.Add(btnDefaultFolder);
            Controls.Add(btnDel);
            Controls.Add(btnMod);
            Controls.Add(lvNotes);
            Controls.Add(btnAdd);
            Name = "NoteFolderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Carpeta de Notas";
            Load += NoteFolderForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdd;
        private ListView lvNotes;
        private Button btnMod;
        private Button btnDel;
        private Button btnDefaultFolder;
        private Button btnImg;
        private ColumnHeader FileName;
        private ColumnHeader DateAdd;
        private ColumnHeader DateMod;
    }
}