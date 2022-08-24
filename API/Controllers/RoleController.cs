using Application.Dtos.Role;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(int id)
        {
            try
            {
                return Ok(await _roleService.GetAsync(id));
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find role with id: {id}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetAll()
        {
            return Ok(await _roleService.GetAllAsync());
        }


        [HttpPost]
        public async Task<ActionResult<int>> CreateRole(CreateRoleDto data)
        {
            int addedId = await _roleService.CreateAsync(data);
            return Ok(addedId);
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateRole(UpdateRoleDto data)
        {
            try
            {
                int updatedId = await _roleService.UpdateAsync(data);
                return Ok(updatedId);
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find record with id: {data.Id}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRole(int id)
        {
            try
            {
                await _roleService.DeleteAsync(id);
                return Ok(id);
            }
            catch (NullReferenceException)
            {
                return NotFound($"Unable to find role with id: {id}");
            }
        }

    }
}
