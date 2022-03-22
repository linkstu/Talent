using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.Base.ViewModels.BannerVMs
{
    public partial class BannerListVM : BasePagedListVM<Banner_View, BannerSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Banner", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Base", dialogWidth: 800),
                this.MakeStandardAction("Banner", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Base", dialogWidth: 800),
                this.MakeStandardAction("Banner", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Base", dialogWidth: 800),
                this.MakeStandardAction("Banner", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Base", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<Banner_View>> InitGridHeader()
        {
            return new List<GridColumn<Banner_View>>{
                this.MakeGridHeader(x => x.Title, 300),
                this.MakeGridHeader(x => x.Url),
                this.MakeGridHeader(x => x.ImageID, 120).SetFormat(ImageIDFormat),
                this.MakeGridHeader(x => x.SortIndex, 100),
                this.MakeGridHeader(x => x.IsEnabled, 100),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> ImageIDFormat(Banner_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.ImageID),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.ImageID,640,480),
            };
        }


        public override IOrderedQueryable<Banner_View> GetSearchQuery()
        {
            var query = DC.Set<Banner>()
                .CheckContain(Searcher.Title, x=>x.Title)
                .CheckEqual(Searcher.IsEnabled, x=>x.IsEnabled)
                .Select(x => new Banner_View
                {
				    ID = x.ID,
                    Title = x.Title,
                    Url = x.Url,
                    ImageID = x.ImageID,
                    SortIndex = x.SortIndex,
                    IsEnabled = x.IsEnabled,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Banner_View : Banner{

    }
}
