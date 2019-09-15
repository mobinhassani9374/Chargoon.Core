using Chargoon.DataLayer.Context;
using Chargoon.DomainModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chargoon.DataLayer.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
