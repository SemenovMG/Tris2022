using Microsoft.AspNetCore.Mvc;
using Tris2022.Entity;
using Tris2022.Interfaces.Services;
using Tris2022.Models;

namespace Tris2022.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(
            IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        public IEnumerable<Group> GetAllGroups()
        {
            return _groupService.GetAllGroups();
        }

        [HttpGet("{id}")]
        public ActionResult<Group> GetGroupById(int id)
        {
            return _groupService.GetGroupById(id);
        }

        [HttpPost]
        public ActionResult<Group> AddGroup(AddGroupRequest req)
        {
            var newGroup = _groupService.AddGroup(req);
            return CreatedAtAction("GetGroupById", 
                new { newGroup.Id },
                newGroup);
        }

        [HttpDelete("{id}")]
        public ActionResult<Group> DeleteGroupById(int id)
        {
            return _groupService.DeleteGroupById(id);
        }
    }
}