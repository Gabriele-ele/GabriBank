using Application.Dtos;
using Domain.Interfaces;
using MediatR;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries
{
    public record GetUsersQuery : IRequest<List<UserResponse>>
    {

    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler (IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        Task<List<UserResponse>> IRequestHandler<GetUsersQuery, List<UserResponse>>.Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            List<UserResponse> userResponse = _mapper.Map<List<UserResponse>>(users);

            return Task.FromResult(userResponse);
        }
    }

}
