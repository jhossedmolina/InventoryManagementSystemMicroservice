using DocumentTypesService.Core.DTOs;
using FluentValidation;

namespace DocumentTypesService.Infraestructure.Validators
{
    public class DocumentTypeValidator : AbstractValidator<DocumentTypeDto>
    {
        public DocumentTypeValidator()
        {
            RuleFor(dc => dc.Code)
                .NotEmpty()
                .Length(2, 5);

            RuleFor(dc => dc.Name)
                .NotEmpty()
                .Length(5, 20);
        }
    }
}
