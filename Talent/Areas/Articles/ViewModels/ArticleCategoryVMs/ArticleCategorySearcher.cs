using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleCategoryVMs
{
    public partial class ArticleCategorySearcher : BaseSearcher
    {
        [Display(Name = "类型")]
        public String Category { get; set; }
        [Display(Name = "启用")]
        public Boolean? IsEnabled { get; set; }

        protected override void InitVM()
        {
        }

    }
}
