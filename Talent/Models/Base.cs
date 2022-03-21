using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /*
     * 系统模块
     */

    /// <summary>
    /// 导航图片
    /// </summary>
    [Table("Banners")]
    public class Banner : BasePoco
    {
        [Display(Name = "标题"), StringLength(100), Required]
        public string Title { get; set; }

        [Display(Name = "跳转地址"), StringLength(255)]
        public string Url { get; set; }

        [Display(Name = "图片"), Required]
        public Guid ImageID { get; set; }
        public FileAttachment Image { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

    }

    /// <summary>
    /// 行业类别
    /// </summary>
    [Table("IndustryCategories")]
    public class IndustryCategory : BasePoco
    {
        [Display(Name = "类别"), StringLength(20), Required]
        public string Category { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }
    }

    /// <summary>
    /// 服务类别
    /// </summary>
    [Table("ServiceCategories")]
    public class ServiceCategory : BasePoco
    {
        [Display(Name = "服务名称"), StringLength(100), Required]
        public string Name { get; set; }


        [Display(Name = "服务性质"), Required]
        public EnumServiceType Type { get; set; }

        [Display(Name = "年度限额（元）"), Required]
        public decimal LimitedValuation { get; set; }

        [Display(Name = "年度限额（次）"), Required]
        public int LimitedCount { get; set; }

        [Display(Name = "描述"), StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }
    }

    /// <summary>
    /// 内容类型
    /// </summary>
    [Table("ArticleCategories")]
    public class ArticleCategory : BasePoco
    {
        [Display(Name = "类型"), StringLength(50), Required]
        public string Category { get; set; }

        [Display(Name = "别名"), StringLength(20), Required]
        public string Alias { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }
    }
}
