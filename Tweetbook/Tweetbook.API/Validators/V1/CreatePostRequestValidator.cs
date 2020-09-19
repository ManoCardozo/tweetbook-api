using FluentValidation;
using Tweetbook.Contracts.V1.Requests;

namespace Tweetbook.API.Validators.V1
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
