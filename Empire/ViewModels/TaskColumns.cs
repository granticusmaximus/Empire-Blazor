using Empire.Models;
using TaskStatus = Empire.Models.TaskStatus;

namespace Empire.ViewModels
{
    public class TaskColumns
    {
        public List<MSRTask> Backlog { get; set; } = new List<MSRTask>();
        public List<MSRTask> InProgress { get; set; } = new List<MSRTask>();
        public List<MSRTask> Done { get; set; } = new List<MSRTask>();

        public TaskColumns(IEnumerable<MSRTask> tasks)
        {
            Backlog = tasks.Where(t => t.Status == TaskStatus.Backlog).ToList();
            InProgress = tasks.Where(t => t.Status == TaskStatus.InProgress).ToList();
            Done = tasks.Where(t => t.Status == TaskStatus.Done).ToList();
        }

        // Method to move a task to a different column
        public void MoveTask(int taskId, TaskStatus newStatus)
        {
            var task = Backlog.FirstOrDefault(t => t.MsrID == taskId) ??
                       InProgress.FirstOrDefault(t => t.MsrID == taskId) ??
                       Done.FirstOrDefault(t => t.MsrID == taskId);

            if (task != null)
            {
                // Remove from current list
                Backlog.Remove(task);
                InProgress.Remove(task);
                Done.Remove(task);

                // Add to the new status list and update the status
                task.Status = newStatus;
                switch (newStatus)
                {
                    case TaskStatus.Backlog:
                        Backlog.Add(task);
                        break;
                    case TaskStatus.InProgress:
                        InProgress.Add(task);
                        break;
                    case TaskStatus.Done:
                        Done.Add(task);
                        break;
                }
            }
        }
    }

}
