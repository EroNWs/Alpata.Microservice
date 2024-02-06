using Meeting.Core.Utilities.Results.Interfaces;

namespace Meeting.Core.Utilities.Results.Concrete;

public class SuccessResult : Result
{
    public SuccessResult() : base(true)
    { }
    public SuccessResult(string message) : base(true, message)
    { }

}
