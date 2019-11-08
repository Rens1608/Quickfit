using System;
using ILayer;
using DataLayer;
namespace Factory
{
    public class ExerciseFactory
    {
        public static IExerciseDAL CreateExerciseDAL
        {
            get
            {
                return CreateExerciseDAL;
            }
            set
            {
                IExerciseDAL exerciseDAL = new ExerciseDAL();
            }
        }
        public static IExerciseDAL CreateExerciseContainerDAL
        {
            get
            {
                return CreateExerciseContainerDAL;
            }
            set
            {
                IExerciseContainerDAL exerciseDAL = new ExerciseDAL();
            }
        }
    }
}
