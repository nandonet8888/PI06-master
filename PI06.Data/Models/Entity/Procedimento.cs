using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
    public class Procedimento : EntityBase
    {
        public string observacao{ get; set;}
        public Exame exame { get; set; }

        public TipoProcedimento TipoProcedimento { get; set; }

        public Consulta consulta { get; set; }

        public Cirurgia cirurgia { get; set; }

        public int idProcedimento { get; set; }


    }
}
