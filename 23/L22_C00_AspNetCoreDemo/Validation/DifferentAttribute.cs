using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace L22_C00_AspNetCoreDemo.Validation
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	[SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes", Justification = "This attribute is designed to be a base class for other attributes.")]
	public class DifferentAttribute : ValidationAttribute
	{
		public DifferentAttribute(string otherProperty)
		{
			if (otherProperty == null)
			{
				throw new ArgumentNullException("otherProperty");
			}
			OtherProperty = otherProperty;
		}

		public string OtherProperty { get; private set; }

		public override bool RequiresValidationContext
		{
			get
			{
				return true;
			}
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
			if (otherPropertyInfo == null)
			{
				return new ValidationResult($"Cannot find other property {OtherProperty}");
			}

			object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
			if (Equals(value, otherPropertyValue))
			{				
				return new ValidationResult($"{validationContext.MemberName} should not have the same value as {OtherProperty}");
			}
			return ValidationResult.Success;
		}

	}
}
