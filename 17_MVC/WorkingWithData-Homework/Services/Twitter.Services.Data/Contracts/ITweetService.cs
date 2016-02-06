using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Data.Models;

namespace Twitter.Services.Data.Contracts
{
    public interface ITweetService
    {
        IQueryable<Tweet> LastTen();

        IQueryable<Tweet> ByUser(string userName);

        IQueryable<Tweet> ByTag(string tag);

        Tweet CrateTag(string userName, string comment, List<string> Tags);
    }
}
