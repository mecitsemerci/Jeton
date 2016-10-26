﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeton.Core.Entities;

namespace Jeton.Services.SettingService
{
    public interface ISettingService
    {
        Setting GetSettingById(Guid settingId);
        Setting GetSettingByName(string name);
        Setting Insert(Setting setting);
        void Update(Setting setting);
        void Delete(Guid settingId);
        IEnumerable<Setting> GetAllSettings();
    }
}
