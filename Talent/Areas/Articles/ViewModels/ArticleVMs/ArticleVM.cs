using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.Articles.ViewModels.ArticleVMs
{
    public partial class ArticleVM : BaseCRUDVM<Article>
    {
        public List<ComboSelectListItem> AllCategorys { get; set; }

        public ArticleVM()
        {
            SetInclude(x => x.Category);
        }

        protected override void InitVM()
        {
            AllCategorys = DC.Set<ArticleCategory>().GetSelectListItems(Wtm, y => y.Alias);

            if(Entity.ID == default)
            {
                Entity.IsPublished = true;
            }
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
