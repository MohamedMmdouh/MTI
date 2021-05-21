using MTI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers
{
    public class Min16Years :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Students)validationContext.ObjectInstance;

            if (student.BirthDate == null)
            {
                return new ValidationResult("تاريخ الميلاد مطلوب");
            }

            var age = DateTime.Today.Year - student.BirthDate.Value.Year;

            return (age >= 16) ? ValidationResult.Success : new ValidationResult("يجب الا يقل عمر الطالب عن 16 سنه");

            return base.IsValid(value, validationContext);

        }
    }
}