using Application.Dtos;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public record GetUserByIdQuery(int Id) : IRequest<UserResponse>
    {
    }

    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        async Task<UserResponse> IRequestHandler<GetUserByIdQuery, UserResponse>.Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var userById = await _userRepository.GetById(request.Id);
            if (userById == null)
            {
                throw new NotFoundException($"User with id {request.Id} does not exist");
            }

            var userResponse = MapToUserResponse(userById);
            return userResponse;
        }

        private UserResponse MapToUserResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Address = user.Address
            };
        }
    }
}
