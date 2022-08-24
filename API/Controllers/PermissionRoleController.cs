using Application.Dtos.PermissionRole;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionRoleController : ControllerBase
    {
        private readonly IPermissionRoleService _permissionRoleService;

        public PermissionRoleController(IPermissionRoleService permissionRoleService)
        {
            _permissionRoleService = permissionRoleService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePermissionRoleDto data)
        {
            try
            {
                bool result = await _permissionRoleService.AddPermissionToRole(data);
                return result ? Ok() : BadRequest("Record already exists");
            }
            catch (NullReferenceException)
            {
                return NotFound("Unable to find role or permission");
            }
        }
    }
}
