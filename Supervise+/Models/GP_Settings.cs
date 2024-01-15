using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Supervise_.Models
{
    public class GP_Settings
    {
        public int id { get; set; }
        public int Max_students_number {  get; set; }
        public int Min_students_number { get; set; }
        public int Num_of_male_groups { get; set; }
        public int Num_of_female_groups { get; set; }
        public int Dr_supervision_limit { get; set; }
        public int Ms_supervision_limit { get; set; }
        public int M_F__supervision_limit { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime Term1_SubmissionDeadline { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateTime Term2_SubmissionDeadline { get; set; }


    }
}
