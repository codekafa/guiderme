using Business.Service.Infrastructure;
using Repository.Base;
using System;
using ViewModel.Views;
using ViewModel.Views.Security;

namespace Business.Service
{

    public class UserService : IUserService
    {
        IUserRepository _userRepo;
        IUserAddressRepository _userAddressRepo;
        public UserService(IUserRepository userRepo, IUserAddressRepository userAddressRepo)
        {
            _userRepo = userRepo;
            _userAddressRepo = userAddressRepo;
        }

    }
}
