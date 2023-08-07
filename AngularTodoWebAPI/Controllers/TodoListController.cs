using System.Threading.Tasks;

namespace AngularTodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public async Task Get()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
