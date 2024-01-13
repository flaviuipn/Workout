using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;


namespace RentACarM.Models
{
    public class Gym
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string GymName { get; set; }
        public string Adress { get; set; }
        public string GymDetails
        {
            get
            {
                return GymName + " " +Adress;} }

        [OneToMany]
        public List<WorkoutList> WokoutLists { get; set; }
    }
}
