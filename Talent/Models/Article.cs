using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /// <summary>
    /// 网站内容
    /// </summary>
    [Table("Articles")]
    public class Article : BasePoco
    {
        [Display(Name ="标题"), StringLength(200), Required]
        public string Subject { get; set; }

        [Display(Name ="作者"), StringLength(200), Required]
        public string Author { get; set; }

        [Display(Name ="来源"), StringLength(100)]
        public string Source { get; set; }

        [Display(Name = "阅读量"), Required]
        public int ReadCount { get; set; }
            
        [Display(Name ="类型"), Required]
        public Guid CategoryID { get; set; }
        public ArticleCategory Category { get; set; }

        [Display(Name = "内容"), Required]
        public string Context { get; set; }

        [Display(Name ="发布日期")]
        public DateTime? DateOfPublish { get; set; }

        [Display(Name ="是否发布"), Required]
        public bool IsPublished { get; set; }

        /*
         * 修改日期，修改人，创建日期、发布人
         * 从基类中调取
         * UpdateTime,UpdateBy,CreateTime,CreateBy
         */
    }
}
