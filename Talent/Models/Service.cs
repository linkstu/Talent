using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /// <summary>
    /// 服务场所
    /// </summary>
    [Table("Services")]
    public class Service : BasePoco
    {
        [Display(Name ="服务类别"), Required]
        public Guid CategoryID { get; set; }
        public ServiceCategory Category { get; set; }

        [Display(Name ="服务场所"), StringLength(200), Required]
        public string Name { get; set; }

        [Display(Name = "介绍"), Required]
        public string Description { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }
    }
}
