using System.Collections.Generic;
using FluentValidation.Results;

namespace Notepad.Utilities.Validator.FluentValidation.Api
{
    public class FluentValidationFailure
    {
        public static Dictionary<string, string> ValidationFailures(List<ValidationFailure> validationFailures)
        {
            Dictionary<string, string> newItem = new Dictionary<string, string>();

            validationFailures.ForEach(x =>
            {
                if ( !newItem.ContainsKey(x.PropertyName) )
                {
                    newItem.Add(x.PropertyName, x.ErrorMessage);
                }
            });
            return newItem;
        }
    }
}