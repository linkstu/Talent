using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleCategoryVMs
{
    public partial class ArticleCategoryListVM : BasePagedListVM<ArticleCategory_View, ArticleCategorySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Articles", dialogWidth: 800),
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Articles", dialogWidth: 800),
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Articles", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<ArticleCategory_View>> InitGridHeader()
        {
            return new List<GridColumn<ArticleCategory_View>>{
                this.MakeGridHeader(x => x.Category),
                this.MakeGridHeader(x => x.Alias),
                this.MakeGridHeader(x => x.IsEnabled),
                this.MakeGridHeader(x => x.SortIndex),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ArticleCategory_View> GetSearchQuery()
        {
            var query = DC.Set<ArticleCategory>()
                .CheckContain(Searcher.Category, x=>x.Category)
                .CheckEqual(Searcher.IsEnabled, x=>x.IsEnabled)
                .Select(x => new ArticleCategory_View
                {
				    ID = x.ID,
                    Category = x.Category,
                    Alias = x.Alias,
                    IsEnabled = x.IsEnabled,
                    SortIndex = x.SortIndex,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class ArticleCategory_View : ArticleCategory{

    }
}
