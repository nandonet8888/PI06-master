using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Collections.Generic;

namespace PI06.Data.Models.Entity
{
    public class Consulta : EntityBase
    {
        [Required()]
        public Funcionario Funcionario { get; set; }

        [Required()]
        public Paciente Paciente { get; set; }

        public int IdPaciente { get; set; }

        [Required()]
        public DateTime dataInicio { get; set; }

        public DateTime? dataTermino { get; set; }

        [Required()]
        public string diagnostico { get; set; }
        [Required()]
        public string medicacao { get; set; }
        [Required()]
        public virtual ICollection<Exame> exames { get; set; }
        [Required()]
        public virtual ICollection<Procedimento> procedimentos {get; set;}


    }
}
