﻿using MediatR;

namespace Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarEmail
{
    public class ConfirmarEmailCommand : IRequest<ConfirmarEmailResponse>
    {
        public string Token { get; set; }
    }
}