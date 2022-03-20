using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.Models
{
    /*
     * 系统模块
     */

    /// <summary>
    /// 行业类别
    /// </summary>
    [Table("IndustryCategories")]
    public class IndustryCategory
    {
        [Display(Name ="类别"), StringLength(20), Required]
        public string Category { get; set; }

        [Display(Name = "启用"), Required]
        public bool IsEnabled { get; set; }

        [Display(Name ="排序"), Required]
        public int SortIndex { get; set; }
    }
}
