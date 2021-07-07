using FluentValidation;
using System;

namespace Monitor.Dashboard.Dashboard.Commands.SaveSalesTarget
{
    public class SaveSalesTargetValidator : AbstractValidator<SaveSalesTargetCommand>
    {
        public SaveSalesTargetValidator()
        {
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Model.Year).NotEmpty().Must( y => y >= DateTime.Now.Year);
            RuleFor(x => x.Model.Month).NotEmpty().Must(m => m > 0 && m <= 12);
            RuleFor(x => x.Model).Must(m => {
                if (DateTime.Now.Year == m.Year && DateTime.Now.Month <= m.Month || DateTime.Now.Year < m.Year)
                {
                    return true;
                }
                return false;
            });
            RuleFor(x => x.Model.PlannedSalesSumm).NotEmpty().Must(s => s >= 0);
        }
    }
}
