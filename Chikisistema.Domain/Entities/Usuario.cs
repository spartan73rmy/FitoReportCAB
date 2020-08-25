using Chikisistema.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Chikisistema.Domain.Entities
{
    public partial class Usuario : BaseEntity
    {
        public Usuario()
        {
            AlumnoCurso = new HashSet<AlumnoCurso>();
            ArchivoUsuario = new HashSet<ArchivoUsuario>();
            Curso = new HashSet<Curso>();
            MensajeIdUsuarioEnviaNavigation = new HashSet<Mensaje>();
            MensajeIdUsuarioRecibeNavigation = new HashSet<Mensaje>();
            UsuarioActividad = new HashSet<UsuarioActividad>();
            UsuarioTokens = new HashSet<UsuarioToken>();
            Comentarios = new HashSet<ComentarioActividad>();
            PostsForo = new HashSet<PostForo>();
        }

        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public TiposUsuario TipoUsuario { get; set; }
        public bool Confirmado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string TokenConfirmacion { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime LockoutEnd { get; set; }
        public string NormalizedUserName { get; set; }
        public string NormalizedEmail { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string ImagenPerfil { get; set; }

        public virtual ICollection<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual ICollection<ArchivoUsuario> ArchivoUsuario { get; set; }
        public virtual ICollection<Curso> Curso { get; set; }
        public virtual ICollection<Mensaje> MensajeIdUsuarioEnviaNavigation { get; set; }
        public virtual ICollection<Mensaje> MensajeIdUsuarioRecibeNavigation { get; set; }
        public virtual ICollection<UsuarioActividad> UsuarioActividad { get; set; }
        public virtual ICollection<UsuarioToken> UsuarioTokens { get; set; }

        public virtual ICollection<ComentarioActividad> Comentarios { get; set; }
        public virtual ICollection<PostForo> PostsForo { get; set; }
    }
}
