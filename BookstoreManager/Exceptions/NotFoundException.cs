using System.Net;

namespace BookstoreManager.Exceptions;

public class NotFoundException : BookstoreManagerException
{
    public NotFoundException(string errorMessage) : base(errorMessage)
    {
        
    }

    public override List<string> GetErrors() => [Message];
    
    public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
}