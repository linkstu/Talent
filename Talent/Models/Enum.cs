using System.ComponentModel.DataAnnotations;

namespace Talent.Models
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum EnumSex
    {
        [Display(Name = "男")]
        Male,
        [Display(Name = "女")]
        Female,
        //  此项不要
        //[Display(Name = "未知")]
        //Unknow,
    }
    
    /// <summary>
    /// 合同类型
    /// </summary>
    public enum EnumLaborContractPeriod
    {
        [Display(Name = "固定期限")]
        Fix,
        [Display(Name = "无固定期限")]
        Flex,
        [Display(Name = "创业者")]
        Starter
    }

    /// <summary>
    /// 证件类型
    /// </summary>
    public enum EnumDocumentType
    {
        [Display(Name = "身份证")]
        IdNum,
        [Display(Name = "护照")]
        Passport,
    }

    /// <summary>
    /// 政治面貌
    /// </summary>
    public enum EnumPolitical
    {
        [Display(Name = "中共党员")]
        P01,
        [Display(Name = "中共预备党员")]
        P02,
        [Display(Name = "共青团员")]
        P03,
        [Display(Name = "民革会员")]
        P04,
        [Display(Name = "民盟盟员")]
        P05,
        [Display(Name = "民建会员")]
        P06,
        [Display(Name = "民进会员")]
        P07,
        [Display(Name = "农工党党员")]
        P08,
        [Display(Name = "致公党党员")]
        P09,
        [Display(Name = "九三学社社员")]
        P10,
        [Display(Name = "台盟盟员")]
        P11,
        [Display(Name = "无党派民主人士")]
        P12,
        [Display(Name = "群众")]
        P13,
    }

    /// <summary>
    /// 学历
    /// </summary>
    public enum EnumEducation
    {
        [Display(Name = "专科")]
        E01,
        [Display(Name = "本科")]
        E02,
        [Display(Name = "研究生")]
        E03,
        [Display(Name = "博士")]
        E04,
    }

    /// <summary>
    /// 人才审核状态
    /// </summary>
    public enum EnumTalentStatus
    {
        [Display(Name = "未提交")]
        Draft,
        [Display(Name = "待受理")]
        WaitingAccept,
        [Display(Name = "受理退回")]
        RejectAccept,
        [Display(Name = "已受理")]
        Accepted,
        [Display(Name = "待审核")]
        WaitingVerify,
        [Display(Name = "审核退回")]
        RejectVerify,
        [Display(Name = "已审核")]
        Verified,
    }

    /// <summary>
    /// 单位状态
    /// </summary>
    public enum EnumUnitStatus
    {
        [Display(Name = "待审核")]
        Waiting,
        [Display(Name = "已审核")]
        Verified,
        [Display(Name = "审核不通过")]
        Failed,
        [Display(Name = "锁定")]
        Locked,
        [Display(Name = "注销")]
        Canceled,
    }

    /// <summary>
    /// 服务性质
    /// </summary>
    public enum EnumServiceType
    {
        [Display(Name = "计价")]
        ByValuation,
        [Display(Name = "计次")]
        ByCount
    }
}
