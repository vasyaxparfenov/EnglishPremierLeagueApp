//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EnglishPremierLeagueApp.ModelsOLD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Injury
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public System.DateTime DateOfInjured { get; set; }
        public System.DateTime DateOfRecover { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
