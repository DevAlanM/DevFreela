﻿using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null) return null;

            return new UserViewModel(user.FullName, user.Email);
        }

        public List<UserViewModel> GetAll(string query)
        {
            var users = _dbContext.Users;
            var userViewModel = users
                .Select(u => new UserViewModel(u.Id, u.FullName, u.Email))
                .ToList();
            return userViewModel;
        }
    }
}
