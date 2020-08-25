using MediatR;

namespace Chikisistema.Application.Security
{
    public interface IAlumnoRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
