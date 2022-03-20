using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleVMs
{
    public partial class ArticleSearcher : BaseSearcher
    {
        [Display(Name = "标题")]
        public String Subject { get; set; }
        [Display(Name = "作者")]
        public String Author { get; set; }

        [Display(Name = "分类")]
        public List<ComboSelectListItem> AllCategorys { get; set; }
        public Guid? CategoryID { get; set; }
        [Display(Name = "发布日期")]
        public DateRange DateOfPublish { get; set; }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<ArticleCategory>().GetSelectListItems(Wtm, y => y.Alias);
        }

    }
}
