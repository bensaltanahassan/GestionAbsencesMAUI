using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class AbsenceServices
    {
        public SQLiteAsyncConnection _db;
        public AbsenceServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Absence>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }


        public async Task<int> addAbsence(Models.Absence absence)
        {
            try
            {
                return await _db.InsertAsync(absence);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        // get all absences in a session
        public async Task<List<Models.Absence>> GetAbsencesInSession(int sessionId)
        {
            try
            {
                return await _db.Table<Models.Absence>().Where(absence => absence.SessionId == sessionId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Absence>();
        }
    }


    




}
