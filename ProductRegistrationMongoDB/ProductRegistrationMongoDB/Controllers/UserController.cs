using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProductRegistrationMongoDB.Domain.Entities;
using ProductRegistrationMongoDB.Domain.Interfaces;
using ProductRegistrationMongoDB.Models;

namespace ProductRegistrationMongoDB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var result = await _userService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("get-by-name/{name}")]
        public async Task<ActionResult<List<User>>> GetByName(string name)
        {
            var result = await _userService.FindAsync(x => x.Name.Contains(name));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRequestModel user)
        {
            // TODO: colocar automapper.
            await _userService.CreateAsync(new User()
            {
                Name = user.Name,
                Email = user.Email,
                Address = new Address()
                {
                    City = user.Address.City,
                    Street = user.Address.Street,
                    ZipCode = user.Address.ZipCode
                }
            });
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserRequestModel user)
        {
            if (await _userService.GetByIdAsync(user.Id) == null)
            {
                return NotFound();
            }

            // TODO: colocar automapper.
            return Ok(await _userService.UpdateAsync(new User()
            {
                Id = ObjectId.Parse(user.Id),
                Name = user.Name,
                Email = user.Email,
                Address = new Address()
                {
                    City = user.Address.City,
                    Street = user.Address.Street,
                    ZipCode = user.Address.ZipCode
                }
            }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var produto = await _userService.GetByIdAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            await _userService.DeleteAsync(id);

            return NoContent();
        }

    }
}
