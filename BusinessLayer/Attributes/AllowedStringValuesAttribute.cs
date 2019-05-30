using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessLayer.Attributes
{
    public class AllowedStringValuesAttribute : ValidationAttribute
    {
        private readonly string[] _allowedValues;
        
        public AllowedStringValuesAttribute(string[] allowedValues)
        {
            _allowedValues = allowedValues;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (_allowedValues.Any(i => i.Equals((string)value)))
                return ValidationResult.Success;

            var errorMessage = $"Value not allowed. Allowed values are: {string.Join(", ", (_allowedValues ?? new [] { "No allowable values found" }))}.";
            return new ValidationResult(errorMessage);
        }
    }
}
