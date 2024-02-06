namespace Meeting.Core.Utilities.Results.Interfaces;

public interface IResult
{
    bool IsSuccess { get; }
    string Message { get; }
}
