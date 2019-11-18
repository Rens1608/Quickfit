using System;
using System.Collections.Generic;
using System.Text;

namespace ILayer
{
    public interface IExerciseDAL
    {
        void UpdateName( int id, string name);
        void UpdateWeight( int id, int weight);
        void UpdateRepetitions(int id, int repetitions);
        void UpdateLevel(int id, string level);
    }
}
