using System;
using System.Collections.Generic;
using System.Text;

namespace ILayer
{
    public interface IExerciseDAL
    {
        void UpdateName();
        void UpdateWeight();
        void UpdateRepetitions();
        void UpdateLevel();
    }
}
