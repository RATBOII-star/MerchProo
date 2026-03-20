namespace ITelectFinal
{
    partial class OrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblProductId = new Label();
            lblQuantity = new Label();
            lblCustomerId = new Label();
            lblUnitPrice = new Label();
            lblCustomerInfo = new Label();
            lblCustomerPaidInfo = new Label();
            cboProductMenu = new ComboBox();
            txtProductId = new TextBox();
            txtQuantity = new TextBox();
            txtCustomerId = new TextBox();
            txtUnitPrice = new TextBox();
            btnCreateOrder = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Order Form";
            // 
            // lblProductId
            // 
            lblProductId.AutoSize = true;
            lblProductId.Location = new Point(28, 78);
            lblProductId.Name = "lblProductId";
            lblProductId.Size = new Size(76, 20);
            lblProductId.TabIndex = 1;
            lblProductId.Text = "Product Menu";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(28, 144);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(65, 20);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity";
            // 
            // lblCustomerId
            // 
            lblCustomerId.AutoSize = true;
            lblCustomerId.Location = new Point(28, 210);
            lblCustomerId.Name = "lblCustomerId";
            lblCustomerId.Size = new Size(88, 20);
            lblCustomerId.TabIndex = 3;
            lblCustomerId.Text = "Customer Id";
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Location = new Point(28, 276);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(67, 20);
            lblUnitPrice.TabIndex = 4;
            lblUnitPrice.Text = "Unit Price";
            // 
            // cboProductMenu
            // 
            cboProductMenu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProductMenu.Location = new Point(28, 102);
            cboProductMenu.Name = "cboProductMenu";
            cboProductMenu.Size = new Size(320, 27);
            cboProductMenu.TabIndex = 5;
            cboProductMenu.SelectedIndexChanged += cboProductMenu_SelectedIndexChanged;
            // 
            // txtProductId
            // 
            txtProductId.Location = new Point(28, 102);
            txtProductId.Name = "txtProductId";
            txtProductId.Size = new Size(320, 27);
            txtProductId.TabIndex = 5;
            txtProductId.TextChanged += txtProductId_TextChanged;
            txtProductId.Visible = false;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(28, 168);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(320, 27);
            txtQuantity.TabIndex = 6;
            // 
            // txtCustomerId
            // 
            txtCustomerId.Location = new Point(28, 234);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.Size = new Size(320, 27);
            txtCustomerId.TabIndex = 7;
            txtCustomerId.TextChanged += txtCustomerId_TextChanged;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.Location = new Point(28, 300);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.PlaceholderText = "Leave blank to use product base price";
            txtUnitPrice.Size = new Size(320, 27);
            txtUnitPrice.TabIndex = 8;
            // 
            // btnCreateOrder
            // 
            btnCreateOrder.Location = new Point(28, 384);
            btnCreateOrder.Name = "btnCreateOrder";
            btnCreateOrder.Size = new Size(320, 40);
            btnCreateOrder.TabIndex = 9;
            btnCreateOrder.Text = "Create Order";
            btnCreateOrder.UseVisualStyleBackColor = true;
            btnCreateOrder.Click += btnCreateOrder_Click;

            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Location = new Point(28, 332);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(0, 20);
            lblCustomerInfo.TabIndex = 10;
            lblCustomerInfo.Text = "";

            // 
            // lblCustomerPaidInfo
            // 
            lblCustomerPaidInfo.AutoSize = true;
            lblCustomerPaidInfo.Location = new Point(28, 356);
            lblCustomerPaidInfo.Name = "lblCustomerPaidInfo";
            lblCustomerPaidInfo.Size = new Size(0, 20);
            lblCustomerPaidInfo.TabIndex = 11;
            lblCustomerPaidInfo.Text = "";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 530);
            Controls.Add(btnCreateOrder);
            Controls.Add(txtUnitPrice);
            Controls.Add(txtCustomerId);
            Controls.Add(txtQuantity);
            Controls.Add(cboProductMenu);
            Controls.Add(txtProductId);
            Controls.Add(lblCustomerId);
            Controls.Add(lblUnitPrice);
            Controls.Add(lblCustomerInfo);
            Controls.Add(lblCustomerPaidInfo);
            Controls.Add(lblQuantity);
            Controls.Add(lblProductId);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "OrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProductId;
        private Label lblQuantity;
        private Label lblCustomerId;
        private Label lblUnitPrice;
        private Label lblCustomerInfo;
        private Label lblCustomerPaidInfo;
        private ComboBox cboProductMenu;
        private TextBox txtProductId;
        private TextBox txtQuantity;
        private TextBox txtCustomerId;
        private TextBox txtUnitPrice;
        private Button btnCreateOrder;
    }
}

