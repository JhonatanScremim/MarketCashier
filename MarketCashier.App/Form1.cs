using MarketCashier.App.Helpers;
using MarketCashier.App.Models;
using MarketCashier.App.Models.Enums;

namespace MarketCashier.App
{
    public partial class FormMain : Form
    {
        ApiHelper _apiHelper;
        List<Product> basket;
        double basketValue;

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
            richTxtBoxTotalPrice.Clear();
            if (TxtBoxBarCode.Text == "")
            {
                MessageBox.Show("Preecha o campo!");
                return;
            }

            long barCode = Convert.ToInt64(TxtBoxBarCode.Text);
            var product = await _apiHelper.GetProductByBarCode(barCode);
            basket.Add(product);

            string linhaFormatada = $"{product.Id,-5} {$"{product.Name}, {product.Brand}",-15} x1  ----------------------- {product.Price}\n";
            linhaFormatada += new string('-', 60) + "\n";

            RichTxtBoxProducts.AppendText(linhaFormatada);
            basketValue += product.Price;
            richTxtBoxTotalPrice.AppendText($"Valor:\n\n\n" + $"                      R$ {string.Format("{0:F2}", basketValue)}");
            TxtBoxBarCode.Text = "";
        }

        private void BtCheckout_Click(object sender, EventArgs e)
        {
            var paymentTypeIndex = ComboBoxPaymentType.SelectedIndex;
            PaymentType paymentType;

            switch (paymentTypeIndex)
            {
                case 0:
                    paymentType = PaymentType.Debit;
                    break;
                case 1:
                    paymentType = PaymentType.Credit;
                    break;
                default:
                    paymentType = PaymentType.Debit; 
                    break;
            }

            var checkout = new CheckoutItems()
            {
                PaymentType = Enum.GetName(typeof(PaymentType), paymentType) ?? "",
                Products = basket,
                TotalPrice = Math.Round(basketValue, 2)
            };

            var rabbit = new RabbitMQMessageSenderHelper();

            if (rabbit.SendMessage(checkout))
                FinalizePayment();
            else
                MessageBox.Show("Erro, por favor tente mais tarde");
        }

        private void FinalizePayment()
        {
            MessageBox.Show("Sucesso");
            TxtBoxBarCode.Text = "";
            richTxtBoxTotalPrice.Clear();
            RichTxtBoxProducts.Clear();
        }
    }
}
