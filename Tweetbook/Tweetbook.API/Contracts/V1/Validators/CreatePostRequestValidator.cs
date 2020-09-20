using FluentValidation;
using Tweetbook.API.Contracts.V1.Requests;

namespace Tweetbook.API.Contracts.V1.Validators
{
    public class CreatePostRequestValidator : AbstractValidator<CreatePostRequest>
    {
        public CreatePostRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
