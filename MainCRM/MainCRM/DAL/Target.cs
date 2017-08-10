using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainCRM.DAL
{
    public class Target
    {

            public IEnumerable<Departement> Departs { get; set; }
            public IEnumerable<Instance> Instans { get; set; }

    }
}