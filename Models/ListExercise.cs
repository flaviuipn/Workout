using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace RentACarM.Models
{
   public class ListExercise
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(WorkoutList))]
        public int WorkoutListID { get; set; }
        public int ExerciseID { get; set; }
    }
}
