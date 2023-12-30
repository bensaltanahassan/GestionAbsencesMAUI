using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionAbsencesMAUI.Models;

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

        public async Task<List<Absence>> GetAbsencesInModuleForStudent(int studentId, int moduleId)
        {
            try
            {
                var query = $"SELECT Absence.* FROM Absence " +
                            $"INNER JOIN Etudiant ON Absence.EtudiantId = Etudiant.Id " +
                            $"INNER JOIN FiliereModule ON Etudiant.filiereId = FiliereModule.FiliereId " +
                            $"INNER JOIN Module ON FiliereModule.ModuleId = Module.Id " +
                            $"WHERE Etudiant.Id = {studentId} AND Module.Id = {moduleId}";

                var absencesInModuleForStudent = await _db.QueryAsync<Absence>(query);
                return absencesInModuleForStudent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error querying absences: {ex.Message}");
                return new List<Absence>();
            }
        }


        public async Task<int> addAbsence(Models.Absence absence)
        {
            try
            {
                var ab = await _db.Table<Models.Absence>().Where(abs => abs.SessionId == absence.SessionId && abs.EtudiantId == absence.EtudiantId).
                    FirstOrDefaultAsync();
                if (ab != null)
                {
                    ab.IsPresent = absence.IsPresent;
                    return await _db.UpdateAsync(ab);
                }
                else
                {
                    return await _db.InsertAsync(absence);
                }
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
