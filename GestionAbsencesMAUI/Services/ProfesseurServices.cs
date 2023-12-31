using GestionAbsencesMAUI.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Services
{
    public class ProfesseurServices
    {
        public SQLiteAsyncConnection _db;
        public ProfesseurServices(string dbPath)
        {
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Professeur>().Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }



        public async Task<bool> ajouterProfesseur(Professeur professeur)
        {
            try
            {
                int res = await _db.InsertAsync(professeur);
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding student: {ex.Message}");
                return false;
            }
        }


        public async Task<List<Professeur>> getAllProfesseurs()
        {
            try
            {
                return await _db.Table<Professeur>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all Professeurs: {ex.Message}");
                return null;
            }
        }

        public async Task<Professeur> getProfesseurById(int id)
        {
            try
            {
                return await _db.Table<Professeur>().Where(p => p.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Professeur: {ex.Message}");
                return null;
            }
        }

        public async Task<Professeur> getProfesseurByUsername(string username)
        {
            try
            { 
                return await _db.Table<Professeur>().Where(p => p.Username == username).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting Professeur: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> AuthenticateProfessorAsync(string username, string password)
        {
            try
            {
                var professor = await _db.Table<Professeur>().Where(p => p.Username == username && p.Password == password).FirstOrDefaultAsync();
                return professor != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error authenticating professor: {ex.Message}");
                return false;
            }
        }






    }



}
