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
    /// 单位状态
    /// </summary>
    public enum EnumUnitStatus
    {
        [Display(Name = "待审核")]
        Waiting,
        [Display(Name = "已审核")]
        Approved,
        [Display(Name = "审核不通过")]
        Failed,
        [Display(Name = "停用")]
        Stopped,
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
