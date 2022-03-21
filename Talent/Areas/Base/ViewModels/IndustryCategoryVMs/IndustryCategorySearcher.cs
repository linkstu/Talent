using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Base.ViewModels.IndustryCategoryVMs
{
    public partial class IndustryCategorySearcher : BaseSearcher
    {
        [Display(Name = "类别")]
        public String Category { get; set; }
        [Display(Name = "启用")]
        public Boolean? IsEnabled { get; set; }

        protected override void InitVM()
        {
        }

    }
}
