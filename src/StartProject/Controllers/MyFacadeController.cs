using Microsoft.AspNetCore.Mvc;
using MyApplication.Module.Facade;

namespace StartProject.Controllers
{
    [ApiController, Route("test/")]
    public class MyFacadeController : ControllerBase
    {
        private readonly IMyFacade _facade;

        public MyFacadeController(IMyFacade facade)
        {
            _facade = facade;
        }

        [HttpGet("facade/type")]
        public ActionResult<string> AccessFacade()
        {
            return _facade.GetType().FullName;
        }
    }
}