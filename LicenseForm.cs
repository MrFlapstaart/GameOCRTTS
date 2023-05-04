using System;
using System.Windows.Forms;

namespace GameOCRTTS
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            licenseBox.Navigate("https://www.gnu.org/licenses/agpl-3.0.txt");
        }
    }
}
