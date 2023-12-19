using BM.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Validator
{
    public class AtualizarJogoValidator:AbstractValidator<AtualizarJogo>
    {
        public AtualizarJogoValidator()
        {
             RuleFor(x=>x.Id).NotEmpty().GreaterThan(0).NotNull();
            Include(new NovoJogoValidator());
        }
    }
}
