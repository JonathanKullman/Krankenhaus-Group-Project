using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public class SendReportEventArgs
    {
        public int CurrentTick { get;}
        public bool NoMorePatients { get; }
        public SendReportEventArgs(int currentTick)
        {

            this.CurrentTick = currentTick; 
        }
    }
}
