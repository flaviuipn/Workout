﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;
namespace RentACarM.Models
{
    public class WorkoutList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(500), Unique]
        public string Description { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Gym))]
        public int GymID { get; set; }
    }
}
