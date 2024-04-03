using Microsoft.AspNetCore.Mvc;
using Moryx.AbstractionLayer.Resources;

namespace MyApplication.App;

[ApiController, Route("test/")]
public class MyFacadeController(IResourceManagement facade) : ControllerBase
{
    private readonly IResourceManagement _facade = facade;

    [HttpGet("facade/type")]
    public ActionResult<string> AccessFacade()
    {
        return _facade.GetType().FullName;
    }
}