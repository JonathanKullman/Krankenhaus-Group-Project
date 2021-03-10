using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary
{
    public interface IDepartment
    {
        int Risk { get; }
        int Chance { get; }

        public virtual void OnTickChanges(Hospital hp) { }
        public IDepartment Clone();

    }
}
