using MediatR;

namespace FitoReport.Application.Security
{
    interface INotAuth<TRequest, TResponse> : IAuthenticatedRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }
}
