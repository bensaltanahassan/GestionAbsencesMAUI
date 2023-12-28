using GestionAbsencesMAUI.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class EtudiantService
    {
        //here add the logic of the service of the student model (CRUD)

        public SQLiteAsyncConnection _db;
        public EtudiantService(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Etudiant>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        public async Task<bool> ajouterEtudiant(Etudiant etudiant)
        {
            try
            {
                int res = await _db.InsertAsync(etudiant);
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
                return false;
            }
        }


    }
}
