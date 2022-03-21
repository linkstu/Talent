using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.Base.ViewModels.ServiceCategoryVMs
{
    public partial class ServiceCategoryListVM : BasePagedListVM<ServiceCategory_View, ServiceCategorySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ServiceCategory", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Base", dialogWidth: 800),
                this.MakeStandardAction("ServiceCategory", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Base", dialogWidth: 800),
                this.MakeStandardAction("ServiceCategory", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Base", dialogWidth: 800),
                this.MakeStandardAction("ServiceCategory", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Base", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<ServiceCategory_View>> InitGridHeader()
        {
            return new List<GridColumn<ServiceCategory_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Type),
                this.MakeGridHeader(x => x.LimitedValuation,130),
                this.MakeGridHeader(x => x.LimitedCount,130),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.IsEnabled,80),
                this.MakeGridHeader(x => x.SortIndex,80),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ServiceCategory_View> GetSearchQuery()
        {
            var query = DC.Set<ServiceCategory>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.Type, x=>x.Type)
                .CheckEqual(Searcher.IsEnabled, x=>x.IsEnabled)
                .Select(x => new ServiceCategory_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Type = x.Type,
                    LimitedValuation = x.LimitedValuation,
                    LimitedCount = x.LimitedCount,
                    Description = x.Description,
                    IsEnabled = x.IsEnabled,
                    SortIndex = x.SortIndex,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ServiceCategory_View : ServiceCategory{

    }
}
