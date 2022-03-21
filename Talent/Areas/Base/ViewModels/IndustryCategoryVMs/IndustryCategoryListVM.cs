using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.Base.ViewModels.IndustryCategoryVMs
{
    public partial class IndustryCategoryListVM : BasePagedListVM<IndustryCategory_View, IndustryCategorySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("IndustryCategory", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Base", dialogWidth: 800),
                this.MakeStandardAction("IndustryCategory", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Base", dialogWidth: 800),
                this.MakeStandardAction("IndustryCategory", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Base", dialogWidth: 800),
                this.MakeStandardAction("IndustryCategory", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Base", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<IndustryCategory_View>> InitGridHeader()
        {
            return new List<GridColumn<IndustryCategory_View>>{
                this.MakeGridHeader(x => x.Category),
                this.MakeGridHeader(x => x.IsEnabled),
                this.MakeGridHeader(x => x.SortIndex),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<IndustryCategory_View> GetSearchQuery()
        {
            var query = DC.Set<IndustryCategory>()
                .CheckContain(Searcher.Category, x=>x.Category)
                .CheckEqual(Searcher.IsEnabled, x=>x.IsEnabled)
                .Select(x => new IndustryCategory_View
                {
				    ID = x.ID,
                    Category = x.Category,
                    IsEnabled = x.IsEnabled,
                    SortIndex = x.SortIndex,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class IndustryCategory_View : IndustryCategory{

    }
}
