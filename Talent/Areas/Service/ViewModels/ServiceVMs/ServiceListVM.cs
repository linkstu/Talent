using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.service.ViewModels.ServiceVMs
{
    public partial class ServiceListVM : BasePagedListVM<Service_View, ServiceSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Service", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"service", dialogWidth: 800),
                this.MakeStandardAction("Service", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "service", dialogWidth: 800),
                this.MakeStandardAction("Service", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "service", dialogWidth: 800),
                this.MakeStandardAction("Service", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "service", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<Service_View>> InitGridHeader()
        {
            return new List<GridColumn<Service_View>>{
                this.MakeGridHeader(x => x.Name_view,200),
                this.MakeGridHeader(x => x.Name,200),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.IsEnabled, 100),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Service_View> GetSearchQuery()
        {
            var query = DC.Set<Service>()
                .CheckEqual(Searcher.CategoryID, x=>x.CategoryID)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.IsEnabled, x=>x.IsEnabled)
                .Select(x => new Service_View
                {
				    ID = x.ID,
                    Name_view = x.Category.Name,
                    Name = x.Name,
                    Description = x.Description,
                    IsEnabled = x.IsEnabled,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Service_View : Service{
        [Display(Name = "服务名称")]
        public String Name_view { get; set; }

    }
}
