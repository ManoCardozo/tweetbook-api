using FluentValidation;
using Tweetbook.API.Contracts.V1.Requests;

namespace Tweetbook.API.Contracts.V1.Validators
{
    public class UpdatePostRequestValidator : AbstractValidator<UpdatePostRequest>
    {
        public UpdatePostRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
