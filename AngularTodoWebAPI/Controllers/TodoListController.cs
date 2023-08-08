using AngularTodoWebAPI.DataTransferObject;
using System.Threading.Tasks;

namespace AngularTodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        [HttpGet]
        public async Task<ApiResultDataModel> Get()
        {
            try
            {
                var result = new ApiResultDataModel();

                return result;
            }
            catch (Exception ex)
            {
                return new ApiResultDataModel
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message,
                    ErrorMessageDetail = ex.ToString()
                };
            }
        }
    }
}
