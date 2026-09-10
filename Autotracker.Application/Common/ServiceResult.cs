
namespace Autotracker.Application.Common
{
    public record ServiceResult(bool Success, string Message, object? Data = null);
}
