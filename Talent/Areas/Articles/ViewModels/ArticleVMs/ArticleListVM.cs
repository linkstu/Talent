using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Talent.Models;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;


namespace Talent.Articles.ViewModels.ArticleVMs
{
    public partial class ArticleListVM : BasePagedListVM<Article_View, ArticleSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Articles", dialogWidth: 800)
                    .SetIsRedirect(true).SetShowDialog(false),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Articles", dialogWidth: 800)
                    .SetIsRedirect(true).SetShowDialog(false),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Articles", dialogWidth: 800)
                    .SetShowDialog(false).SetPromptMessage("确实要删除当前内容？"),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Articles", dialogWidth: 800)
                    .SetIsRedirect(true).SetShowDialog(false),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Articles", dialogWidth: 800),
            };
        }

        protected override IEnumerable<IGridColumn<Article_View>> InitGridHeader()
        {
            return new List<GridColumn<Article_View>>{
                this.MakeGridHeader(x => x.Subject),
                this.MakeGridHeader(x => x.Category_view, 200),
                this.MakeGridHeader(x => x.Author,100),
                this.MakeGridHeader(x => x.ReadCount,100),
                this.MakeGridHeader(x => x.IsPublished,100),
                this.MakeGridHeader(x => x.CreateBy,100),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Article_View> GetSearchQuery()
        {
            var query = DC.Set<Article>()
                .CheckContain(Searcher.Subject, x=>x.Subject)
                .CheckContain(Searcher.Author, x=>x.Author)
                .CheckEqual(Searcher.CategoryID, x=>x.CategoryID)
                .CheckBetween(Searcher.DateOfPublish?.GetStartTime(), Searcher.DateOfPublish?.GetEndTime(), x => x.DateOfPublish, includeMax: false)
                .Select(x => new Article_View
                {
				    ID = x.ID,
                    Subject = x.Subject,
                    Author = x.Author,
                    Source = x.Source,
                    ReadCount = x.ReadCount,
                    Category_view = x.Category.Category,
                    DateOfPublish = x.DateOfPublish,
                    IsPublished = x.IsPublished,
                    CreateBy = x.CreateBy,
                    CreateTime = x.CreateTime,
                    UpdateBy = x.UpdateBy,
                    UpdateTime = x.UpdateTime
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Article_View : Article{
        [Display(Name = "类型")]
        public String Category_view { get; set; }

    }
}
