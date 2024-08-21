using System.ComponentModel.DataAnnotations;
using System;

namespace FerizzaMWL.Models
{
    public partial class Patient
    {
        [Key]
        public string PatientID { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string NamePrefix { get; set; }
        public string NameSuffix { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public string EthnicGroup { get; set; }
        public string Comments { get; set; }
        public string RetrieveAETitle { get; set; }
        public string IssuerOfPatientID { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDte { get; set; }
    }
}
