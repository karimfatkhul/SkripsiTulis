//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainCRM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bidding
    {
        public int BiddingID { get; set; }
        public int InstanceID { get; set; }
        public Nullable<int> DepartementID { get; set; }
        public int ProgramID { get; set; }
        public Nullable<int> ModulID { get; set; }
        public string BiddingStatus { get; set; }
        public string BiddingInformationDetail { get; set; }
        public string BiddingStage { get; set; }
        public Nullable<System.DateTime> DateOfCurrentBidStatus { get; set; }
        public string NextStep { get; set; }
        public Nullable<System.DateTime> DateOfNextStep { get; set; }
        public string Qualified { get; set; }
    
        public virtual Departement Departement { get; set; }
        public virtual Instance Instance { get; set; }
        public virtual Modul Modul { get; set; }
        public virtual Program Program { get; set; }
    }
}
