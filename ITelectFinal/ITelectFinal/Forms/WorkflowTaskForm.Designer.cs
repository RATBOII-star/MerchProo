namespace ITelectFinal
{
    partial class WorkflowTaskForm
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
            lblTaskName = new Label();
            lblDescription = new Label();
            lblAssignedRole = new Label();
            txtTaskName = new TextBox();
            txtDescription = new TextBox();
            txtOrderId = new TextBox();
            txtAssignedRole = new TextBox();
            btnAddTask = new Button();
            btnUpdateWorkflow = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(183, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Workflow Tasks";
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
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Location = new Point(24, 134);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(79, 20);
            lblTaskName.TabIndex = 2;
            lblTaskName.Text = "Task Name";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(24, 194);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(85, 20);
            lblDescription.TabIndex = 3;
            lblDescription.Text = "Description";
            // 
            // lblAssignedRole
            // 
            lblAssignedRole.AutoSize = true;
            lblAssignedRole.Location = new Point(24, 336);
            lblAssignedRole.Name = "lblAssignedRole";
            lblAssignedRole.Size = new Size(96, 20);
            lblAssignedRole.TabIndex = 4;
            lblAssignedRole.Text = "Assigned Role";
            // 
            // txtOrderId
            // 
            txtOrderId.Location = new Point(24, 98);
            txtOrderId.Name = "txtOrderId";
            txtOrderId.Size = new Size(360, 27);
            txtOrderId.TabIndex = 5;
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(24, 158);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(360, 27);
            txtTaskName.TabIndex = 6;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(24, 218);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(360, 90);
            txtDescription.TabIndex = 7;
            // 
            // txtAssignedRole
            // 
            txtAssignedRole.Location = new Point(24, 360);
            txtAssignedRole.Name = "txtAssignedRole";
            txtAssignedRole.PlaceholderText = "Admin / Cashier / Prod. Staff";
            txtAssignedRole.Size = new Size(360, 27);
            txtAssignedRole.TabIndex = 8;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(24, 412);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(360, 40);
            btnAddTask.TabIndex = 9;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // btnUpdateWorkflow
            // 
            btnUpdateWorkflow.Location = new Point(24, 464);
            btnUpdateWorkflow.Name = "btnUpdateWorkflow";
            btnUpdateWorkflow.Size = new Size(360, 40);
            btnUpdateWorkflow.TabIndex = 10;
            btnUpdateWorkflow.Text = "Update Workflow Status (Pending -> InProgress)";
            btnUpdateWorkflow.UseVisualStyleBackColor = true;
            btnUpdateWorkflow.Click += btnUpdateWorkflow_Click;
            // 
            // WorkflowTaskForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(412, 525);
            Controls.Add(btnUpdateWorkflow);
            Controls.Add(btnAddTask);
            Controls.Add(txtAssignedRole);
            Controls.Add(txtDescription);
            Controls.Add(txtTaskName);
            Controls.Add(txtOrderId);
            Controls.Add(lblAssignedRole);
            Controls.Add(lblDescription);
            Controls.Add(lblTaskName);
            Controls.Add(lblOrderId);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "WorkflowTaskForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Workflow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOrderId;
        private Label lblTaskName;
        private Label lblDescription;
        private Label lblAssignedRole;
        private TextBox txtOrderId;
        private TextBox txtTaskName;
        private TextBox txtDescription;
        private TextBox txtAssignedRole;
        private Button btnAddTask;
        private Button btnUpdateWorkflow;
    }
}

