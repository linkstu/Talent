using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.TalentUnits.ViewModels.TalentUnitVMs
{
    public partial class TalentUnitListVM : BasePagedListVM<TalentUnit_View, TalentUnitSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"TalentUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "TalentUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "TalentUnits", dialogWidth: 800),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "TalentUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "TalentUnits", dialogWidth: 800),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "TalentUnits", dialogWidth: 800),
                this.MakeStandardAction("TalentUnit", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "TalentUnits"),
            };
        }


        protected override IEnumerable<IGridColumn<TalentUnit_View>> InitGridHeader()
        {
            return new List<GridColumn<TalentUnit_View>>{
                this.MakeGridHeader(x => x.Name,120),
                this.MakeGridHeader(x => x.Category_view,120),
                this.MakeGridHeader(x => x.LicenseID,120).SetFormat(LicenseIDFormat),
                this.MakeGridHeader(x => x.Certificate,120),
                this.MakeGridHeader(x => x.DateOfFound,120),
                this.MakeGridHeader(x => x.Telephone,120),
                this.MakeGridHeader(x => x.Address,120),
                this.MakeGridHeader(x => x.Legal,120),
                this.MakeGridHeader(x => x.LegalMobile,120),
                this.MakeGridHeader(x => x.Manager,120),
                this.MakeGridHeader(x => x.ManagerMobile,120),
                //this.MakeGridHeader(x => x.ManagerPassword,120),
                this.MakeGridHeader(x => x.Description,220),
                this.MakeGridHeader(x => x.Status,100),
                this.MakeGridHeader(x => x.DateOfRegister,140),
                this.MakeGridHeader(x => x.AcceptanceComments,220),
                this.MakeGridHeader(x => x.DateOfAcceptance,140),
                this.MakeGridHeader(x => x.VerifyComments,220),
                this.MakeGridHeader(x => x.DateOfVerify,140),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> LicenseIDFormat(TalentUnit_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.LicenseID),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.LicenseID,640,480),
            };
        }


        public override IOrderedQueryable<TalentUnit_View> GetSearchQuery()
        {
            var query = DC.Set<TalentUnit>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.CategoryID, x=>x.CategoryID)
                .CheckContain(Searcher.Telephone, x=>x.Telephone)
                .CheckEqual(Searcher.Status, x=>x.Status)
                .Select(x => new TalentUnit_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Category_view = x.Category.Category,
                    LicenseID = x.LicenseID,
                    Certificate = x.Certificate,
                    DateOfFound = x.DateOfFound,
                    Telephone = x.Telephone,
                    Address = x.Address,
                    Legal = x.Legal,
                    LegalMobile = x.LegalMobile,
                    Manager = x.Manager,
                    ManagerMobile = x.ManagerMobile,
                    ManagerPassword = x.ManagerPassword,
                    Description = x.Description,
                    Status = x.Status,
                    DateOfRegister = x.DateOfRegister,
                    AcceptanceComments = x.AcceptanceComments,
                    DateOfAcceptance = x.DateOfAcceptance,
                    VerifyComments = x.VerifyComments,
                    DateOfVerify = x.DateOfVerify,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class TalentUnit_View : TalentUnit{
        [Display(Name = "类别")]
        public String Category_view { get; set; }

    }
}
