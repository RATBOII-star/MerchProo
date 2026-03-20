namespace ITelectFinal
{
    partial class PaymentForm
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
            lblOrderId = new Label();
            lblAmountPaid = new Label();
            lblMethod = new Label();
            lblCustomerInfo = new Label();
            lblOrderPaidInfo = new Label();
            txtOrderId = new TextBox();
            txtAmountPaid = new TextBox();
            txtMethod = new TextBox();
            btnCheckout = new Button();
            lblReceipt = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Payment";
            // 
            // lblOrderId
            // 
            lblOrderId.AutoSize = true;
            lblOrderId.Location = new Point(24, 74);
            lblOrderId.Name = "lblOrderId";
            lblOrderId.Size = new Size(59, 20);
            lblOrderId.TabIndex = 1;
            lblOrderId.Text = "Order Id";
            // 
            // lblAmountPaid
            // 
            lblAmountPaid.AutoSize = true;
            lblAmountPaid.Location = new Point(24, 134);
            lblAmountPaid.Name = "lblAmountPaid";
            lblAmountPaid.Size = new Size(97, 20);
            lblAmountPaid.TabIndex = 2;
            lblAmountPaid.Text = "Amount Paid";
            // 
            // lblMethod
            // 
            lblMethod.AutoSize = true;
            lblMethod.Location = new Point(24, 194);
            lblMethod.Name = "lblMethod";
            lblMethod.Size = new Size(117, 20);
            lblMethod.TabIndex = 3;
            lblMethod.Text = "Payment Method";
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(24, 98);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(320, 27);
            txtOrderId.TabIndex = 4;
            txtOrderId.TextChanged += txtOrderId_TextChanged;
            // 
            // txtAmountPaid
            // 
            txtAmountPaid.Location = new Point(24, 158);
            txtAmountPaid.Name = "txtAmountPaid";
            txtAmountPaid.Size = new Size(320, 27);
            txtAmountPaid.TabIndex = 5;
            // 
            // txtMethod
            // 
            txtMethod.Location = new Point(24, 218);
            txtMethod.Name = "txtMethod";
            txtMethod.PlaceholderText = "Cash / Card / GCash";
            txtMethod.Size = new Size(320, 27);
            txtMethod.TabIndex = 6;
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(24, 266);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(320, 40);
            btnCheckout.TabIndex = 7;
            btnCheckout.Text = "Record Payment";
            btnCheckout.UseVisualStyleBackColor = true;
            btnCheckout.Click += btnCheckout_Click;
            // 
            // lblReceipt
            // 
            lblReceipt.BorderStyle = BorderStyle.FixedSingle;
            lblReceipt.Location = new Point(24, 360);
            lblReceipt.Name = "lblReceipt";
            lblReceipt.Size = new Size(320, 150);
            lblReceipt.TabIndex = 8;
            lblReceipt.Text = "";

            // 
            // lblCustomerInfo
            // 
            lblCustomerInfo.AutoSize = true;
            lblCustomerInfo.Location = new Point(24, 290);
            lblCustomerInfo.Name = "lblCustomerInfo";
            lblCustomerInfo.Size = new Size(0, 20);
            lblCustomerInfo.TabIndex = 9;
            lblCustomerInfo.Text = "";

            // 
            // lblOrderPaidInfo
            // 
            lblOrderPaidInfo.AutoSize = true;
            lblOrderPaidInfo.Location = new Point(24, 310);
            lblOrderPaidInfo.Name = "lblOrderPaidInfo";
            lblOrderPaidInfo.Size = new Size(0, 20);
            lblOrderPaidInfo.TabIndex = 10;
            lblOrderPaidInfo.Text = "";
            // 
            // PaymentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(372, 520);
            Controls.Add(lblReceipt);
            Controls.Add(btnCheckout);
            Controls.Add(txtMethod);
            Controls.Add(txtAmountPaid);
            Controls.Add(txtOrderId);
            Controls.Add(lblMethod);
            Controls.Add(lblAmountPaid);
            Controls.Add(lblOrderId);
            Controls.Add(lblOrderPaidInfo);
            Controls.Add(lblCustomerInfo);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "PaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payment";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOrderId;
        private Label lblAmountPaid;
        private Label lblMethod;
        private TextBox txtOrderId;
        private TextBox txtAmountPaid;
        private TextBox txtMethod;
        private Button btnCheckout;
        private Label lblReceipt;
        private Label lblCustomerInfo;
        private Label lblOrderPaidInfo;
    }
}

