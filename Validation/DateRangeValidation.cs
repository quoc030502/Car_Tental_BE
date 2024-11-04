using System;
using System.ComponentModel.DataAnnotations;

namespace basic_api.Validation
{
    public class DateRangeValidationAttribute(string comparisonProperty) : ValidationAttribute
    {
        private readonly string _comparisonProperty = comparisonProperty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDate = (DateTime)value;

            var endDateProperty = validationContext.ObjectType.GetProperty(_comparisonProperty) ?? throw new ArgumentException("Property with this name not found");

            var endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

            if (startDate >= endDate)
            {
                return new ValidationResult("StartDate or EndDate must be valid");
            }

            return ValidationResult.Success;
        }
    }
}