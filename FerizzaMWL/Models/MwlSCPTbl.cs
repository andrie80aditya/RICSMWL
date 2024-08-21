using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FerizzaMWL.Models
{
    public partial class MwlSCPTbl
    {
        [Key]
        public int Item_ID { get; set; }
        [Required]
        public string TAG_ACCESSION_NUMBER { get; set; }
        [Required]
        public string TAG_MODALITY { get; set; }
        [Required]
        public string TAG_INSTITUTION_NAME { get; set; }
        [Required]
        public string TAG_REFERRING_PHYSICIAN_NAME { get; set; }
        [Required]
        public string TAG_PATIENT_NAME { get; set; }
        [Required]
        public string TAG_PATIENT_ID { get; set; }
        [Required]
        public DateTime? TAG_PATIENT_BIRTH_DATE { get; set; }
        [Required]
        public string TAG_PATIENT_SEX { get; set; }
        [Required]
        public double? TAG_PATIENT_WEIGHT { get; set; }
        [Required]
        public string TAG_STUDY_INSTANCE_UID { get; set; }
        public string TAG_REQUESTING_PHYSICIAN { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_DESCRIPTION { get; set; }
        public string TAG_ADMISSION_ID { get; set; }
        [Required]
        public string TAG_SCHEDULED_STATION_AE_TITLE { get; set; }
        [Required]
        public DateTime? TAG_SCHEDULED_PROCEDURE_STEP_START_DATE { get; set; }
        [Required]
        public DateTime? TAG_SCHEDULED_PROCEDURE_STEP_START_TIME { get; set; }
        public string TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME { get; set; }
        [Required]
        public string TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION { get; set; }
        [Required]
        public string TAG_SCHEDULED_PROCEDURE_STEP_ID { get; set; }
        public string TAG_SCHEDULED_PROCEDURE_STEP_LOCATION { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_ID { get; set; }
        public string TAG_REASON_FOR_THE_REQUESTED_PROCEDURE { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_PRIORITY { get; set; }
    }

    public partial class MwlSCP
    {
        [Key]
        public int Item_ID { get; set; }
        [Required]
        public string TAG_ACCESSION_NUMBER { get; set; }
        [Required]
        public string TAG_MODALITY { get; set; }
        [Required]
        public string TAG_INSTITUTION_NAME { get; set; }
        [Required]
        public string TAG_REFERRING_PHYSICIAN_NAME { get; set; }
        [Required]
        public string TAG_PATIENT_NAME { get; set; }
        [Required]
        public string TAG_PATIENT_ID { get; set; }
        [Required]
        public DateTime? TAG_PATIENT_BIRTH_DATE { get; set; }
        [Required]
        public string TAG_PATIENT_SEX { get; set; }
        [Required]
        public double? TAG_PATIENT_WEIGHT { get; set; }
        [Required]
        public string TAG_STUDY_INSTANCE_UID { get; set; }
        public string TAG_REQUESTING_PHYSICIAN { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_DESCRIPTION { get; set; }
        public string TAG_ADMISSION_ID { get; set; }
        [Required]
        public string TAG_SCHEDULED_STATION_AE_TITLE { get; set; }
        [Required]
        public DateTime? TAG_SCHEDULED_PROCEDURE_STEP_START_DATE { get; set; }
        [Required]
        public DateTime? TAG_SCHEDULED_PROCEDURE_STEP_START_TIME { get; set; }
        public string TAG_SCHEDULED_PERFORMING_PHYSICIAN_NAME { get; set; }
        [Required]
        public string TAG_SCHEDULED_PROCEDURE_STEP_DESCRIPTION { get; set; }
        [Required]
        public string TAG_SCHEDULED_PROCEDURE_STEP_ID { get; set; }
        public string TAG_SCHEDULED_PROCEDURE_STEP_LOCATION { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_ID { get; set; }
        public string TAG_REASON_FOR_THE_REQUESTED_PROCEDURE { get; set; }
        [Required]
        public string TAG_REQUESTED_PROCEDURE_PRIORITY { get; set; }
        [Required]
        public string TAG_USERNAME_IN_CHARGE { get; set; }
        [Required]
        public string TAG_PATIENT_SOURCE { get; set; }
    }
}