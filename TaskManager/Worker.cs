using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    internal class Worker
    {
        private string workerName;
        private string workerTask;

        public string WorkerName {  get { return workerName; } }
        public Worker(string workerName)
        {
            this.workerName = workerName;            
        }
        
    }
}
