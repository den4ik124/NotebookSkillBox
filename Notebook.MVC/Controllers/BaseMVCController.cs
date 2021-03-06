using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Notebook.Application.Core;

namespace Notebook.MVC.Controllers
{
    public class BaseMVCController : Controller
    {
        private IMediator mediator;

        protected IMediator Mediator => this.mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess && result.Value != null)
            {
                return View(result.Value);
            }
            if (result.IsSuccess && result.Value == null)
            {
                return Redirect("/");
            }
            return BadRequest(result.Error);
        }
    }
}