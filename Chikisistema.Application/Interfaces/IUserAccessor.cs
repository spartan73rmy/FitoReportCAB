using Chikisistema.Domain.Enums;

namespace Chikisistema.Application.Interfaces
{
    public interface IUserAccessor
    {
        int UserId { get; }
        bool IsAuthenticated { get; }
        TiposUsuario TipoUsuario { get; }
    }
}
