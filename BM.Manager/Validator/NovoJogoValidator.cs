using BM.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Validator
{
    public class NovoJogoValidator:AbstractValidator<NovoJogo>
    {
        public NovoJogoValidator()
        {
            RuleFor(x => x.DataJogo).GreaterThan(DateTime.Now.AddDays(-1)).NotEmpty().NotNull();
        }
    }
}
