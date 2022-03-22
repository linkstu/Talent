using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.service.ViewModels.ServiceVMs
{
    public partial class ServiceSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllCategorys { get; set; }
        public Guid? CategoryID { get; set; }
        [Display(Name = "服务场所")]
        public String Name { get; set; }
        [Display(Name = "启用")]
        public Boolean? IsEnabled { get; set; }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<ServiceCategory>().GetSelectListItems(Wtm, y => y.Name);
        }

    }
}
