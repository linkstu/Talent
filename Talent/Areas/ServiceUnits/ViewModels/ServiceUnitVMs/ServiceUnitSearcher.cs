using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.ServiceUnits.ViewModels.ServiceUnitVMs
{
    public partial class ServiceUnitSearcher : BaseSearcher
    {
        [Display(Name = "单位名称")]
        public String Name { get; set; }
        [Display(Name = "服务类别")]
        public EnumServiceType? Type { get; set; }
        [Display(Name = "状态")]
        public EnumUnitStatus? Status { get; set; }

        protected override void InitVM()
        {
        }

    }
}
