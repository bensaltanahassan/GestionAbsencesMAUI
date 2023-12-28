using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class FiliereServices
    {
        public SQLiteAsyncConnection _db;
        public FiliereServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Filiere>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        } 

        public async Task<List<Models.Filiere>> GetFilieresAsync()
        {
            try
            {
                return await _db.Table<Models.Filiere>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new List<Models.Filiere>();
        }

        public async Task<Models.Filiere> GetFiliereAsync(int id)
        {
            try
            {
                return await _db.Table<Models.Filiere>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return new Models.Filiere();
        }

        public async Task<int> addFiliere(Models.Filiere filiere)
        {
            try
            {
                return await _db.InsertAsync(filiere);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
            
        }

        public async Task<int> updateFiliere(Models.Filiere filiere)
        {
            try
            {
                // get the filiere and update it
                Models.Filiere filiereToUpdate = await GetFiliereAsync(filiere.Id);
                filiereToUpdate.Nom = filiere.Nom;
                return await _db.UpdateAsync(filiereToUpdate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }

        public async Task<int> deleteFiliere(Models.Filiere filiere)
        {
            try
            {
                return await _db.DeleteAsync(filiere);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return 0;
        }


        

    }
}
