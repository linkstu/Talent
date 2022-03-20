using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /*
     * 系统模块
     */

    /// <summary>
    /// 行业类别
    /// </summary>
    [Table("IndustryCategories")]
    public class IndustryCategory : BasePoco
    {
        [Display(Name ="类别"), StringLength(20), Required]
        public string Category { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name ="排序"), Required]
        public int SortIndex { get; set; }
    }

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
        public FileAttachment Image { get; set; }

        [Display(Name = "排序"), Required]
        public int SortIndex { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

    }
}
