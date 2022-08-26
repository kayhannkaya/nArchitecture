using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>(); //IMediator nesnesinin instance ını döndür diyoruz.
        private IMediator? _mediator;

    }
}
