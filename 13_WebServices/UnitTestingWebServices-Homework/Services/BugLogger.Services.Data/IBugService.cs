namespace BugLogger.Services.Data
{
    using System;
    using System.Linq;
    using BugLogger.Models;

    public interface IBugService
    {
        IQueryable<Bug> All();

        int Post(string text);

        IQueryable<Bug> GetAfterDate(DateTime date);

        IQueryable<Bug> GetAllByStatus(string status);

        void ChangeBugStatus(int id, string status);
    }
}
