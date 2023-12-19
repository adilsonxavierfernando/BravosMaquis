using BM.Core.Shared.ModelViews;
using BravosMaquis.Models.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Validator
{
    public class NovoClubeValidator:AbstractValidator<NovoClube>
    {
        public NovoClubeValidator()
        {
            RuleFor(x => x.Clube)
                .NotNull()
                .NotEmpty()
                .MinimumLength(25)
                .MaximumLength(100).WithMessage("Verifique o nome do clube, não pode ser muito curto, vazio, nulo ou muito longo");

            RuleFor(x => x.Emblema)
               .NotNull()
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(15)
               .Matches("^[a-zA-Z0-9_]+\\.(jpeg|png|jpg|tiff|gif)$");
            RuleFor(x => x.Sigla)
               .NotNull()
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(8).WithMessage("A sigla não deve ser vazia, nula, ou muito longa");
           ;

        }
    }
}
