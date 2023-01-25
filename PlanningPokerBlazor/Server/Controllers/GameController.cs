using Microsoft.AspNetCore.Mvc;
using PlanningPokerBlazor.Shared;

namespace PlanningPokerBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        [HttpGet("Obter")]
        public async Task<List<Room>> ObterServidores()
        {
            return await Task.FromResult(RoomsCreated.RoomList.ToList());
        }
    }
}
