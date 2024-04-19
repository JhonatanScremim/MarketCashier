namespace MarketCashier.App
{
    partial class FormMain
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
            TxtBoxBarCode = new TextBox();
            RichTxtBoxProducts = new RichTextBox();
            BtAddProduct = new Button();
            SuspendLayout();
            // 
            // TxtBoxBarCode
            // 
            TxtBoxBarCode.Location = new Point(50, 82);
            TxtBoxBarCode.Name = "TxtBoxBarCode";
            TxtBoxBarCode.Size = new Size(339, 23);
            TxtBoxBarCode.TabIndex = 0;
            // 
            // RichTxtBoxProducts
            // 
            RichTxtBoxProducts.Location = new Point(50, 125);
            RichTxtBoxProducts.Name = "RichTxtBoxProducts";
            RichTxtBoxProducts.Size = new Size(371, 281);
            RichTxtBoxProducts.TabIndex = 1;
            RichTxtBoxProducts.Text = "";
            // 
            // BtAddProduct
            // 
            BtAddProduct.Location = new Point(395, 82);
            BtAddProduct.Name = "BtAddProduct";
            BtAddProduct.Size = new Size(42, 23);
            BtAddProduct.TabIndex = 2;
            BtAddProduct.Text = "->";
            BtAddProduct.UseVisualStyleBackColor = true;
            BtAddProduct.Click += BtAddProduct_Click;
            // 
            // FormMain
            // 
            AcceptButton = BtAddProduct;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BtAddProduct);
            Controls.Add(RichTxtBoxProducts);
            Controls.Add(TxtBoxBarCode);
            Name = "FormMain";
            Text = "Caixa";
            Load += FormMain_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtBoxBarCode;
        private RichTextBox RichTxtBoxProducts;
        private Button BtAddProduct;
    }
}
