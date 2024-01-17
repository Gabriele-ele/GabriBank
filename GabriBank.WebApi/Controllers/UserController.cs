using Application.Users.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GabriBank.WebApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUserService _userService;

        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        [HttpGet]
        [Route("user/all")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var getUsersQuery = new GetUsersQuery();
            var users = await _mediator.Send(getUsersQuery);
            return Ok(users);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        [HttpGet]
        [Route("user/{id}")]
        public async Task<ActionResult<User>> GetById(int id) 
        {
            var getUserById = new GetUserByIdQuery(id);
            var user = await _mediator.Send(getUserById);
            return Ok(user);
        }
    }
}
