using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Syroot.Windows.IO;
using System.Configuration;
using System.IO;

namespace Notes
{
    public partial class NotebookForm : Form
    {
        public string _filename = "";
        public string _folder = "";
        public bool _isSaved = false;
        public bool _isImgSaved = false;
        public List<string> _URLIMGs = new List<string>();
        public List<string> _URLSavedImgs = new List<string>();
        public NotebookForm(string folder = "", string fileName = "") //Modificar para que folder sea obligatorio traerlo desde el form principal
        {
            InitializeComponent();
            _folder = folder;
            if (fileName != "")
            {
                LoadTxt(fileName);
                SearchImagesInFolder();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNote.Text))
                Save();
            else
                MessageBox.Show("Introduzca al menos un caracter válido para guardar la nota", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void btnAddImg_Click(object sender, EventArgs e)
        {
            ImageAdd();
        }
        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved && !txtNote.Text.IsNullOrEmpty())
            {
                DialogResult guardar = MessageBox.Show("Tiene cambios sin guardar \n ¿Desea guardarlos?", "Atención", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (guardar == DialogResult.Yes)
                {
                    if (!Save())
                        e.Cancel = true;
                }
                else if (guardar == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }
        private void btnImgForm_Click(object sender, EventArgs e)
        {
            OpenImagesForm();
        }

        private bool Save()
        {
            if (!Path.Exists(_folder)) //Si no existe la carpeta destino predeterminada, la crea
                Directory.CreateDirectory(_folder);
            if (_filename == "") //Si el archivo es nuevo el usuario elige donde guardarlo y que nombre darle, con opciones predeterminadas
            {
                string Fecha = DateTime.Now.ToString("yyyyMMddHHmmss");
                SaveFileDialog SFD = new SaveFileDialog();
                SFD.RestoreDirectory = true;
                SFD.InitialDirectory = _folder;
                SFD.FileName = "Note_" + Fecha;
                SFD.Filter = "Text Files|*.txt";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    _filename = SFD.FileName;
                    _folder = SFD.FileName.Substring(0, SFD.FileName.Length - Path.GetFileName(SFD.FileName).Length);
                }
                else
                    return false;
                File.WriteAllText(Path.Combine(_folder, _filename), txtNote.Text);
            }
            else
                File.WriteAllText(Path.Combine(_folder, _filename) + ".txt", txtNote.Text);

            MessageBox.Show("Se guardó correctamente la nota en " + _folder, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _isSaved = true;
            if (!_URLIMGs.IsNullOrEmpty())
            {
                string path = Path.Combine(_folder, Path.GetFileNameWithoutExtension(_filename)) + @"\";
                Directory.CreateDirectory(path);
                for (int i = 0; i < _URLIMGs.Count; i++)
                {
                    if (!_URLIMGs[i].Contains("ImgNote"))
                    {
                        File.Copy(_URLIMGs[i], path + "ImgNote" + (i + 1) + Path.GetExtension(_URLIMGs[i]));
                        _URLSavedImgs.Add(path + "ImgNote" + (i + 1) + Path.GetExtension(_URLIMGs[i]));
                    }
                }
                MessageBox.Show("Se guardaron correctamente las imágenes adjuntas en " + path, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isImgSaved = true;
            }
            return _isSaved;
        }

        private void ImageAdd()
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Imagenes|*.jpg;*.jpeg;*.jpe;*.png;*.gif";
            OFD.InitialDirectory = KnownFolders.Pictures.Path;
            OFD.Multiselect = true;
            if (OFD.ShowDialog() == DialogResult.OK)
            {
                foreach (string img in OFD.FileNames)
                    _URLIMGs.Add(img);
            }
        }

        private void OpenImagesForm()
        {
            if (_URLSavedImgs.Count == 0 && _URLIMGs.Count == 0)
            {
                MessageBox.Show("No existen imágenes adjuntas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var check = CheckImages();
                var form = new ImagesForm(check ? _URLSavedImgs : _URLIMGs);
                form.StartPosition = FormStartPosition.CenterScreen;
                form.ShowDialog();
            }
        }

        private bool CheckImages()
        {
            if(_URLSavedImgs.Count != _URLIMGs.Count)
                return false;
            else
            {
                foreach(var img in _URLIMGs)
                {
                    if (!_URLSavedImgs.Contains(img))
                        return false;
                }
                return true;
            }
        }

        private void SearchImagesInFolder()
        {
            string path = Path.Combine(_folder, _filename);
            if (!Path.Exists(path))
                return;
            DirectoryInfo DI = new DirectoryInfo(path);
            FileInfo[] files = DI.GetFiles();
            foreach (FileInfo file in files)
                _URLSavedImgs.Add(file.FullName);
            _URLIMGs.AddRange(_URLSavedImgs);
        }

        private void LoadTxt(string filename)
        {
            DirectoryInfo DI = new DirectoryInfo(_folder);
            FileInfo[] files = DI.GetFiles();

            foreach(FileInfo file in files)
            {
                if(Path.GetFileNameWithoutExtension(file.Name) == filename)
                    txtNote.Text = File.ReadAllText(file.FullName);
            }
            _filename = filename;
            _isSaved = true;
        }
    }
}
