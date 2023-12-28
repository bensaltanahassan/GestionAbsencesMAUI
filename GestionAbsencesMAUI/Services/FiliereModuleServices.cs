using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class FiliereModuleServices
    {
        public SQLiteAsyncConnection _db;
        public FiliereModuleServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.FiliereModule>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }


        public async Task<int> addFiliereModule(Models.FiliereModule filiereModule)
        {
            try
            {
                return await _db.InsertAsync(filiereModule);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<int> deleteFiliereModule(Models.FiliereModule filiereModule)
        {
            try
            {
                return await _db.DeleteAsync(filiereModule);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<List<Models.FiliereModule>> GetFiliereModulesAsync()
        {
            try
            {
                return await _db.Table<Models.FiliereModule>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.FiliereModule>();
        }


        
        public async Task<List<Models.Filiere>> GetFilieresThatHaveModule(int moduleId)
        {
            try
            {
                var filieres = await _db.QueryAsync<Models.Filiere>(
                "SELECT * FROM Filiere WHERE Id IN (SELECT FiliereId FROM FiliereModule WHERE ModuleId = ?)", moduleId);
                return filieres;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Filiere>();
        }
    }
}
