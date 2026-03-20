namespace ITelectFinal
{
    partial class HomeForm
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
            lblCurrentUser = new Label();
            btnCustomers = new Button();
            btnOrders = new Button();
            btnPayments = new Button();
            btnReports = new Button();
            btnWorkflow = new Button();
            tblBottom = new TableLayoutPanel();
            pnlReports = new Panel();
            lblReportsHeader = new Label();
            lblTotalSales = new Label();
            lblTotalOrders = new Label();
            lblPaidOrders = new Label();
            lblUnpaidOrders = new Label();
            lvOrdersSummary = new ListView();
            pnlWorkflow = new Panel();
            tblWorkflow = new TableLayoutPanel();
            lblPending = new Label();
            lblInProgress = new Label();
            lblCompleted = new Label();
            lstPendingTasks = new ListBox();
            lstInProgressTasks = new ListBox();
            lstCompletedTasks = new ListBox();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 28);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(136, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Home (Blank)";
            // 
            // lblCurrentUser
            // 
            lblCurrentUser.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentUser.AutoSize = true;
            lblCurrentUser.Location = new Point(500, 38);
            lblCurrentUser.Name = "lblCurrentUser";
            lblCurrentUser.Size = new Size(0, 20);
            lblCurrentUser.TabIndex = 6;
            // 
            // btnCustomers
            // 
            btnCustomers.Location = new Point(30, 90);
            btnCustomers.Name = "btnCustomers";
            btnCustomers.Size = new Size(220, 40);
            btnCustomers.TabIndex = 1;
            btnCustomers.Text = "Customers";
            btnCustomers.UseVisualStyleBackColor = true;
            btnCustomers.Click += btnCustomers_Click;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(30, 142);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(220, 40);
            btnOrders.TabIndex = 2;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += btnOrders_Click;
            // 
            // btnPayments
            // 
            btnPayments.Location = new Point(30, 194);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(220, 40);
            btnPayments.TabIndex = 3;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = true;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(30, 246);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(220, 40);
            btnReports.TabIndex = 4;
            btnReports.Text = "Reports";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // btnWorkflow
            // 
            btnWorkflow.Location = new Point(30, 298);
            btnWorkflow.Name = "btnWorkflow";
            btnWorkflow.Size = new Size(220, 40);
            btnWorkflow.TabIndex = 5;
            btnWorkflow.Text = "Workflow Tasks";
            btnWorkflow.UseVisualStyleBackColor = true;
            btnWorkflow.Click += btnWorkflow_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            btnCustomers.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnOrders.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnPayments.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnReports.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnWorkflow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCustomers.Width = ClientSize.Width - 60;
            btnOrders.Width = ClientSize.Width - 60;
            btnPayments.Width = ClientSize.Width - 60;
            btnReports.Width = ClientSize.Width - 60;
            btnWorkflow.Width = ClientSize.Width - 60;

            // 
            // tblBottom
            // 
            tblBottom.ColumnCount = 3;
            tblBottom.Dock = DockStyle.Bottom;
            // Give enough vertical space so the reports panel can show the chart.
            tblBottom.Height = 520;
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tblBottom.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tblBottom.RowCount = 2;
            // More space for reports so the chart is not squeezed.
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tblBottom.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            // 
            // pnlReports
            // 
            pnlReports.Dock = DockStyle.Fill;
            pnlReports.BorderStyle = BorderStyle.FixedSingle;
            // 
            // lblReportsHeader
            // 
            lblReportsHeader.AutoSize = true;
            lblReportsHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblReportsHeader.Location = new Point(8, 8);
            lblReportsHeader.Name = "lblReportsHeader";
            lblReportsHeader.Size = new Size(68, 20);
            lblReportsHeader.TabIndex = 0;
            lblReportsHeader.Text = "Reports";
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Location = new Point(8, 34);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(62, 15);
            lblTotalSales.TabIndex = 1;
            lblTotalSales.Text = "TotalSales: 0";
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Location = new Point(8, 52);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(66, 15);
            lblTotalOrders.TabIndex = 2;
            lblTotalOrders.Text = "TotalOrders: 0";
            // 
            // lblPaidOrders
            // 
            lblPaidOrders.AutoSize = true;
            lblPaidOrders.Location = new Point(8, 70);
            lblPaidOrders.Name = "lblPaidOrders";
            lblPaidOrders.Size = new Size(63, 15);
            lblPaidOrders.TabIndex = 3;
            lblPaidOrders.Text = "Paid: 0";
            // 
            // lblUnpaidOrders
            // 
            lblUnpaidOrders.AutoSize = true;
            lblUnpaidOrders.Location = new Point(8, 88);
            lblUnpaidOrders.Name = "lblUnpaidOrders";
            lblUnpaidOrders.Size = new Size(78, 15);
            lblUnpaidOrders.TabIndex = 4;
            lblUnpaidOrders.Text = "Not paid: 0";
            // 
            // lvOrdersSummary
            // 
            // Important: do NOT anchor Bottom; otherwise it will resize and cover the chart at runtime.
            lvOrdersSummary.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvOrdersSummary.Location = new Point(8, 108);
            lvOrdersSummary.Name = "lvOrdersSummary";
            lvOrdersSummary.Size = new Size(374, 86);
            lvOrdersSummary.TabIndex = 5;
            lvOrdersSummary.UseCompatibleStateImageBehavior = false;
            lvOrdersSummary.View = View.Details;
            lvOrdersSummary.Columns.Add("OrderId", 60);
            lvOrdersSummary.Columns.Add("Customer", 200);
            lvOrdersSummary.Columns.Add("TotalAmount", 100);
            lvOrdersSummary.Columns.Add("Status", 90);

            pnlReports.Controls.Add(lblReportsHeader);
            pnlReports.Controls.Add(lblTotalSales);
            pnlReports.Controls.Add(lblTotalOrders);
            pnlReports.Controls.Add(lblPaidOrders);
            pnlReports.Controls.Add(lblUnpaidOrders);
            pnlReports.Controls.Add(lvOrdersSummary);

            // 
            // pnlWorkflow
            // 
            pnlWorkflow.Dock = DockStyle.Fill;
            pnlWorkflow.BorderStyle = BorderStyle.FixedSingle;
            // 
            // tblWorkflow
            // 
            tblWorkflow.ColumnCount = 3;
            tblWorkflow.Dock = DockStyle.Fill;
            tblWorkflow.RowCount = 1;
            tblWorkflow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblWorkflow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblWorkflow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tblWorkflow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Pending column
            var pnlPending = new Panel { Dock = DockStyle.Fill };
            lblPending.AutoSize = false;
            lblPending.Dock = DockStyle.Top;
            lblPending.Height = 22;
            lblPending.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPending.Location = new Point(8, 8);
            lblPending.Text = "Not paid";
            lblPending.Name = "lblPending";
            lstPendingTasks.Dock = DockStyle.Fill;

            pnlPending.Controls.Add(lstPendingTasks);
            pnlPending.Controls.Add(lblPending);

            // InProgress column
            var pnlInProgress = new Panel { Dock = DockStyle.Fill };
            lblInProgress.AutoSize = false;
            lblInProgress.Dock = DockStyle.Top;
            lblInProgress.Height = 22;
            lblInProgress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblInProgress.Location = new Point(8, 8);
            lblInProgress.Text = "Working";
            lblInProgress.Name = "lblInProgress";
            lstInProgressTasks.Dock = DockStyle.Fill;

            pnlInProgress.Controls.Add(lstInProgressTasks);
            pnlInProgress.Controls.Add(lblInProgress);

            // Completed column
            var pnlCompleted = new Panel { Dock = DockStyle.Fill };
            lblCompleted.AutoSize = false;
            lblCompleted.Dock = DockStyle.Top;
            lblCompleted.Height = 22;
            lblCompleted.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCompleted.Location = new Point(8, 8);
            lblCompleted.Text = "Done";
            lblCompleted.Name = "lblCompleted";
            lstCompletedTasks.Dock = DockStyle.Fill;

            pnlCompleted.Controls.Add(lstCompletedTasks);
            pnlCompleted.Controls.Add(lblCompleted);

            tblWorkflow.Controls.Add(pnlPending, 0, 0);
            tblWorkflow.Controls.Add(pnlInProgress, 1, 0);
            tblWorkflow.Controls.Add(pnlCompleted, 2, 0);

            pnlWorkflow.Controls.Add(tblWorkflow);

            tblBottom.Controls.Add(pnlReports, 1, 0);
            tblBottom.Controls.Add(pnlWorkflow, 1, 1);

            Controls.Add(btnWorkflow);
            Controls.Add(btnReports);
            Controls.Add(btnPayments);
            Controls.Add(btnOrders);
            Controls.Add(btnCustomers);
            Controls.Add(lblCurrentUser);
            Controls.Add(lblTitle);
            Controls.Add(tblBottom);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCurrentUser;
        private Button btnCustomers;
        private Button btnOrders;
        private Button btnPayments;
        private Button btnReports;
        private Button btnWorkflow;

        private TableLayoutPanel tblBottom;
        private Panel pnlReports;
        private Label lblReportsHeader;
        private Label lblTotalSales;
        private Label lblTotalOrders;
        private Label lblPaidOrders;
        private Label lblUnpaidOrders;
        private ListView lvOrdersSummary;

        private Panel pnlWorkflow;
        private TableLayoutPanel tblWorkflow;
        private Label lblPending;
        private Label lblInProgress;
        private Label lblCompleted;
        private ListBox lstPendingTasks;
        private ListBox lstInProgressTasks;
        private ListBox lstCompletedTasks;
    }
}

