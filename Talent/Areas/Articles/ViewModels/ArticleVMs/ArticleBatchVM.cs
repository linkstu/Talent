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
    public partial class ArticleBatchVM : BaseBatchVM<Article, Article_BatchEdit>
    {
        public ArticleBatchVM()
        {
            ListVM = new ArticleListVM();
            LinkedVM = new Article_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Article_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
