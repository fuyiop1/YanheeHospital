﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace YanheeHospital.Models
{
    public class UserAnswer
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required(ErrorMessage = "请输入邮寄地址")]
        public string PostAddress { get; set; }

        [Required(ErrorMessage = "请输入电话号码")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "请输入正确格式的电话号码")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "请输入诊疗卡号")]
        public string TherapyCardId { get; set; }

        [Required(ErrorMessage = "请输入中文名字")]
        public string ChineseName { get; set; }

        public int Gender { get; set; }

        [Required(ErrorMessage = "请输入出生日期")]
        [DataType(DataType.Date, ErrorMessage = "请输入正确的日期格式")]
        public Nullable<DateTime> Birthdate { get; set; }

        [Required(ErrorMessage = "请输入身高")]
        [RegularExpression("^[-+]?\\d+(\\.\\d+)?$", ErrorMessage = "请输入身高数字（正数）")]
        public Nullable<double> Height { get; set; }

        [Required(ErrorMessage = "请输入体重")]
        [RegularExpression("^[-+]?\\d+(\\.\\d+)?$", ErrorMessage = "请输入体重数字（正数）")]
        public Nullable<double> Weight { get; set; }

        public int EatMostDinner { get; set; }

        public bool IsLikeSnack { get; set; }

        public bool IsAllergic { get; set; }

        public string AllergyDetail { get; set; }

        public bool HaveSeriousDesease { get; set; }

        //public string SeriousDeseaseDetail { get; set; }

        public bool HavePreviousDietMedicine { get; set; }

        public string PreviousDietMedicineDetail { get; set; }

        public string PreviousDietMedicineDuringTime { get; set; }

        public string PreviousDietMedicineStopTime { get; set; }

        public bool IsPreviousDietMedicineHaveSideEffect { get; set; }

        //public string PreviousDietMedicineSideEffectDetail { get; set; }

        public bool IsHavingOtherMedicine { get; set; }

        //public string OtherMedicineDetail { get; set; }

        public bool IsSmoking { get; set; }

        public bool IsDrinkingAlcohol { get; set; }

        public bool IsConstipate { get; set; }

        public bool IsInsomnic { get; set; }

        [Required(ErrorMessage = "请输入睡觉时间")]
        public string SleepTime { get; set; }
        
        [Required(ErrorMessage = "请输入需要购买的疗程")]
        [RegularExpression("^\\+?[1-9][0-9]*$", ErrorMessage = "请输入正整数")]
        public Nullable<int> ExpectedDietMedicineTherapy { get; set; }

        [Required(ErrorMessage = "请输入期望体重")]
        [RegularExpression("^[-+]?\\d+(\\.\\d+)?$", ErrorMessage = "请输入数字（正数）")]
        public Nullable<double> IdealWeight { get; set; }

        [Required(ErrorMessage = "请输入您想对医生说的话")]
        public string MessageToDoctor { get; set; }

    }

    public enum Gender
    {
        [Description("女")]
        Female,

        [Description("男")]
        Male
    }

    public enum Dinner
    {
        [Description("早餐")]
        Breakfast,

        [Description("午餐")]
        Lunch,

        [Description("晚餐")]
        Supper,

        [Description("夜宵")]
        MidnightSnack,

        [Description("其他")]
        Other
    }

}