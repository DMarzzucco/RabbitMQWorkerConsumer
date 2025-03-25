using Microsoft.AspNetCore.Mvc;
using Project.Module.DTOs;
using Project.Module.Model;
using Project.Module.Services.Interface;

namespace Project.Module.Handler
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ProjectModel>> CreatingProject([FromBody] CreateProjectDTO body)
        {
            var project = await this._service.SaveProject(body);

            return CreatedAtAction(nameof(GetAll), new { id = project.Id }, project);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAll()
        {
            var project = await this._service.ListOfProject();
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetById(int id)
        {
            return Ok(await this._service.GetProjectById(id));
        }
    }
}
