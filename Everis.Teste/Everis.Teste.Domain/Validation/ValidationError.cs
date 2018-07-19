using System;
using System.Collections.Generic;
using System.Text;

namespace Everis.Teste.Domain.Validation
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
