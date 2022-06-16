using BSC.Core.Data;
using FluentValidation.Results;

namespace BSC.Core.Messages;

public abstract class CommandHandler
{
    protected ValidationResult ValidationResult;

    protected CommandHandler()
    {
        ValidationResult = new ValidationResult();
    }

    protected void AddError(string mensagem)
    {
        ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
    }

    protected async Task<ValidationResult> SaveData(IUnitOfWork uow)
    {
        if (!await uow.Commit()) AddError("There was a error when try to add the data");

        return ValidationResult;
    }
}