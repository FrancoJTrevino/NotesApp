using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notes
{
    public partial class ImagesForm : Form
    {
        List<string> _URLImgs = new List<string>();

        public ImagesForm(List<string> URLImgs)
        {
            InitializeComponent();
            _URLImgs.AddRange(URLImgs);
        }

        private void ImagesForm_Load(object sender, EventArgs e)
        {
            if (_URLImgs.Count > 1)
                btnNext.Enabled = true;
            pbImage.ImageLocation = _URLImgs[0];
            lblImageCount.Text = "1/" + _URLImgs.Count;
        }

        private void BackNextClick(object sender, EventArgs e)
        {
            var btn = (sender as Button).Text;
            var currentImageIndex = _URLImgs.IndexOf(pbImage.ImageLocation);
            if (btn == "Siguiente")
                pbImage.ImageLocation = _URLImgs[currentImageIndex + 1];
            else if (btn == "Anterior")
                pbImage.ImageLocation = _URLImgs[currentImageIndex - 1];
            currentImageIndex = _URLImgs.IndexOf(pbImage.ImageLocation);
            if (currentImageIndex > 0)
                btnBack.Enabled = true;
            else if (currentImageIndex == 0)
                btnBack.Enabled = false;
            if (currentImageIndex + 1 < _URLImgs.Count)
                btnNext.Enabled = true;
            else if (currentImageIndex + 1 == _URLImgs.Count)
                btnNext.Enabled = false;
            lblImageCount.Text = (currentImageIndex + 1) + "/" + _URLImgs.Count;
        }
    }
}
