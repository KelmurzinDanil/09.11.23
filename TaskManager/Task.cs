using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Task
    {
        enum TaskStatus
        {
            Назначена,
            В_работе,
            На_проверке,
            Выполнена
        }
        private List<string> descriptionTask = new List<string>();
        private List<DateTime> deadLineTask = new List<DateTime>();
        private string customerProject;
        private Dictionary<int, string> executorTask = new Dictionary<int, string>();
        private List<TaskStatus> statusTask = new List<TaskStatus>();
        private List<Report> reportTasks = new List<Report>();

        public List<string> DescriptionTask { get { return descriptionTask; } }
        public List<DateTime> DeadLineTask { get { return deadLineTask; } }
        public Dictionary<int, string> ExecutorTask { get { return executorTask; } }
        public void AddTask(string descriptionTask, DateTime deadLineTask)
        {
            this.descriptionTask.Add(descriptionTask);
            this.deadLineTask.Add(deadLineTask);
        }
        public void GetTaskWorker(int key, string name) // Дать задачу работнику
        {
            statusTask.Add(TaskStatus.Назначена);
            this.executorTask.Add(key, name);
        }
        public void TakeTask(string name) // Работник берет задачу
        {
            string task = DescriptionTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key];
            if (task != null)
            {
                statusTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key] = TaskStatus.В_работе;
                executorTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key] = name ;
            }
            else
            {
                Console.WriteLine("Вы не можете взять задачу");
            }
        }
        public void DelegateTask(string name, string delegateName)// Работник передает задачу
        {
            string task = DescriptionTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key];
            if ( task != null)
            {
                statusTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key] = TaskStatus.В_работе;
                int ind1 = DescriptionTask.IndexOf(delegateName);
                int ind2 = DescriptionTask.IndexOf(name);
                (ind1, ind2) = (DescriptionTask.IndexOf(name), DescriptionTask.IndexOf(delegateName));
                
            }
            else
            {
                Console.WriteLine("Вы не можете передать задачу");
            }
        }
        public void RefusedTask(string name)// 
        {
            ExecutorTask[ExecutorTask.FirstOrDefault(x => x.Value == name).Key] = null;
        }
    }
}
