using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class ModuleServices
    {
        public SQLiteAsyncConnection _db;
        public ModuleServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Module>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        public async Task<List<Models.Module>> GetAllModulesAsync()
        {
            try
            {
                return await _db.Table<Models.Module>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Module>();
        }

        public async Task<Models.Module> GetSingleModuleAsync(int id)
        {
            try
            {
                return await _db.Table<Models.Module>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Models.Module();
        }

        public async Task<int> addModule(Models.Module module)
        {
            try
            {
                return await _db.InsertAsync(module);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<int> deleteModule(Models.Module module)
        {
            try
            {
                return await _db.DeleteAsync(module);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;

        }

        public async Task<int> updateModule(Models.Module module)
        {
            try
            {
                // get the module and update it
                Models.Module moduleToUpdate = await GetSingleModuleAsync(module.Id);
                moduleToUpdate.Nom = module.Nom;
                return await _db.UpdateAsync(moduleToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;

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

        public async Task<List<Models.Module>> GetModulesInProf(int profId)
        {
            try
            {
                return await _db.Table<Models.Module>().Where(i => i.ProfesseurId == profId).ToListAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Module>();
        }


    }
}
