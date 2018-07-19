using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Everis.Teste.Domain.Validation
{
    public class ValidationResult
    {
        private readonly List<ValidationError> _erros;
        private string Message { get; set; }
        public bool IsValid { get { return !_erros.Any(); } }
        public IEnumerable<ValidationError> Errors { get { return _erros; } }
        public int IddentityCurrent { get; set; }

        public ValidationResult()
        {
            _erros = new List<ValidationError>();
        }
    }
}
