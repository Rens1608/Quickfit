using System;
using System.Collections.Generic;
using System.Text;

namespace ILayer
{
    public interface IWorkoutDAL
    {
        void UpdateWorkout(int id, string name, string skillevel, int time, string category);
    }
}
