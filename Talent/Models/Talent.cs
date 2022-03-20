using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace Talent.Models
{
    /// <summary>
    /// 高层次人才
    /// </summary>
    [Table("Talents")]
    public class Talent : BasePoco
    {
        [Display(Name = "姓名"), StringLength(20), Required]
        public string Name { get; set; }

        [Display(Name = "性别"), Required]
        public EnumSex Sex { get; set; }

        [Display(Name = "手机号码"), StringLength(20), Required]
        public string Mobile { get; set; }

        [Display(Name = "登录密码"), StringLength(50), Required]
        public string Password { get; set; }
        
        [Display(Name = "出生日期"), Required]
        public DateTime Birth { get; set; }

        [Display(Name = "民族"), Required]
        public string Nation { get; set; }

        [Display(Name = "籍贯"), StringLength(30), Required]
        public string HomeTown { get; set; }

        [Display(Name = "政治面貌"), Required]
        public EnumPolitical Political { get; set; }

        [Display(Name = "职务"), StringLength(30), Required]
        public string JobTitle { get; set; }

        [Display(Name = "行业类别"), Required]
        public Guid IndustryCategoryID { get; set; }
        public IndustryCategory IndustryCategory { get; set; }

        [Display(Name = "引进前工作单位"), StringLength(100), Required]
        public string FormerWorkplace { get; set; }

        [Display(Name = "单位地址"), StringLength(200), Required]
        public string WorkplaceAddress { get; set; }

        [Display(Name = "最高学历"), Required]
        public EnumEducation HighestEducation { get; set; }

        [Display(Name = "所学专业"), StringLength(50), Required]
        public string Major { get; set; }

        [Display(Name = "毕业院校"), StringLength(100), Required]
        public string GraduatedSchool { get; set; }

        [Display(Name = "毕业时间"), Required]
        public DateTime GraduationTime { get; set; }

        [Display(Name = "技术职称"), StringLength(50)]
        public string TechnicalTitles { get; set; }

        [Display(Name = "取得时间")]
        public DateTime? GetTime { get; set; }

        [Display(Name = "合同类型"), Required]
        public EnumLaborContractPeriod? LaborContractPeriod { get; set; }

        [Display(Name = "劳动合同期限")]
        public DateTime? LaborContractExpired { get; set; }

        [Display(Name = "证件类型"), Required]
        public EnumDocumentType TypeOfDocument { get; set; }

        [Display(Name = "证件"),StringLength(30), Required]
        public string IDNumber { get; set; }

        [Display(Name = "申报条件"), Required]
        public string DeclarationConditions { get; set; }

        [Display(Name = "主要教育经历"), Required]
        public string EducationalExperience { get; set; }

        [Display(Name = "主要工作经历"), Required]
        public string WorkExperience { get; set; }

        [Display(Name = "主要业绩和创新成果"), Required]
        public string MainAchievement { get; set; }

        [Display(Name = "工作设想"), Required]
        public string WorkAssumptions { get; set; }

        [Display(Name = "审核状态"), Required]
        public EnumTalentStatus Status { get; set; }

        [Display(Name = "注册时间"), Required]
        public DateTime DateOfRegister { get; set; }

        [Display(Name = "申报单位意见")]
        public string UnitComments { get; set; }

        [Display(Name = "支持条件")]
        public string Support { get; set; }

        [Display(Name = "申报日期")]
        public DateTime? DateOfApply { get; set; }

        [Display(Name = "受理部门意见")]
        public string AcceptanceComments { get; set; }

        [Display(Name = "受理日期")]
        public DateTime? DateOfAcceptance { get; set; }

        [Display(Name = "审核部门意见")]
        public string VerifyComments { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? DateOfVerify { get; set; }
    }
}
