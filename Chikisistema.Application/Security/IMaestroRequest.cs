using MediatR;

namespace Chikisistema.Application.Security
{
    public interface IMaestroRequest<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
