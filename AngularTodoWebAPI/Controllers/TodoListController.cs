using AngularTodoWebAPI.Services;

namespace AngularTodoWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListController(ITodoListService todoListService)
        {
            this._todoListService = todoListService;
        }

        [HttpPost]
        public async Task<ApiResultDataModel> Post(TodoListDto todoRecord)
        {
            try
            {
                var result = new ApiResultDataModel();
                var data = await _todoListService.CreateTodoRecord(todoRecord);
                result.Data = data;
                result.IsSuccess = true;
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

        [HttpGet]
        public async Task<ApiResultDataModel> Get()
        {
            try
            {
                var result = new ApiResultDataModel();
                var data = await _todoListService.GetAllTodoList();
                result.Data = data;
                result.IsSuccess = true;
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

        [HttpPut]
        public async Task<ApiResultDataModel> Put(TodoListDto todoRecord)
        {
            try
            {
                var result = new ApiResultDataModel();
                var data = await _todoListService.UpdateProduct(todoRecord);
                result.Data = data;
                result.IsSuccess = true;
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

        [HttpDelete]
        public async Task<ApiResultDataModel> Delete(Guid todoRecordId)
        {
            try
            {
                var result = new ApiResultDataModel();
                var data = await _todoListService.DeleteProduct(todoRecordId);
                result.Data = data;
                result.IsSuccess = true;
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
