using AnimalShelter_WebAPI.DTOs.Role;
using AnimalShelter_WebAPI.DTOs.Role.Requests;
using AnimalShelter_WebAPI.Services.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Controllers
{
    [Authorize]
    [Route("api/persons/{personId}/role")]
    [ApiController]
    
    public class RolesController: ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddRoleToPerson([FromRoute] int personId, AddRoleToPersonRequest request)
        {
            _rolesService.AddRoleToPerson(personId, request);
            return Ok(personId);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("")]
        [Route("{roleId}/{quitDate}")]
        public ActionResult RomoveRoleFromPerson([FromRoute] int personId, [FromRoute] int roleId, [FromRoute] DateTime? quitDate)
        {
  
        _rolesService.RemoveRoleFromPerson(personId, roleId, quitDate);
            return Ok();
        }
    }
    
}
