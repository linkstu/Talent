using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleVMs
{
    public partial class ArticleTemplateVM : BaseTemplateVM
    {
        [Display(Name = "标题")]
        public ExcelPropety Subject_Excel = ExcelPropety.CreateProperty<Article>(x => x.Subject);
        [Display(Name = "作者")]
        public ExcelPropety Author_Excel = ExcelPropety.CreateProperty<Article>(x => x.Author);
        [Display(Name = "来源")]
        public ExcelPropety Source_Excel = ExcelPropety.CreateProperty<Article>(x => x.Source);
        [Display(Name = "阅读量")]
        public ExcelPropety ReadCount_Excel = ExcelPropety.CreateProperty<Article>(x => x.ReadCount);
        public ExcelPropety Category_Excel = ExcelPropety.CreateProperty<Article>(x => x.CategoryID);
        [Display(Name = "内容")]
        public ExcelPropety Context_Excel = ExcelPropety.CreateProperty<Article>(x => x.Context);
        [Display(Name = "发布日期")]
        public ExcelPropety DateOfPublish_Excel = ExcelPropety.CreateProperty<Article>(x => x.DateOfPublish);
        [Display(Name = "是否发布")]
        public ExcelPropety IsPublished_Excel = ExcelPropety.CreateProperty<Article>(x => x.IsPublished);

	    protected override void InitVM()
        {
            Category_Excel.DataType = ColumnDataType.ComboBox;
            Category_Excel.ListItems = DC.Set<ArticleCategory>().GetSelectListItems(Wtm, y => y.Alias);
        }

    }

    public class ArticleImportVM : BaseImportVM<ArticleTemplateVM, Article>
    {

    }

}
