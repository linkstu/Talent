using System.Collections.Generic;
using System.Linq;
using Talent.Models;
using WalkingTec.Mvvm.Core;


namespace Talent.Base.ViewModels.ArticleCategoryVMs
{
    public partial class ArticleCategoryListVM : BasePagedListVM<ArticleCategory_View, ArticleCategorySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Base", dialogWidth: 800),
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Base", dialogWidth: 800),
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Base", dialogWidth: 800)
                    .SetShowDialog(false).SetPromptMessage("当前分类下的所有内容将被删除<br />确实要删除当前分类？"),
                this.MakeStandardAction("ArticleCategory", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Base", dialogWidth: 800),
            };
        }


        protected override IEnumerable<IGridColumn<ArticleCategory_View>> InitGridHeader()
        {
            return new List<GridColumn<ArticleCategory_View>>{
                this.MakeGridHeader(x => x.Category),
                this.MakeGridHeader(x => x.Alias, 160),
                this.MakeGridHeader(x => x.IsEnabled, 80),
                this.MakeGridHeader(x => x.SortIndex, 80),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<ArticleCategory_View> GetSearchQuery()
        {
            var query = DC.Set<ArticleCategory>()
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
