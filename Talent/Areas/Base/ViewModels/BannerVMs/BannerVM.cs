using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Base.ViewModels.BannerVMs
{
    public partial class BannerVM : BaseCRUDVM<Banner>
    {

        public BannerVM()
        {
        }

        protected override void InitVM()
        {
            if (Entity.ID == default)
                Entity.IsEnabled = true;
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
