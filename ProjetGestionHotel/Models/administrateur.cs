//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetGestionHotel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class administrateur
    {
        public int id_admin { get; set; }
        public string nom_admin { get; set; }
        public string prenom_admin { get; set; }
        public string email_admin { get; set; }
        public string tel_admin { get; set; }
        public string login_admin { get; set; }
        public string mdp_admin { get; set; }
        public bool is_superadmin { get; set; }
    }
}