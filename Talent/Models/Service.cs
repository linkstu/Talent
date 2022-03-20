using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /// <summary>
    /// 服务类别
    /// </summary>
    [Table("ServiceCategories")]
    public class ServiceCategory : BasePoco
    {
        [Display(Name = "服务名称"), StringLength(100), Required]
        public string Name { get; set; }


        [Display(Name = "服务性质"), StringLength(100), Required]
        public EnumServiceType Type { get; set; }

        [Display(Name ="年度限额（元）"), Required]
        public decimal LimitedValuation { get; set; }

        [Display(Name = "年度限额（次）"), Required]
        public int LimitedCount { get; set; }

        [Display(Name ="描述"), StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }
    }

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
