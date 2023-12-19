using BM.Core.Shared.ModelViews;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BM.Manager.Validator
{
    public class UpdateClubeValidator:AbstractValidator<UpdateClube>
    {
        public UpdateClubeValidator()
        {
             RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            Include(new NovoClubeValidator());
        }
    }
}
