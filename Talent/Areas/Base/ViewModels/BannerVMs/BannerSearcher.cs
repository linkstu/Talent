using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Base.ViewModels.BannerVMs
{
    public partial class BannerSearcher : BaseSearcher
    {
        [Display(Name = "标题")]
        public String Title { get; set; }
        [Display(Name = "启用")]
        public Boolean? IsEnabled { get; set; }

        protected override void InitVM()
        {
        }

    }
}
