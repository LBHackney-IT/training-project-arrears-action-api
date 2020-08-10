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
        public string Status { get; set; } = "fail";
        public List<string> Errors { get; set; }

        public ErrorResponse()
        {
            Errors = new List<string>();
        }

        public ErrorResponse(List<string> errorList)
        {
            Errors = errorList;
        }

        public ErrorResponse(params string[] errorStrings)
        {
            Errors = errorStrings.ToList();
        }

        public ErrorResponse(IList<ValidationFailure> validationFailures)
        {
            Errors = ErrorMessagesFormatter.FormatValidationFailures(validationFailures);
        }
    }
}
