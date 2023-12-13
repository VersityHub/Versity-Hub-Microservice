namespace ProductManagementService.Common.Generics;
public class Result<T>
{
    public Error Error { get; set; }
    public bool HasError => ErrorMessage != "";
    public string ErrorMessage { get; set; } = "";
    public string Message { get; set; } = "";
    public string RequestId { get; set; } = "";
    public bool IsSuccess { get; set; } = true;
    public DateTime RequestTime { get; set; } = DateTime.UtcNow;
    public DateTime ResponseTime { get; set; } = DateTime.UtcNow;

    public Result()
    {

    }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
    }

    public void SetError(string errorMessage, string messsage)
    {
        ErrorMessage = errorMessage;
        Message = messsage;
        IsSuccess = false;
    }

    public void SetSuccess(string messsage)
    {

        IsSuccess = true;
        Message = messsage;
    }
}

