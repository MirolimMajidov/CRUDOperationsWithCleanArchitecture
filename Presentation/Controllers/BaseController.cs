using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : BaseEntity
    {
        protected readonly ILogger<ControllerBase> _logger;
        protected readonly IBaseService<TEntity> _service;

        public BaseController(ILogger<ControllerBase> logger, IBaseService<TEntity> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<IEnumerable<TEntity>> Get(int? from = null, int? size = null)
        {
            return await _service.GetAllAsync(from, size);
        }

        [HttpGet("GetById")]
        [AllowAnonymous]
        public async Task<ActionResult> GetById(Guid id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Create(TEntity user)
        {
            var entity = await _service.CreateAsync(user);
            if (entity == null)
                return BadRequest();

            return Ok(entity);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Guid userId, TEntity user)
        {
            var _user = await _service.UpdateAsync(userId, user);
            if (_user == null)
                return BadRequest();

            return Ok(_user);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid userId)
        {
            var response = await _service.DeleteAsync(userId);
            if (response)
                BadRequest();

            return Ok();
        }
    }
}