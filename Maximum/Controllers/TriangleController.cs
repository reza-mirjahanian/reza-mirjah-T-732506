using Maximum.Services;
using Microsoft.AspNetCore.Mvc;

namespace Maximum.Controllers;

[ApiController]
[Route("api/maximum")]
public class TriangleController(
    ILogger<TriangleController> logger,
    IComputeTriangleService computeTriangleService,
    IGenerateTriangleService generateTriangleService
) : Controller
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public int Get()
    {
        logger.LogInformation(
            "Compute started at :  {} !",
            DateTime.UtcNow.ToString("H:mm:ss zzz")
        );
        var triangle = generateTriangleService.Generate();
        var computeMaxTotal = computeTriangleService.ComputeMax(triangle);
        logger.LogInformation(
            "Compute {} finished at :  {} !",
            computeMaxTotal,
            DateTime.UtcNow.ToString("H:mm:ss zzz")
        );
        return computeMaxTotal;
    }
}
