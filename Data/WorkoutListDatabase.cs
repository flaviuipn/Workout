using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Threading.Tasks;
using RentACarM.Models;

namespace RentACarM.Data
{
    public class WorkoutListDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public WorkoutListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            Task.Run(() => InitializeDatabaseAsync()).Wait();
        }

        private async Task InitializeDatabaseAsync()
        {
            await _database.CreateTableAsync<WorkoutList>();
            await _database.CreateTableAsync<Exercise>();
            await _database.CreateTableAsync<ListExercise>();
            await _database.CreateTableAsync<Gym>();
        }

        public Task<List<Gym>> GetGymsAsync()
        {
            return _database.Table<Gym>().ToListAsync();
        }
        public Task<int> SaveGymAsync(Gym gym)
        {
            if (gym.ID != 0)
            {
                return _database.UpdateAsync(gym);
            }
            else
            {
                return _database.InsertAsync(gym);
            }
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            if (exercise.ID != 0)
            {
                return _database.UpdateAsync(exercise);
            }
            else
            {
                return _database.InsertAsync(exercise);
            }
        }
        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            if (exercise.ID != 0)
            {
                return _database.DeleteAsync(exercise);
            }
            else
            {
                // Întoarce un Task care semnalează că ștergerea nu a avut loc
                return Task.FromResult(0);
            }
        }
            public Task<List<Exercise>>GetExercisesAsync()
        {
            return _database.Table<Exercise>().ToListAsync();
        }
        public Task<int> SaveListExerciseAsync(ListExercise listw)
        {
            if (listw.ID != 0)
            {
                return _database.UpdateAsync(listw);
            }
            else
            {
                return _database.InsertAsync(listw);
            }
        }
        public Task<List<Exercise>> GetListExercisesAsync(int workoutlistid)
        {
            return _database.QueryAsync<Exercise>(
        "SELECT E.ID, E.Description " +
        "FROM Exercise E " +
        "INNER JOIN ListExercise LE ON E.ID = LE.ExerciseID " +
        "WHERE LE.WorkoutListID = ?",
        workoutlistid);
        }
        public Task<List<WorkoutList>> GetWorkoutListsAsync()
        {
            return _database.Table<WorkoutList>().ToListAsync();
        }
        public Task<int> SaveWorkoutListAsync(WorkoutList workoutList)
        {
            if (workoutList.ID != 0)
            {
                return _database.UpdateAsync(workoutList);
            }
            else
            {
                return _database.InsertAsync(workoutList);
            }
        }
        public Task<int> DeleteWorkoutListAsync(WorkoutList workoutList)
        {
            return _database.DeleteAsync(workoutList);
        }

    }
}