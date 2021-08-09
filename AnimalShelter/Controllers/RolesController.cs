using AnimalShelter_WebAPI.DTOs.Role;
using AnimalShelter_WebAPI.Services.Roles;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Route("api/{personId}/role")]
    [ApiController]
    
    public class RolesController: ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        [HttpPost]
        public ActionResult AddRoleToPerson([FromRoute] int personId, AddRoleToPersonRequest request)
        {
            _rolesService.AddRoleToPerson(personId, request);
            return Ok();
        }
    }
    
}
