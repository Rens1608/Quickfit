using System;
using System.Collections.Generic;
using System.Text;

namespace ILayer
{
    public interface IExerciseDAL
    {
        void UpdateExercise(int id, string name, int weight, int repetitions, string skillevel, string connectionstring);
    }
}
