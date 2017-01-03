﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jeton.Core.Entities;
using Jeton.Core.Interfaces.Repositories;
using Jeton.Core.Interfaces.Services;

namespace Jeton.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region CREATE
        public User Insert(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return _userRepository.Insert(user);
        }
        #endregion

        #region READ
        public User GetUserById(Guid userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            return _userRepository.GetById(userId);
        }

        public User GetUserByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var table = _userRepository.Table;

            return table.FirstOrDefault(u => u.Name.Equals(name));
        }

        public User GetUserByNameId(string nameId)
        {
            if (string.IsNullOrEmpty(nameId))
                throw new ArgumentNullException(nameof(nameId));

            var table = _userRepository.Table;

            return table.FirstOrDefault(u => u.NameId.Equals(nameId));
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.Table.ToList();
        }
        #endregion

        #region UPDATE
        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _userRepository.Update(user);
        }
        #endregion

        #region DELETE
        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public Task<bool> IsExistAsync(string nameId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByNameIdAsync(string nameId)
        {
            throw new NotImplementedException();
        }

        public Task<User> InsertAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        #endregion


        public bool IsExist(string nameId)
        {
            if (string.IsNullOrEmpty(nameId))
                throw new ArgumentNullException(nameof(nameId));
            var table = _userRepository.TableNoTracking;

            return table.Any(u => u.NameId.Equals(nameId));
        }
    }
}