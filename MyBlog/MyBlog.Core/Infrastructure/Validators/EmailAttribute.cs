using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Core.Infrastructure.Validators
{
    public class EmailAttribute : ValidationAttribute
    {
        private Regex Regex { get; set; }

        public string Pattern
        {
            get
            {
                return
                    @"^([0-9a-zA-Z]+[-._+&])*[0-9a-zA-Z]+@([-0-9a-zA-Z]+[.])+[a-zA-Z]{2,6}$";
            }
        }

        public EmailAttribute()
        {
            this.Regex = new Regex(this.Pattern, RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        }

        public override bool IsValid(object value)
        {
            // convert the value to a string
            var stringValue = Convert.ToString(value, CultureInfo.CurrentCulture);

            // automatically pass if value is null or empty. RequiredAttribute should be used to assert an empty value.
            if (string.IsNullOrWhiteSpace(stringValue)) return true;

            return Regex.IsMatch(stringValue);
        }
    }
}
