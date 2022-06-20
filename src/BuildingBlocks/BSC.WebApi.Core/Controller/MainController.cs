using BSC.Core.Communication;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BSC.WebApi.Core.Controller;

[ApiController]
public abstract class MainController : Microsoft.AspNetCore.Mvc.Controller
{
    protected ICollection<string> Errors = new List<string>();

    protected ActionResult CustomResponse(object? result = null)
    {
        if (ValidOperation())
        {
            return Ok(result);
        }

        return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
        {
            { "Messages", Errors.ToArray() }
        }));
    }

    protected ActionResult CustomResponse(ModelStateDictionary modelState)
    {
        var errors = modelState.Values.SelectMany(e => e.Errors);
        foreach (var error in errors)
        {
            AddProcessingError(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected ActionResult CustomResponse(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            AddProcessingError(error.ErrorMessage);
        }

        return CustomResponse();
    }

    protected ActionResult CustomResponse(ResponseResult response)
    {
        ResponseHasErrors(response);

        return CustomResponse();
    }

    protected bool ResponseHasErrors(ResponseResult response)
    {
        if (response == null || !response.Errors.Mensagens.Any()) return false;

        foreach (var mensagem in response.Errors.Mensagens)
        {
            AddProcessingError(mensagem);
        }

        return true;
    }

    protected bool ValidOperation()
    {
        return !Errors.Any();
    }

    protected void AddProcessingError(string erro)
    {
        Errors.Add(erro);
    }

    protected void ClearProcessingErrors()
    {
        Errors.Clear();
    }
}