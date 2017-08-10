using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainCRM.DAL
{
    public class Progs
    {
        public IEnumerable<Program> Programs { get; set; }
        public IEnumerable<Modul> Moduls { get; set; }
    }
}