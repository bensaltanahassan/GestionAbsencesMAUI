using GestionAbsencesMAUI.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class SessionServices
    {
        public SQLiteAsyncConnection _db;
        public SessionServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Session>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        public async Task<List<Models.Session>> GetAllInDbSessionsAsync()
        {
            try
            {
                return await _db.Table<Models.Session>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Session>();
        }

        public async Task<List<Models.Session>> GetSessionByFiliereModuleAsync(FiliereModule filiereModule)
        {
            try
            {
                return await _db.Table<Models.Session>().Where(i => i.FiliereModuleId == filiereModule.Id).
                    OrderByDescending(
                    i => i.Date
                    ).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Session>();
        }

        public async Task<int> addSession(Models.Session session)
        {
            try
            {
                return await _db.InsertAsync(session);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<int> deleteSession(Models.Session session)
        {
            try
            {
                return await _db.DeleteAsync(session);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<int> updateSession(Models.Session session)
        {
            try
            {
                // get the session and update it
                Models.Session sessionToUpdate = await GetSingleSessionAsync(session.Id);
                sessionToUpdate.Date = session.Date;
                sessionToUpdate.FiliereModuleId = session.FiliereModuleId;
                return await _db.UpdateAsync(sessionToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }
        public async Task<Models.Session> GetSingleSessionAsync(int id)
        {
            try
            {
                return await _db.Table<Models.Session>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Models.Session();
        }
    }

    



}
