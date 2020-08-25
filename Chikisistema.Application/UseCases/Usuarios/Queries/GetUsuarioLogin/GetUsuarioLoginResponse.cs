﻿using Chikisistema.Domain.Enums;

namespace Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginResponse
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public string RefreshToken { get; set; }
    }
}