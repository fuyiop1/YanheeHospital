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
                switch (propertyDescriptor.Name)
                {
                    case "Height":
                    case "Weight":
                    case "ExpectedDietMedicineTherapy":
                    case "IdealWeight":
                        RegularExpressionAttribute regularExpressionAttribute = null;
                        try
                        {
                            regularExpressionAttribute = propertyDescriptor.Attributes[typeof(RegularExpressionAttribute)] as RegularExpressionAttribute;
                        }
                        catch (Exception)
                        {
                        }
                        if (regularExpressionAttribute != null)
                        {
                            bindingContext.ModelState.AddModelError("UserAnswer." + propertyDescriptor.Name, regularExpressionAttribute.ErrorMessage);
                        }
                        break;
                    case "Birthdate":
                        DataTypeAttribute dataTypeAttribute = null;
                        try
                        {
                            dataTypeAttribute = propertyDescriptor.Attributes[typeof(DataTypeAttribute)] as DataTypeAttribute;
                        }
                        catch (Exception)
                        {
                        }
                        if (dataTypeAttribute != null)
                        {
                            bindingContext.ModelState.AddModelError("UserAnswer." + propertyDescriptor.Name, dataTypeAttribute.ErrorMessage);
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }
        protected override void OnModelUpdated(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            base.OnModelUpdated(controllerContext, bindingContext);
        }
    }
}