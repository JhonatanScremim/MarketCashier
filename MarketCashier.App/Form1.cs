using MarketCashier.App.Helpers;

namespace MarketCashier.App
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            await ApiHelper.GetLoginApi();
        }

        private void BtAddProduct_Click(object sender, EventArgs e)
        {

        }
    }
}
