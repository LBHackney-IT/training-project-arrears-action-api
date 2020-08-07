using ArrearsActionAPI.V1.Helpers;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace ArrearsActionAPI.V1.Errors
{
    /// <summary>
    /// This is an Error Object that conforms to Hackney's API Playbook standards:
    ///
    ///     {
    ///        "status" : "fail",
    ///        "errors" : [ "A title is required" ]
    ///     }
    ///
    /// Defined at: "https://github.com/LBHackney-IT/API-Playbook-v2-beta/blob/master/api-guidelines/data-formats.md"
    /// </summary>

    public class ErrorResponse
    {
        public string status { get; set; } = "fail";
        public List<string> errors { get; set; }

        public ErrorResponse()
        {
            errors = new List<string>();
        }

        public ErrorResponse(List<string> errorList)
        {
            errors = errorList;
        }

        public ErrorResponse(params string[] errorStrings)
        {
            errors = errorStrings.ToList();
        }

        public ErrorResponse(IList<ValidationFailure> validationFailures)
        {
            errors = ErrorMessagesFormatter.FormatValidationFailures(validationFailures);
        }
    }
}
