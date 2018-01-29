using ABADiversityAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABADiversityAPI.Services
{
    public class ABARepository : IABARepository
    {
        private ABAContext _ctx;
       public ABARepository(ABAContext ctx)
        {
            _ctx = ctx;
        }

        public bool Save()
        {
            return (_ctx.SaveChanges() >= 0);
        }

        public IEnumerable<SetUser> ReadSetUsers()
        {
            return _ctx.SetUsers.OrderBy(u => u.user_name).ToList();
        }

        public SetUser ReadSetUser(string userId)
        {
            return _ctx.SetUsers.Where(u => u.user_id == userId).FirstOrDefault();
        }

        public IEnumerable<SetGroup> ReadSetGroups()
        {
            return _ctx.SetGroups.OrderBy(g => g.grp_name).ToList();
        }

        public SetGroup ReadSetGroup(string groupId)
        {
            return _ctx.SetGroups.Where(g => g.grp_id == groupId).FirstOrDefault();
        }

        public IEnumerable<SetUserAccess> ReadSetUserAccesses()
        {
            return _ctx.SetUserAccesses.OrderBy(a => a.user_grp_id).ToList();
        }

        public SetUserAccess ReadSetUserAccess(int accessId)
        {
            return _ctx.SetUserAccesses.Where(a => a.user_grp_id == accessId).FirstOrDefault();
        }

    }
}
