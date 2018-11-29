
using System;
using System.ComponentModel.DataAnnotations;

namespace VideoStore.Models
{
    public class if18YearsOlder : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.unNown|| customer.MembershipTypeId == MembershipType.free)
                return ValidationResult.Success;

            if (customer.CustomerBirthday == null)
                return new ValidationResult("Age is required!");


            return ValidationResult.Success;
        }
    }
}