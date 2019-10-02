
using PI06.Data.Models.Entity;
using System.Collections.Generic;

namespace PI06.Models.Entity
{
    public class Paciente : EntityBase {
        public virtual ICollection<Consulta> Prontuarios { get; set; }

    }
}