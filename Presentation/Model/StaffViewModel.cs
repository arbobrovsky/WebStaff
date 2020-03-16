using Presentation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class StaffViewModel
    {
        public int StaffId { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public virtual PositionViewModel Position { get; set; }
        public virtual List<PositionViewModel> Positions { get; set; }
        public int RankId { get; set; }
        public virtual RankViewModel Rank { get; set; }
        public DateTime HowTimeFired { get; set; }
        public int SubDepartmenId { get; set; }
        public virtual SubDepartmentViewModel SubDepartmen { get; set; }
        public int? DepartmenId { get; set; }
        public virtual List<DepartmentViewModel> Departmens { get; set; }
        public string HowFired { get; set; }
        public bool Fired { get; set; }
        public DateTime DateFired { get; set; }
        public int DecreeId { get; set; }
        public virtual List<DecreeViewModel> DecreeViewModels { get; set; }

    }

    public class StaffCreateViewModel
    {
        public int StaffId { get; set; }

        [Required(ErrorMessage = "Введите имя")]
        [Display(Name = "Имя")]
        public string First { get; set; }
        [Display(Name = "Фамилию")]
        [Required(ErrorMessage = "Введите Фамилию")]
        public string Second { get; set; }
        [Display(Name = "Отчество")]
        [Required(ErrorMessage = "Введите Отчество")]
        public string MiddleName { get; set; }
        public int PositionId { get; set; }
        public virtual List<PositionViewModel> Position { get; set; }
        public int RankId { get; set; }
        public virtual List<RankViewModel> Rank { get; set; }
        public int SubDepartmenId { get; set; }
        public virtual List<SubDepartmentViewModel> SubDepartmen { get; set; }
        public int? DepartmenId { get; set; }
        public virtual List<DepartmentViewModel> Departmens { get; set; }

        public string HowFired { get; set; }
        public DateTime WhereTimeFired { get; set; }
    }









}
