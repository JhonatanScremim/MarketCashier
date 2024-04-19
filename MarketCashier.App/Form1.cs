using MarketCashier.App.Helpers;

namespace MarketCashier.App
{
    public partial class FormMain : Form
    {
        ApiHelper _apiHelper; 

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            _apiHelper = new ApiHelper();
            await _apiHelper.GetLoginApi();
        }

        private async void BtAddProduct_Click(object sender, EventArgs e)
        {
            if(TxtBoxBarCode.Text == "")
            {
                MessageBox.Show("Preecha o campo, ANIMAL!");
                return;
            }

            long barCode = Convert.ToInt64(TxtBoxBarCode.Text);
            var product = await _apiHelper.GetProductByBarCode(barCode);
            RichTxtBoxProducts.AppendText(product.Name + Environment.NewLine);
        }
    }
}
