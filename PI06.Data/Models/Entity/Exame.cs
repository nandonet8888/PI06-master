using PI06.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PI06.Data.Models.Entity
{
   public  class Exame : EntityBase
    {
    
        public string resultado { get; set; }
        public TipoExame tipoExame { get; set; }
       
        public Consulta consultas { get; set; }


           public Procedimento procedimento { get; set; }

    }
}
