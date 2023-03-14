#region MyRegion
namespace Domain.Exceptions;

#endregion
public class ApiToReturn
{
    #region Properties
    public string message { get; set; }
    public int statusCode { get; set; }
    public string detail { get; set; }
    public List<string> messages { get; set; } = new();
    #endregion

    #region Ctors
    public ApiToReturn()
    {
        
    }
    public ApiToReturn(string _message)
    {
        message = _message;
        messages.Add(message);

    }
    public ApiToReturn(string _message, int _statusCode)
    {
        message = _message;
        statusCode = _statusCode;
        messages.Add(_message);
    }
    public ApiToReturn(string _message, int _statusCode, string _detail)
    {
        statusCode = _statusCode;
        detail = _detail;
        message = _message;
        messages.Add(_message);
    }  
    public ApiToReturn(List<string> _messages, int _statusCode)
    {
        messages = _messages;
        statusCode = _statusCode;
    }  
    public ApiToReturn(List<string> _messages, int _statusCode, string _detail)
    {

        statusCode = _statusCode;
        detail = _detail;
        messages = _messages;
    }   
    public ApiToReturn(List<string> _messages, string _message, int _statusCode, string _detail)
    {
        message = _message;
        statusCode = _statusCode;
        detail = _detail;
        messages = _messages;
    }
    #endregion
}