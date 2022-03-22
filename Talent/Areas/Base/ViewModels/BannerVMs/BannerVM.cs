using System.Linq;
using Talent.Models;
using WalkingTec.Mvvm.Core;


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
            {
                Entity.IsEnabled = true;
                Entity.SortIndex = (DC.Set<Banner>().AsEnumerable().MaxBy(a => a.SortIndex)?.SortIndex ?? 0) + 1;
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
