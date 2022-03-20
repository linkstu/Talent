﻿using System;
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
    public class ServiceUnit
    {
        [Display(Name ="单位名称"), StringLength(100), Required]
        public string Name { get; set; }

        [Display(Name = "服务类别"), Required]
        public EnumServiceType Type { get; set; }

        [Display(Name = "单位地址"), StringLength(200), Required]
        public string Address { get; set; }

        [Display(Name = "负责人"), StringLength(20), Required]
        public string InCharge { get; set; }

        [Display(Name = "负责人电话"), StringLength(20), Required]
        public string InChargeTel { get; set; }

        [Display(Name = "联系人"), StringLength(20), Required]
        public string Contacts { get; set; }

        [Display(Name = "联系人电话"), StringLength(20), Required]
        public string ContactTel { get; set; }

        [Display(Name ="登录账号"), StringLength(20, MinimumLength =6), Required]
        public string Account { get; set; }

        [Display(Name ="登录密码"), StringLength(50), Required]
        public string Password { get; set; }

        [Display(Name ="单位介绍"), StringLength(2000), Required]
        public string Description { get; set; }

        //  相关附件，可多文件
        [Display(Name ="相关附件")]
        public List<ServiceUnitDocument> Documents { get; set; }

        [Display(Name = "状态"), Required]
        public EnumUnitStatus Status { get; set; }

        /*
         * 修改日期，修改人，创建日期
         * 从基类中调取
         * UpdateTime,UpdateBy,CreateTime
         */
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
