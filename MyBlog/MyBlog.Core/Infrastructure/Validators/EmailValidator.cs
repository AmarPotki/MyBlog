using System.Collections.Generic;
using System.Web.Mvc;

namespace MyBlog.Core.Infrastructure.Validators
{
    public class EmailValidator : DataAnnotationsModelValidator<EmailAttribute>
    {
        private readonly string _errorMessage;
        private readonly string _pattern;

        public EmailValidator(ModelMetadata metadata, ControllerContext context, EmailAttribute attribute)
            : base(metadata, context, attribute)
        {
            this._errorMessage = attribute.ErrorMessage ?? "Email is not a valid format";
            this._pattern = attribute.Pattern;
        }

        //public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        //{
        //    var rule = new ModelClientValidationRegexRule(this._errorMessage, this._pattern);
        //    return new[] { rule };
        //}
    }
}
