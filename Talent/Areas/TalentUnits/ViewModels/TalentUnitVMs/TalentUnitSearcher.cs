using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.TalentUnits.ViewModels.TalentUnitVMs
{
    public partial class TalentUnitSearcher : BaseSearcher
    {
        [Display(Name = "单位名称")]
        public String Name { get; set; }
        public List<ComboSelectListItem> AllCategorys { get; set; }
        public Guid? CategoryID { get; set; }
        [Display(Name = "联系电话")]
        public String Telephone { get; set; }
        [Display(Name = "状态")]
        public EnumUnitStatus? Status { get; set; }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<IndustryCategory>().GetSelectListItems(Wtm, y => y.Category);
        }

    }
}
