//using Domain.Entities;
//using Domain.Exceptions;
//using Domain.Interfaces;

//namespace Application.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly IUserRepository _userRepository;

//        public UserService(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public Task<List<User>> GetAll()
//        {
//            var users = _userRepository.GetAll();
//            return users;
//        }

//        public Task<User> GetById(int id)
//        {
//            var userById = _userRepository.GetById(id);
//            if (userById == null)
//            {
//                throw new NotFoundException($"User with {id} does not exist");
//            }
//            return userById;
//        }
//    }
//}
