using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Project
    {
        internal enum ProjectStatus
        {
            Проект,
            Исполнение,
            Закрыт
        }
        private string descriptionProject;
        private DateTime deadLineProject;
        private string customerProject;
        private string teamLeaderProject;
        private List<Task> taskProject = new List<Task>();
        private ProjectStatus statusProject;
        
        public Project(string descriptionProject, DateTime deadLineProject, string customerProject, string teamLeaderProject)
        {
            this.descriptionProject = descriptionProject;
            this.deadLineProject = deadLineProject;
            this.customerProject = customerProject;
            statusProject = ProjectStatus.Проект;
            this.teamLeaderProject = teamLeaderProject;
        }
        public string DescriptionProject { get { return descriptionProject; } }
        public DateTime DeadLineProject { get { return deadLineProject; } }
        public string CustomerProject { get { return customerProject; } }
        public string TeamLeaderProject { get { return teamLeaderProject; } }
        public ProjectStatus StatusProject { get { return statusProject;} }

        public bool CheckAccess(string name) // Проверка доступа 
        {
            if( name == TeamLeaderProject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeStatus() // Смена статуса проекта
        {
            Task task = new Task();
            if (StatusProject == ProjectStatus.Проект && descriptionProject != null)
            {
                statusProject = ProjectStatus.Исполнение;
            }
            else if (StatusProject == ProjectStatus.Исполнение && descriptionProject != null)
            {
                statusProject = ProjectStatus.Закрыт;
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}
