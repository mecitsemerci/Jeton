﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Jeton.Core.Common;
using Jeton.Core.Entities;
using Jeton.Core.Helpers;
using Jeton.Core.Interfaces.Repositories;
using Jeton.Data.Infrastructure;
using Jeton.Data.Infrastructure.Interfaces;

namespace Jeton.Data.Repositories
{
    public class SettingRepository : BaseRepository<Setting>, ISettingRepository
    {
        #region Ctor
        public SettingRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
            
        }
        #endregion

        #region INSERT
        #endregion

        #region UPDATE
        #endregion

        #region DELETE
        #endregion

        #region SELECT
        /// <summary>
        /// Get setting by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Setting GetSettingByName(string name)
        {
            return Table.FirstOrDefault(s => string.Equals(s.Name, name));
        }
        /// <summary>
        /// Get setting by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Setting> GetSettingByNameAsync(string name)
        {
            return await Table.FirstOrDefaultAsync(s => string.Equals(s.Name, name));
        }
        /// <summary>
        /// Get secretKey setting value
        /// </summary>
        /// <returns></returns>
        public string GetSecretKey()
        {
            return Table.FirstOrDefault(s => s.Name.Equals(Constants.Settings.SecretKey))?.Value;
        }
        /// <summary>
        /// Get secretKey setting value async
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetSecretKeyAsync()
        {
            var secretKey = await Table.FirstOrDefaultAsync(s => s.Name.Equals(Constants.Settings.SecretKey));

            return secretKey?.Value;
        }
        /// <summary>
        /// Get token duration value
        /// </summary>
        /// <returns></returns>
        public int GetTokenDuration()
        {
            return Convert.ToInt32(Table.FirstOrDefault(s => s.Name.Equals(Constants.Settings.TokenDuration))?.Value);
        }
        /// <summary>
        /// Get token duration value async
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetTokenDurationAsync()
        {
            var tokenDuration = await Table.FirstOrDefaultAsync(s => s.Name.Equals(Constants.Settings.TokenDuration));

            return Convert.ToInt32(tokenDuration?.Value);
        }
        #endregion


        /// <summary>
        /// Check isExist by name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsExist(string name)
        {
            return TableNoTracking.Any(s => s.Name.Equals(name));
        }
        /// <summary>
        /// Check isExist by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(string name)
        {
            return await TableNoTracking.AnyAsync(s => string.Equals(s.Name, name));
        }


    }
}
