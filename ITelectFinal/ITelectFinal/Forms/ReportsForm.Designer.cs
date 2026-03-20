namespace ITelectFinal
{
    partial class ReportsForm
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
            btnLoadReport = new Button();
            lblTotalSalesLabel = new Label();
            lblOrdersLabel = new Label();
            lblTotalSales = new Label();
            lblOrders = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(102, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reports";
            // 
            // btnLoadReport
            // 
            btnLoadReport.Location = new Point(24, 76);
            btnLoadReport.Name = "btnLoadReport";
            btnLoadReport.Size = new Size(240, 40);
            btnLoadReport.TabIndex = 1;
            btnLoadReport.Text = "Load Sales Report";
            btnLoadReport.UseVisualStyleBackColor = true;
            btnLoadReport.Click += btnLoadReport_Click;
            // 
            // lblTotalSalesLabel
            // 
            lblTotalSalesLabel.AutoSize = true;
            lblTotalSalesLabel.Location = new Point(24, 142);
            lblTotalSalesLabel.Name = "lblTotalSalesLabel";
            lblTotalSalesLabel.Size = new Size(79, 20);
            lblTotalSalesLabel.TabIndex = 2;
            lblTotalSalesLabel.Text = "Total Sales:";
            // 
            // lblOrdersLabel
            // 
            lblOrdersLabel.AutoSize = true;
            lblOrdersLabel.Location = new Point(24, 178);
            lblOrdersLabel.Name = "lblOrdersLabel";
            lblOrdersLabel.Size = new Size(93, 20);
            lblOrdersLabel.TabIndex = 3;
            lblOrdersLabel.Text = "Total Orders:";
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Location = new Point(140, 142);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(17, 20);
            lblTotalSales.TabIndex = 4;
            lblTotalSales.Text = "0";
            // 
            // lblOrders
            // 
            lblOrders.AutoSize = true;
            lblOrders.Location = new Point(140, 178);
            lblOrders.Name = "lblOrders";
            lblOrders.Size = new Size(17, 20);
            lblOrders.TabIndex = 5;
            lblOrders.Text = "0";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 240);
            Controls.Add(lblOrders);
            Controls.Add(lblTotalSales);
            Controls.Add(lblOrdersLabel);
            Controls.Add(lblTotalSalesLabel);
            Controls.Add(btnLoadReport);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnLoadReport;
        private Label lblTotalSalesLabel;
        private Label lblOrdersLabel;
        private Label lblTotalSales;
        private Label lblOrders;
    }
}

