using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Talent.Models;


namespace Talent.ServiceUnits.ViewModels.ServiceUnitVMs
{
    public partial class ServiceUnitTemplateVM : BaseTemplateVM
    {
        [Display(Name = "单位名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Name);
        [Display(Name = "服务类别")]
        public ExcelPropety Type_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Type);
        [Display(Name = "组织机构代码")]
        public ExcelPropety Certificate_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Certificate);
        [Display(Name = "注册/成立时间")]
        public ExcelPropety DateOfFound_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.DateOfFound);
        [Display(Name = "联系电话")]
        public ExcelPropety Telephone_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Telephone);
        [Display(Name = "单位地址")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Address);
        [Display(Name = "法人姓名")]
        public ExcelPropety Legal_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Legal);
        [Display(Name = "法人手机")]
        public ExcelPropety LegalMobile_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.LegalMobile);
        [Display(Name = "管理员姓名")]
        public ExcelPropety Manager_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Manager);
        [Display(Name = "管理员手机")]
        public ExcelPropety ManagerMobile_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.ManagerMobile);
        [Display(Name = "登录密码")]
        public ExcelPropety ManagerPassword_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.ManagerPassword);
        [Display(Name = "单位介绍")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Description);
        [Display(Name = "状态")]
        public ExcelPropety Status_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.Status);
        [Display(Name = "注册日期")]
        public ExcelPropety DateOfRegister_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.DateOfRegister);
        [Display(Name = "受理部门意见")]
        public ExcelPropety AcceptanceComments_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.AcceptanceComments);
        [Display(Name = "受理日期")]
        public ExcelPropety DateOfAcceptance_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.DateOfAcceptance);
        [Display(Name = "审核部门意见")]
        public ExcelPropety VerifyComments_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.VerifyComments);
        [Display(Name = "审核日期")]
        public ExcelPropety DateOfVerify_Excel = ExcelPropety.CreateProperty<ServiceUnit>(x => x.DateOfVerify);

	    protected override void InitVM()
        {
        }

    }

    public class ServiceUnitImportVM : BaseImportVM<ServiceUnitTemplateVM, ServiceUnit>
    {

    }

}
