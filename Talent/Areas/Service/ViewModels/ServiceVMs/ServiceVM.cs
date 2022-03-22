using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.service.ViewModels.ServiceVMs
{
    public partial class ServiceVM : BaseCRUDVM<Service>
    {
        public List<ComboSelectListItem> AllCategorys { get; set; }

        public ServiceVM()
        {
            SetInclude(x => x.Category);
        }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<ServiceCategory>().GetSelectListItems(Wtm, y => y.Name);
            if (Entity.ID == default)
            {
                Entity.IsEnabled = true;
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
