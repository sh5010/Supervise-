using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Supervise_.Models
{
    public class sp_student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }
        public int Phone { get; set; }
        public int Completed_hrs { get; set; }
        public decimal GPA { get; set; }
        
        public string Is_pass_web2 { get; set; }
        public string Is_pass_pr_mang { get; set; }
    }
}

