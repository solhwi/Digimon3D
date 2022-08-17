using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    public class JobTimer
    {
        Action JobAction;
        int IntervalMiliSeconds;
        bool bStart = false;

        Task Worker = null;

        public JobTimer(Action InJobAction, int InIntervalMiliSeconds)
        {
            JobAction = InJobAction;
            IntervalMiliSeconds = InIntervalMiliSeconds;
            bStart = true;

            Worker = new Task(Execute);
            Worker.Start();
        }

        public void Execute()
        {
            while(bStart)
            {
                JobAction.Invoke();
                Thread.Sleep(IntervalMiliSeconds);
            }
        }

        public void Start()
        {
            bStart = true;
            Worker = new Task(Execute);
            Worker.Start();
        }

        public void Stop()
        {
            if(Worker.Status != TaskStatus.Running)
            {
                return;
            }

            bStart = false;
        }

    }
}
