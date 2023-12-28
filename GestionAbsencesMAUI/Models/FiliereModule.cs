using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionAbsencesMAUI.Models
{
    public class FiliereModule
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public int FiliereId { get; set; }
        public int ModuleId { get; set; }
    }
}
