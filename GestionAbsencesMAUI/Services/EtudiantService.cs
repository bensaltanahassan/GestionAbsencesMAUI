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
        public SQLiteAsyncConnection _db;
        public EtudiantService(string dbPath)
        {

            Console.WriteLine($"Database path: {dbPath}");
            try
            {
                _db = new SQLiteAsyncConnection(dbPath);
                _db.CreateTableAsync<Models.Etudiant>().Wait();
                Console.WriteLine("Database created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
                Console.WriteLine(ex.Message);
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


        public async Task<List<Etudiant>> getAllEtudiants()
        {
            try
            {
                return await _db.Table<Etudiant>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all students: {ex.Message}");
                return null;
            }
        }

        //get etudiant in filiere
        public async Task<List<Etudiant>> getEtudiantsInFiliere(int filiereId)
        {
            try
            {
                return await _db.Table<Etudiant>().Where(etudiant => etudiant.filiereId == filiereId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting students in filiere: {ex.Message}");
                return null;
            }
        }
        public async Task<Etudiant> getEtudiantInFiliereByCne(int filiereId, string cne)
        {
            try
            {
                Etudiant etd = await _db.Table<Etudiant>().Where(etudiant => etudiant.filiereId == filiereId && etudiant.Cne == cne).FirstOrDefaultAsync();
                if(etd == null)
                {
                    return null;
                }else
                {
                    return etd;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting student in filiere by cne: {ex.Message}");
                return null;
            }
        }

        public async Task<Etudiant> getEtudiantById(int id)
        {
            try
            {
                return await _db.Table<Etudiant>().Where(etudiant => etudiant.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting student by id: {ex.Message}");
                return null;
            }
        }

        
        public async Task<List<Etudiant>> GetEtudiantsInModule(int moduleId)
        {
            try
            {
                var filiereModules = await _db.Table<FiliereModule>().Where(fm => fm.ModuleId == moduleId).ToListAsync();
                List<int> filiereIds = [];
                foreach (var filiereModule in filiereModules)
                {
                    filiereIds.Add(filiereModule.FiliereId);
                }

                List<Etudiant> etudiants = [];
                foreach (var filiereId in filiereIds)
                {
                    var etds = await _db.Table<Etudiant>().Where(etudiant => etudiant.filiereId == filiereId).ToListAsync();
                    etudiants.AddRange(etds);
                }

                return etudiants;



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting students in module: {ex.Message}");
                return new List<Etudiant>();
            }
        }


    }
}
