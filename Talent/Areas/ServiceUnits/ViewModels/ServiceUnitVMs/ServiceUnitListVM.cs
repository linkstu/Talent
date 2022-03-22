using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Talent.Models;


namespace Talent.ServiceUnits.ViewModels.ServiceUnitVMs
{
    public partial class ServiceUnitListVM : BasePagedListVM<ServiceUnit_View, ServiceUnitSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.Create, Localizer["Sys.Create"],"ServiceUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.Edit, Localizer["Sys.Edit"], "ServiceUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.Delete, Localizer["Sys.Delete"], "ServiceUnits", dialogWidth: 800),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.Details, Localizer["Sys.Details"], "ServiceUnits", dialogWidth: 800).SetShowDialog(false).SetIsRedirect(),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.BatchDelete, Localizer["Sys.BatchDelete"], "ServiceUnits", dialogWidth: 800),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.Import, Localizer["Sys.Import"], "ServiceUnits", dialogWidth: 800),
                this.MakeStandardAction("ServiceUnit", GridActionStandardTypesEnum.ExportExcel, Localizer["Sys.Export"], "ServiceUnits"),
            };
        }


        protected override IEnumerable<IGridColumn<ServiceUnit_View>> InitGridHeader()
        {
            return new List<GridColumn<ServiceUnit_View>>{
                this.MakeGridHeader(x => x.Name,120),
                this.MakeGridHeader(x => x.Type,120),
                this.MakeGridHeader(x => x.LicenseID,140).SetFormat(LicenseIDFormat),
                this.MakeGridHeader(x => x.Status,100),
                this.MakeGridHeader(x => x.Certificate,140),
                this.MakeGridHeader(x => x.DateOfFound,140),
                this.MakeGridHeader(x => x.Telephone,120),
                this.MakeGridHeader(x => x.Address,200),
                this.MakeGridHeader(x => x.Legal,120),
                this.MakeGridHeader(x => x.LegalMobile,140),
                this.MakeGridHeader(x => x.Manager,120),
                this.MakeGridHeader(x => x.ManagerMobile,120),
                //this.MakeGridHeader(x => x.ManagerPassword),
                this.MakeGridHeader(x => x.Description,200),
                this.MakeGridHeader(x => x.DateOfRegister,140),
                this.MakeGridHeader(x => x.AcceptanceComments,200),
                this.MakeGridHeader(x => x.DateOfAcceptance,140),
                this.MakeGridHeader(x => x.VerifyComments,200),
                this.MakeGridHeader(x => x.DateOfVerify,140),

                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> LicenseIDFormat(ServiceUnit_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.LicenseID),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.LicenseID,640,480),
            };
        }


        public override IOrderedQueryable<ServiceUnit_View> GetSearchQuery()
        {
            var query = DC.Set<ServiceUnit>()
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.Type, x => x.Type)
                .CheckEqual(Searcher.Status, x => x.Status)
                .Select(x => new ServiceUnit_View
                {
                    ID = x.ID,
                    Name = x.Name,
                    Type = x.Type,
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

    public class ServiceUnit_View : ServiceUnit
    {

    }
}
