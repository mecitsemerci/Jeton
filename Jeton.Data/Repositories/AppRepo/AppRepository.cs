﻿using Jeton.Core.Entities;
using Jeton.Data.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace Jeton.Data.Repositories.AppRepo
{
    public class AppRepository : RepositoryBase<App>, IAppRepository
    {
        public AppRepository(IDbFactory dbFactory)
            : base(dbFactory) { }

        public App GetAppById(Guid appId)
        {
            return DbContext.Apps.Find(appId);
        }

        public App GetAppByName(string appName)
        {
            return DbContext.Apps.FirstOrDefault(a => a.Name.Equals(appName));
        }

        public bool IsExist(Guid appId)
        {
            return DbContext.Apps.Any(a => a.AppID.Equals(appId));
        }

        public bool IsExist(App app)
        {
            return DbContext.Apps.Any(a => a.AppID.Equals(app.AppID) && a.Name.Equals(app.Name, StringComparison.OrdinalIgnoreCase));
        }

        public bool IsExistByName(string appName)
        {
            return DbContext.Apps.Any(a => a.Name.Equals(appName, StringComparison.OrdinalIgnoreCase));
        }

        public override void Update(App entity)
        {
            entity.Modified = DateTime.Now;

            base.Update(entity);
        }

        public override App Insert(App entity)
        {

            if (IsExistByName(entity.Name))
            {
                int index = 0;
                string name = entity.Name;
                while (IsExistByName(entity.Name))
                {
                    entity.Name = string.Format("{0}_{1}", name, ++index);
                }
            }
            return base.Insert(entity);
        }
    }
}
