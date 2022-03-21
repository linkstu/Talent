using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Base.ViewModels.ServiceCategoryVMs
{
    public partial class ServiceCategorySearcher : BaseSearcher
    {
        [Display(Name = "服务名称")]
        public String Name { get; set; }
        [Display(Name = "服务性质")]
        public EnumServiceType? Type { get; set; }
        [Display(Name = "启用")]
        public Boolean? IsEnabled { get; set; }

        protected override void InitVM()
        {
        }

    }
}
