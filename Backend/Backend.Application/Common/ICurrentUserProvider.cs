using Backend.Application.Common.Models;

namespace Backend.Application.Common;

public interface ICurrentUserProvider
{
    CurrentUser GetCurrentUser();
}