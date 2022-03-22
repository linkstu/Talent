using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.ServiceUnits.ViewModels.ServiceUnitVMs
{
    public partial class ServiceUnitVM : BaseCRUDVM<ServiceUnit>
    {

        public ServiceUnitVM()
        {
        }

        protected override void InitVM()
        {
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
