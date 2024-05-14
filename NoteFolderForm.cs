using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class NoteFolderForm : Form
    {
        string defaultPath = "";
        public NoteFolderForm()
        {
            InitializeComponent();
        }
        private void NoteFolderForm_Load(object sender, EventArgs e)
        {
            defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "NotesApp");
            LoadNoteList();
        }
        private void btnDefaultFolder_Click(object sender, EventArgs e)
        {
            ChangeFolder();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewNote();
        }
        private void btnMod_Click(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una nota a modificar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvNotes.SelectedItems.Count > 1)
            {
                MessageBox.Show("Solo puede modificar una nota a la vez", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ModNote();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una nota a eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Desea eliminar " + lvNotes.SelectedItems.Count + " nota/s?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                DelNote();
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            if (lvNotes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Seleccione al menos una nota para ver las imágenes adjuntas", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvNotes.SelectedItems.Count > 1)
            {
                MessageBox.Show("Solo puede ver las imágenes adjuntas de una nota a la vez", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OpenImagesForm();
        }

        

        private void LoadNoteList()
        {
            if (!Path.Exists(defaultPath)) //si no existe el directorio por ser la primera vez en abrir el programa/cambiar de carpeta, lo crea
                Directory.CreateDirectory(defaultPath);
            DirectoryInfo DI = new DirectoryInfo(defaultPath);
            FileInfo[] Files = DI.GetFiles();
            List<string[]> fileData = new List<string[]>();
            lvNotes.Items.Clear();
            if (Files.Length <= 0) //si no hay archivos en la carpeta, se vuelve
                return;
            foreach (FileInfo file in Files)
                fileData.Add([file.CreationTime.ToString(), file.LastWriteTime.ToString(), Path.GetFileNameWithoutExtension(file.Name)]);
            for (int i = 0; i < Files.Length; i++)
                lvNotes.Items.Add(fileData[i][2]).SubItems.AddRange(fileData[i]);
        }
        private void ChangeFolder()
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                defaultPath = Path.Combine(fbd.SelectedPath, "NotesApp");
        }
        private void NewNote()
        {
            var NF = new NotebookForm(folder: defaultPath);
            NF.ShowDialog();
            if (NF._isSaved)
                LoadNoteList();
        }
        private void ModNote()
        {
            var filename = lvNotes.SelectedItems[0].Text;
            var NF = new NotebookForm(defaultPath, filename);
            NF.ShowDialog();
            if (NF._isSaved)
                LoadNoteList();
        }
        private void DelNote()
        {
            List<string> filenames = new();
            for (int i = 0; i < lvNotes.SelectedItems.Count; i++)
                filenames.Add(lvNotes.SelectedItems[i].Text);
            foreach (string filename in filenames)
            {
                if (Directory.Exists(Path.Combine(defaultPath, filename)))
                    Directory.Delete(Path.Combine(defaultPath, filename), true);
                string file = Path.Combine(defaultPath, filename) + ".txt";
                if (File.Exists(file))
                    File.Delete(file);
            }
            LoadNoteList();
        }
        private void OpenImagesForm()
        {
            var pathImages = Path.Combine(defaultPath, lvNotes.SelectedItems[0].Text);
            List<string> URLImgs = new();
            if (!Path.Exists(pathImages))       //Si no existe una carpeta del archivo para las imágenes, vuelve
            {
                MessageBox.Show("Esta nota no tiene imagenes adjuntas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var DI = new DirectoryInfo(pathImages);
            FileInfo[] Files = DI.GetFiles();
            if (Files.Length <= 0)              //Si no tiene archivos guardados, vuelve
            {
                MessageBox.Show("Esta nota no tiene imagenes adjuntas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            foreach (FileInfo file in Files)
                URLImgs.Add(file.FullName);
            var form = new ImagesForm(URLImgs);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog();
        }
    }
}
