namespace ITelectFinal
{
    partial class AdminPaymentsForm
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
            dgvPayments = new DataGridView();
            btnRefresh = new Button();
            lblTitle = new Label();
            SuspendLayout();
            // 
            // dgvPayments
            // 
            dgvPayments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayments.Location = new Point(16, 60);
            dgvPayments.Name = "dgvPayments";
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersWidth = 51;
            dgvPayments.RowTemplate.Height = 29;
            dgvPayments.Size = new Size(720, 360);
            dgvPayments.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(640, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(96, 34);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(16, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 37);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Payments";
            // 
            // AdminPaymentsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(760, 440);
            Controls.Add(lblTitle);
            Controls.Add(btnRefresh);
            Controls.Add(dgvPayments);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "AdminPaymentsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin - Payments";
            Load += AdminPaymentsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPayments;
        private Button btnRefresh;
        private Label lblTitle;
    }
}

