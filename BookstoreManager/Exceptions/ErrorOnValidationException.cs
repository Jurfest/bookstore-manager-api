using System.Net;

namespace BookstoreManager.Exceptions;

public class ErrorOnValidationException : BookstoreManagerException
{
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errorMessages) : base(string.Empty)
        {
            _errors = errorMessages;
        }

        // Long syntax
        // public override List<string> GetErrors()
        // {
        //     return _errors;
        // }
        // Short syntax
        public override List<string> GetErrors() => _errors;
        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.BadRequest;
}