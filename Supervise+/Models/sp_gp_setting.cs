using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Supervise_.Models
{
    public class sp_gp_setting
    {
        public int Id { get; set; }
        public int Max_st_num { get; set; }

        public int Min_st_num { get; set; }

        public int Num_male_grp { get; set; }
        public int Num_female_grp { get; set; }
        public int Dr_supr_limit { get; set; }
        public int Ms_supr_limit { get; set; }
        public int M_F_supr_limit { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime Term1_Subm_deadline { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime Term2_Subm_deadline { get; set; }
    }
}
