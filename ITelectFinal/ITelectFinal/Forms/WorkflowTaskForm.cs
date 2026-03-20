using ITelectFinal.Models;
using ITelectFinal.Repositories;
using ITelectFinal.Services;
using ITelectFinal.Utils;

namespace ITelectFinal
{
    public partial class WorkflowTaskForm : Form
    {
        private readonly WorkflowTaskRepository _repository;
        private readonly WorkflowService _workflowService;

        public WorkflowTaskForm(WorkflowTaskRepository repository)
        {
            InitializeComponent();
            _repository = repository;
            _workflowService = new WorkflowService(_repository);
        }

        public WorkflowTaskForm()
            : this(new WorkflowTaskRepository())
        {
        }

        private async void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtOrderId.Text.Trim(), out var orderId))
                {
                    MessageBox.Show("OrderId must be a number.");
                    return;
                }

                var task = new WorkflowTask
                {
                    OrderId = orderId,
                    TaskName = txtTaskName.Text.Trim(),
                    TaskDescription = txtDescription.Text.Trim(),
                    AssignedRole = string.IsNullOrWhiteSpace(txtAssignedRole.Text) ? "Prod. Staff" : txtAssignedRole.Text.Trim(),
                    Status = "Pending",
                    LastUpdated = DateTime.Now
                };

                await _repository.AddAsync(task);
                MessageBox.Show("Task added successfully!");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
                MessageBox.Show("Something went wrong.");
            }
        }

        private async void btnUpdateWorkflow_Click(object sender, EventArgs e)
        {
            await _workflowService.UpdateWorkflowStatusAsync();
            MessageBox.Show("Workflow updated (Pending -> InProgress).");
        }
    }
}

