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

                List<FiliereModule> fm = await _db.Table<FiliereModule>().Where(f => f.ModuleId == moduleId).ToListAsync();
                List<Session> sessions = new List<Session>();
                foreach (FiliereModule f in fm)
                {
                    List<Session> s = await _db.Table<Session>().Where(s => s.FiliereModuleId == f.Id).ToListAsync();
                    sessions.AddRange(s);
                }

                List<Absence> absences = new List<Absence>();
                foreach (Session s in sessions)
                {
                    Absence a = await _db.Table<Absence>().Where(a => a.SessionId == s.Id && a.EtudiantId == studentId).FirstOrDefaultAsync();
                    if (a != null)
                    {
                        absences.Add(a);
                    }
                }
                return absences;

                
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
