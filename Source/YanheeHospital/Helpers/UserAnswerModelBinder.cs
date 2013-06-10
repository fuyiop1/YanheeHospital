using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YanheeHospital.Helpers
{
    public class UserAnswerModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext,
               ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor,
               object value)
        {
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
            if (!bindingContext.ModelState.IsValidField("UserAnswer." + propertyDescriptor.Name))
            {
                var errorMessage = string.Empty;
                switch (propertyDescriptor.Name)
                {
                    case "Height":
                        errorMessage = "请输入身高数值";
                        break;
                    case "Weight":
                        errorMessage = "请输入体重数值";
                        break;
                    case "ExpectedDietMedicineTherapy":
                        errorMessage = "请输入数值";
                        break;
                    case "IdealWeight":
                        errorMessage = "请输入理想体重数值";
                        break;
                    default:
                        break;
                }
                bindingContext.ModelState.AddModelError(string.Format("{0}.{1}", bindingContext.ModelName, propertyDescriptor.Name), errorMessage);
            }
            
        }
        protected override void OnModelUpdated(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
}