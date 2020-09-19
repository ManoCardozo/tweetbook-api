using FluentValidation;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.API.Validators.V1
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
