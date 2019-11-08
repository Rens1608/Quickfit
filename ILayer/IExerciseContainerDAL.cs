using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IExerciseContainerDAL
    {
        List<Exercise> GetAll();
        void Add(Exercise exercise);
        void Remove(Exercise exercise);
    }
}
