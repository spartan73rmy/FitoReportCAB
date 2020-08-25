using FluentValidation;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetMaestrosNoConfirmados
{
    public class GetMaestrosNoConfirmadosValidator : AbstractValidator<GetMaestrosNoConfirmadosQuery>
    {
        public GetMaestrosNoConfirmadosValidator()
        {
        }
    }
}