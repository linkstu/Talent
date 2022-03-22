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
    public partial class TalentUnitBatchVM : BaseBatchVM<TalentUnit, TalentUnit_BatchEdit>
    {
        public TalentUnitBatchVM()
        {
            ListVM = new TalentUnitListVM();
            LinkedVM = new TalentUnit_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class TalentUnit_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
