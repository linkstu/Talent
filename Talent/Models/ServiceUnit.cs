using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /// <summary>
    /// 服务单位
    /// </summary>
    [Table("ServiceUnits")]
    public class ServiceUnit : BasePoco
    {
        [Display(Name ="单位名称"), StringLength(100), Required]
        public string Name { get; set; }

        [Display(Name = "服务类别"), Required]
        public EnumServiceType Type { get; set; }

        [Display(Name = "营业执照"), Required]
        public Guid LicenseID { get; set; }
        public FileAttachment License { get; set; }

        [Display(Name = "组织机构代码"), StringLength(100), Required]
        public string Certificate { get; set; }

        [Display(Name = "注册/成立时间"), Required]
        public DateTime DateOfFound { get; set; }

        [Display(Name = "联系电话"), StringLength(20), Required]
        public string Telephone { get; set; }

        [Display(Name = "单位地址"), StringLength(200), Required]
        public string Address { get; set; }

        [Display(Name = "法人姓名"), StringLength(20), Required]
        public string Legal { get; set; }

        [Display(Name = "法人手机"), StringLength(20), Required]
        public string LegalMobile { get; set; }

        [Display(Name = "管理员姓名"), StringLength(20), Required]
        public string Manager { get; set; }

        [Display(Name ="管理员手机"), StringLength(20), Required]
        public string ManagerMobile { get; set; }

        [Display(Name ="登录密码"), StringLength(50), Required]
        public string ManagerPassword { get; set; }

        [Display(Name ="单位介绍"), StringLength(2000), Required]
        public string Description { get; set; }

        //  相关附件，可多文件
        [Display(Name ="相关附件")]
        public List<ServiceUnitDocument> Documents { get; set; }

        [Display(Name = "状态"), Required]
        public EnumUnitStatus Status { get; set; }

        [Display(Name = "注册日期"), Required]
        public DateTime DateOfRegister { get; set; }

        [Display(Name = "受理部门意见")]
        public string AcceptanceComments { get; set; }

        [Display(Name = "受理日期")]
        public DateTime? DateOfAcceptance { get; set; }

        [Display(Name = "审核部门意见")]
        public string VerifyComments { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? DateOfVerify { get; set; }
    }

    /// <summary>
    /// 服务单位-相关附件
    /// </summary>
    [Table("ServiceUnitDocuments")]
    public class ServiceUnitDocument : TopBasePoco, ISubFile
    {
        [Display(Name = "服务单位"), Required]
        public Guid ServiceUnitID { get; set; }
        public ServiceUnit ServiceUnit { get; set; }

        [Display(Name = "附件"), Required]
        public Guid FileId { get; set; }
        public FileAttachment File { get; set; }
        public int Order { get; set; }
    }
}
