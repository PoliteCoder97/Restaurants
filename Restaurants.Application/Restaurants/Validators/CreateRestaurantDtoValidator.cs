using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<String> _validCategories =
        ["Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(3, 100).WithMessage("Name must be between 3 and 100 characters.");

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(dto => dto.Category)
            .Must(category => _validCategories.Contains(category))
            .WithMessage($"Category must be one of the following: {string.Join(", ", _validCategories)}")
            // .Custom((value, context) =>
            // {
            //     var isValidCategory = _validCategories.Contains(value);
            //     if(!isValidCategory)
            //     {
            //         context.AddFailure("Category", $"Category must be one of the following: {string.Join(", ", _validCategories)}");
            //     }
            // })
            .NotEmpty().WithMessage("Category is required.");

        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Invalid email address format.")
            .When(dto => !string.IsNullOrEmpty(dto.ContactEmail));

        RuleFor(dto => dto.ContactNumber)
            .Matches(@"^\+?[0-9\s\-()]+$").WithMessage("Invalid phone number format.")
            .When(dto => !string.IsNullOrEmpty(dto.ContactNumber));

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}(-\d{3})?$").WithMessage("Invalid postal code format (XX-XXX).")
            .When(dto => !string.IsNullOrEmpty(dto.PostalCode));
    }
}