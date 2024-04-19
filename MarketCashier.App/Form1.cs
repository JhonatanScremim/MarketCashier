using MarketCashier.App.Helpers;
using MarketCashier.App.Models;
using System.Drawing;

namespace MarketCashier.App
{
    public partial class FormMain : Form
    {
        ApiHelper _apiHelper;
        List<Product> basket;

        public FormMain()
        {
            InitializeComponent();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            TxtBoxBarCode.Enabled = false;
            BtAddProduct.Enabled = false;

            basket = new List<Product>();
            try
            {
                _apiHelper = new ApiHelper();
                await _apiHelper.GetLoginApi();

                TxtBoxBarCode.Enabled = true;
                BtAddProduct.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Erro interno no servidor, por favor tente mais tarde");
            }
        }

        private async void BtAddProduct_Click(object sender, EventArgs e)
        {
            if (TxtBoxBarCode.Text == "")
            {
                MessageBox.Show("Preecha o campo, ANIMAL!");
                return;
            }

            long barCode = Convert.ToInt64(TxtBoxBarCode.Text);
            var product = await _apiHelper.GetProductByBarCode(barCode);
            basket.Add(product);

            string linhaFormatada = $"{product.Id, -5} {product.Name, -15} x1  ----------------------- {product.Price}\n";
            linhaFormatada += new string('-', 70) + "\n";

            RichTxtBoxProducts.AppendText(linhaFormatada);            
        }
    }
}
