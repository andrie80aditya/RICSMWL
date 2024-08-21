using System.ComponentModel.DataAnnotations;
using System;

namespace FerizzaMWL.Models
{
    public partial class Study
    {
        [Key]
        public string StudyInstanceUID { get; set; }
        public DateTime? StudyDate { get; set; }
        public string AccessionNumber { get; set; }
        public string StudyID { get; set; }
        public string ReferDrFamilyName { get; set; }
        public string ReferDrGivenName { get; set; }
        public string ReferDrMiddleName { get; set; }
        public string ReferDrNamePrefix { get; set; }
        public string ReferDrNameSuffix { get; set; }
        public string StudyDescription { get; set; }
        public string AdmittingDiagnosesDesc { get; set; }
        public string PatientAge { get; set; }
        public decimal? PatientSize { get; set; }
        public decimal? PatientWeight { get; set; }
        public string Occupation { get; set; }
        public string AdditionalPatientHistory { get; set; }
        public string InterpretationAuthor { get; set; }
        public string PatientID { get; set; }
        public string RetrieveAETitle { get; set; }
        public string Expertise { get; set; }
        public string ExpertiseBy { get; set; }
        public DateTime? ExpertiseDate { get; set; }
        public string ExpertiseApproveBy { get; set; }
        public DateTime? ExpertiseApproveDate { get; set; }
        public string Addendum { get; set; }
        public string AddendumBy { get; set; }
        public DateTime? AddendumDate { get; set; }
        public string AddendumApproveBy { get; set; }
        public DateTime? AddendumApproveDate { get; set; }
    }

    public partial class StudyViewModel
    {
        public string StudyUID { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? StudyDate { get; set; }
        public string StudyDescription { get; set; }
        public string AccessionNo { get; set; }
        public string PatienId { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string ExpertiseType { get; set; }
        [DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? ExpertiseDate { get; set; }
        public string RadiologyDr { get; set; }
        public string ImageUrl { get; set; }
        public string ExpertiseUrl { get; set; }
        public string ExpertiseHtml { get; set; }
    }
}
