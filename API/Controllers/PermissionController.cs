using Application.Dtos.Permission;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IPermissionService _permissionService;
        public PermissionController(IWebHostEnvironment webHostEnvironment, IPermissionService permissionService)
        {
            _webHostEnvironment = webHostEnvironment;
            _permissionService = permissionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permission>> Get(int id)
        {
            try
            {
                return Ok(await _permissionService.GetAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find permission with id: {id}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permission>>> GetAll()
        {
            return Ok(await _permissionService.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePermission(CreatePermissionDto data)
        {
            int addedId = await _permissionService.CreateAsync(data);
            if (addedId == -1) return BadRequest("Unable to add permission");
            return Ok(addedId);
        }
        
        [HttpPut]
        public async Task<ActionResult<int>> UpdatePermission(UpdatePermissionDto data)
        {
            try
            {
                int updatedId = await _permissionService.UpdateAsync(data);
                if (updatedId == -1) return BadRequest("Unable to update permission");
                return Ok(updatedId);
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find record with id: {data.Id}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeletePermission(int id)
        {
            try
            {
                await _permissionService.DeleteAsync(id);
                return Ok(id);
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find permission with id: {id}");
            }
        }

    }
}
