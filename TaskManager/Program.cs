using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Program
    {
        static int IntNumber() // Проверка на число
        {
            bool flag = true;
            int number;
            do
            {
                Console.WriteLine("Введите число:");
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести число");
                }
            }
            while (flag);

            return number;
        }
        static void Main(string[] args)
        {
            Worker Bob = new Worker("Боб");
            Worker Tom = new Worker("Том");
            Worker Tort = new Worker("Торт");
            Worker Gomer = new Worker("Гомер");
            Worker Ilya = new Worker("Илья");
            Worker Den = new Worker("Ден");
            Worker Fedor = new Worker("Федор");
            Worker Lev = new Worker("Лев");
            Worker Barbara = new Worker("Барбара");
            Worker Nastya = new Worker("Настя");

            Console.WriteLine($"Сотрудники: {Bob.WorkerName}, {Tom.WorkerName}, {Tort.WorkerName}, {Gomer.WorkerName}, {Ilya.WorkerName}," +
                $" {Den.WorkerName}, {Fedor.WorkerName}, {Lev.WorkerName}, {Barbara.WorkerName}, {Nastya.WorkerName}");

            Project projectArcane = new Project("Создать 2 сезон Arcane", DateTime.Today.AddDays(360), "Riot Games", Gomer.WorkerName);

            Console.WriteLine($"Описание проекта: {projectArcane.DescriptionProject}.\nСрок сдачи: {projectArcane.DeadLineProject}.\n" +
                              $"Заказчик: {projectArcane.CustomerProject}.\nОтветсвенный: {projectArcane.TeamLeaderProject}.\nСтатус проекта: {projectArcane.StatusProject}.");

            Console.WriteLine("Для назначения задачи введите ваше имя (вы должны быть отвественным за проект):");
            string nameTeamLeader = Console.ReadLine();
            Task taskArcane = new Task();
            if (projectArcane.CheckAccess(nameTeamLeader))
            {
                taskArcane.AddTask("Написать сюжет", DateTime.Today.AddDays(50));
                taskArcane.AddTask("Проработать персонажей", DateTime.Today.AddDays(70));
                taskArcane.AddTask("Зарисовать скетчи", DateTime.Today.AddDays(83));
                taskArcane.AddTask("Нарисовать предворительные кадры", DateTime.Today.AddDays(100));
                taskArcane.AddTask("Скетч-анимации ключевых моментов", DateTime.Today.AddDays(130));
                taskArcane.AddTask("Выпустить тизер", DateTime.Today.AddDays(180));
                taskArcane.AddTask("Реклама", DateTime.Today.AddDays(220));
                taskArcane.AddTask("Начать анимировать", DateTime.Today.AddDays(350));
                taskArcane.AddTask("Исправление ошибок", DateTime.Today.AddDays(360));
                projectArcane.ChangeStatus();
            }
            else
            {
                Console.WriteLine("У вас нету доступа");
            }
         
            Console.WriteLine("Задачи:");
            for (int i = 0; i < taskArcane.DescriptionTask.Count; i++)
            {
                Console.WriteLine($"Задачи: {taskArcane.DescriptionTask[i]}. Выоплнить до {taskArcane.DeadLineTask[i]}");
            }
            Console.WriteLine($"Статус проекта: {projectArcane.StatusProject}");

            if (projectArcane.CheckAccess(nameTeamLeader))
            {
                // Попытлася создать словарь, где его ключи будут связанны с индексами списка задач
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[0]), Bob.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[1]), Tom.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[2]), Tort.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[3]), Ilya.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[4]), Den.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[5]), Fedor.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[6]), Lev.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[7]), Barbara.WorkerName);
                taskArcane.GetTaskWorker(taskArcane.DescriptionTask.IndexOf(taskArcane.DescriptionTask[8]), Nastya.WorkerName);
            }
            else
            {
                Console.WriteLine("У вас нету доступа");
            }

            taskArcane.TakeTask(Bob.WorkerName);
            taskArcane.TakeTask(Tom.WorkerName);
            taskArcane.RefusedTask(Tort.WorkerName);
            taskArcane.TakeTask(Ilya.WorkerName);
            taskArcane.DelegateTask(Fedor.WorkerName, Den.WorkerName);
            taskArcane.TakeTask(Lev.WorkerName);
            taskArcane.TakeTask(Barbara.WorkerName);
            taskArcane.RefusedTask(Nastya.WorkerName);
            foreach (var pair in taskArcane.ExecutorTask)
            {
                Console.WriteLine($"Задачи: {pair.Key}. Исполнитель {pair.Value}");
            }
            projectArcane.ChangeStatus();
            Console.ReadKey();

        }
    }
}
