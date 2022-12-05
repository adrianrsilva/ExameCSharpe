using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class RetornoDTO<T>
    {

        public bool Status { get; set; }

        public string Erro { get; set; }

        public string Mensagem { get; set; }

        public T Resultado { get; set; }

        //public dynamic Result { get; set; }

    }
}
