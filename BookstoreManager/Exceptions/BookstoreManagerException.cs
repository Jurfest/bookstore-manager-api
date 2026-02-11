using System.Net;

namespace BookstoreManager.Exceptions;

public abstract class BookstoreManagerException : SystemException
{
    public BookstoreManagerException(string errorMessage) : base(errorMessage)
    {
            
    }

    public abstract List<string> GetErrors();
        
    public abstract HttpStatusCode GetHttpStatusCode();
}