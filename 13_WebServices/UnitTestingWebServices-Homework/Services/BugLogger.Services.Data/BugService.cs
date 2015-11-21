namespace BugLogger.Services.Data
{
    using System;
    using System.Linq;
    using BugLogger.Data;
    using Models;

    public class BugService : IBugService
    {
        private readonly IGenericRepository<Bug> bugs;

        public BugService(IGenericRepository<Bug> bugsRepository)
        {
            this.bugs = bugsRepository;
        }

        public IQueryable<Bug> All()
        {
            return this.bugs.All();
        }

        public void ChangeBugStatus(int id, string status)
        {
            var bug = this.bugs.GetById(id);
            BugStatus newStatus = (BugStatus)Enum.Parse(typeof(BugStatus), status);
            bug.BugStatus = newStatus;

            this.bugs.Update(bug);
            this.bugs.SaveChanges();
        }

        public IQueryable<Bug> GetAfterDate(DateTime date)
        {
            return this.bugs.SearchFor(x => x.Logged > date);
        }

        public IQueryable<Bug> GetAllByStatus(string status)
        {
            BugStatus searchStatus = (BugStatus)Enum.Parse(typeof(BugStatus), status);
            return this.bugs.SearchFor(x => x.BugStatus == searchStatus);
        }

        public int Post(string text)
        {
            var bugToAdd = new Bug
            {
                Text = text,
                Logged = DateTime.UtcNow,
                BugStatus = BugStatus.Pending
            };

            this.bugs.Add(bugToAdd);
            this.bugs.SaveChanges();

            return bugToAdd.Id;
        }
    }
}
