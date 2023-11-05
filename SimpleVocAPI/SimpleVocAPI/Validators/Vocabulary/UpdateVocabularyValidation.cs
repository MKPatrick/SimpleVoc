using FluentValidation;
using SimpleVocAPI.DTO.Vocabulary;

namespace SimpleVocAPI.Validators.Vocabulary
{
    public class UpdateVocabularyValidation : AbstractValidator<UpdateVocabularyRequest>
    {
        public UpdateVocabularyValidation()
        {
            RuleFor(voc => voc.Translation).NotEmpty().WithMessage("Your translation is not allowed to be empty!");
            RuleFor(voc => voc.Original).NotEmpty().WithMessage("Your translation is not allowed to be empty!");
        }
    }
}
