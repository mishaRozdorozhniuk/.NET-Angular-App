using System;
namespace ApiAds.Abstract;

public class DataServiceMessage
{
    public bool IsSuccess { get; set; } = false;
    public string MainMessage { get; set; } = string.Empty;
    public object? Data { get; set; }

    public DataServiceMessage() { }

    public DataServiceMessage(bool isSuccess, string mainMessage, object? data)
    {
        IsSuccess = isSuccess;
        MainMessage = mainMessage;
        Data = data;
    }

    public DataServiceMessage(bool isSuccess, object? data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }

    public DataServiceMessage(bool isSuccess, string mainMessage) : this(isSuccess, mainMessage, default) { }
}
