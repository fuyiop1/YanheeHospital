using System;
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

        public string PostAddress { get; set; }

        public string Telephone { get; set; }

        public string TherapyCardId { get; set; }

        public string ChineseName { get; set; }

        public int Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

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

        public string SleepTime { get; set; }

        public int ExpectedDietMedicineTherapy { get; set; }

        public double IdealWeight { get; set; }

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