using FluentValidation.Results;
using System.Collections.Generic;

namespace Usuario.Business.Dtos
{
    public class Retorno
    {
        public Retorno()
        {
            mensagens = new List<string>();
        }

        public bool sucesso { get; set; }

        public IList<string> mensagens { get; set; }
    }
}
