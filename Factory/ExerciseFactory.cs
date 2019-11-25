using System;
using ILayer;
using DataLayer;
namespace Factory
{
    public class ExerciseFactory
    {
        public static IExerciseDAL CreateExerciseDAL()
        {
            IExerciseDAL exerciseDAL = new ExerciseDAL();
            return exerciseDAL;
        }
        public static IExerciseContainerDAL CreateExerciseContainerDAL()
        {
            IExerciseContainerDAL exerciseContainerDAL = new ExerciseDAL();
            return exerciseContainerDAL;
        }
    }
}
