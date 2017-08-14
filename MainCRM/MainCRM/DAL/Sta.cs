using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainCRM.DAL
{
    /*public class Sta
    {
        public Statusnya Stat { get; set; }
    }*/
    public enum Statusnya
    {
        Active,
        Allowed,
        Pending,
        Failed,
        Success
    }
}
    