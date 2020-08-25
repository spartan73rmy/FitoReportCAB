using Chikisistema.Common;
using System;

namespace Chikisistema.Infraestructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
