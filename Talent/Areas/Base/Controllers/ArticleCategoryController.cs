using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Base.ViewModels.ArticleCategoryVMs;

namespace Talent.Controllers
{
    [Area("Base")]
    [ActionDescription("内容类型")]
    public partial class ArticleCategoryController : BaseController
    {
        #region Search
        [ActionDescription("Sys.Search")]
        public ActionResult Index()
        {
            var vm = Wtm.CreateVM<ArticleCategoryListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Sys.Search")]
        [HttpPost]
        public string Search(ArticleCategorySearcher searcher)
        {
            var vm = Wtm.CreateVM<ArticleCategoryListVM>(passInit: true);
            if (ModelState.IsValid)
            {
                vm.Searcher = searcher;
                return vm.GetJson(false);
            }
            else
            {
                return vm.GetError();
            }
        }

        #endregion

        #region Create
        [ActionDescription("Sys.Create")]
        public ActionResult Create()
        {
            var vm = Wtm.CreateVM<ArticleCategoryVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Sys.Create")]
        public ActionResult Create(ArticleCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region Edit
        [ActionDescription("Sys.Edit")]
        public ActionResult Edit(string id)
        {
            var vm = Wtm.CreateVM<ArticleCategoryVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Sys.Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(ArticleCategoryVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion

        #region Delete
        [ActionDescription("Sys.Delete")]
        public ActionResult Delete(string id)
        {
            var vm = Wtm.CreateVM<ArticleCategoryVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return FFResult().Alert(vm.MSD.GetFirstError());
            }
            else
            {
                return FFResult().RefreshGrid();
            }
        }
        #endregion

        #region Details
        [ActionDescription("Sys.Details")]
        public ActionResult Details(string id)
        {
            var vm = Wtm.CreateVM<ArticleCategoryVM>(id);
            return PartialView(vm);
        }
        #endregion
    }
}
