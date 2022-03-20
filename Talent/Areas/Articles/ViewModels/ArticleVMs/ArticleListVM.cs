using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleVMs
{
    public partial class ArticleListVM : BasePagedListVM<Article_View, ArticleSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"Articles", dialogWidth: 800),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "Articles", dialogWidth: 800),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "Articles", dialogWidth: 800),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "Articles", dialogWidth: 800),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "Articles", dialogWidth: 800),
                this.MakeStandardAction("Article", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "Articles"),
            };
        }

        protected override IEnumerable<IGridColumn<Article_View>> InitGridHeader()
        {
            return new List<GridColumn<Article_View>>{
                this.MakeGridHeader(x => x.Subject, 120),
                this.MakeGridHeader(x => x.Author,70),
                
                this.MakeGridHeader(x => x.ReadCount,80),
                this.MakeGridHeader(x => x.Alias_view, 100),
                //this.MakeGridHeader(x => x.Context),
                this.MakeGridHeader(x => x.DateOfPublish,140),
                this.MakeGridHeader(x => x.IsPublished,100),
                this.MakeGridHeader(x => x.Source),
                this.MakeGridHeader(x => x.CreateBy,100),
                this.MakeGridHeader(x => x.CreateTime,140),
                this.MakeGridHeader(x => x.UpdateBy,100),
                this.MakeGridHeader(x => x.UpdateTime,120),
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
                    Alias_view = x.Category.Alias,
                    Context = x.Context,
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
        [Display(Name = "别名")]
        public String Alias_view { get; set; }

    }
}
