namespace Palyio.Domain;

public readonly record struct Result(string ErrorMessage = default)
{
    public bool Success => string.IsNullOrEmpty(ErrorMessage);
    public static implicit operator Result(string error) => new(error);
    public static implicit operator bool(Result result) => result.Success;
}

public readonly record struct Result<T>(T Value = default, string ErrorMessage = default)
{
    public bool Success => string.IsNullOrEmpty(ErrorMessage);
    public static implicit operator Result<T>(string error) => new(default, error);
    public static implicit operator Result<T>(T value) => new(value);
    public static implicit operator Result<T>(Result result) => new(default, result.ErrorMessage);
    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator bool(Result<T> result) => result.Success;
    public static implicit operator Result(Result<T> result) => new(result.ErrorMessage);


    public static Result operator -(Result<T> result) => new(result.ErrorMessage);
    public static T operator +(Result<T> result) => result.Value;
}
