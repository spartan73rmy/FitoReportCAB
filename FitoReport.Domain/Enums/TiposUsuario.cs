namespace FitoReport.Domain.Enums
{
    public enum TiposUsuario
    {
        Publico = 1, //Puede consultar un reporte
        Productor = 2, //Puede consultar sus estadisticas, portafolio, reportes.
        User = 3, //Puede crear, editar, ver y compartir reportes. Puede ver portafolio?
        Admin = 4 //Aprueba usuarios, Acceso total
    }
}
