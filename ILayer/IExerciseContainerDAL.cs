using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace ILayer
{
    public interface IExerciseContainerDAL
    {
        List<ExerciseModel> GetAll();
        void Add(ExerciseModel exercise);
        void Remove(ExerciseModel exercise);
    }
}
