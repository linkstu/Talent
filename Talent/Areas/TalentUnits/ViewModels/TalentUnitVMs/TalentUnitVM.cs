using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.TalentUnits.ViewModels.TalentUnitVMs
{
    public partial class TalentUnitVM : BaseCRUDVM<TalentUnit>
    {
        public List<ComboSelectListItem> AllCategorys { get; set; }

        public TalentUnitVM()
        {
            SetInclude(x => x.Category);
        }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<IndustryCategory>().GetSelectListItems(Wtm, y => y.Category);

            if (Entity.ID == default)
            {
                Entity.Status = EnumUnitStatus.Waiting;
                Entity.DateOfRegister = DateTime.Now;
            }
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
