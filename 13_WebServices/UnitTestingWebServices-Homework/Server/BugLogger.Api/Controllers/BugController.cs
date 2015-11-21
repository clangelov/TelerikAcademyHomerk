namespace BugLogger.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using AutoMapper.QueryableExtensions;
    using Models;
    using Services.Data;

    public class BugController : ApiController
    {
        private readonly IBugService bugs;

        public BugController(IBugService bugsService)
        {
            this.bugs = bugsService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = this.bugs
                .All()
                .ProjectTo<BugResponcseModel>()
                .ToList();

            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetByDate([FromUri] string date)
        {
            if (string.IsNullOrWhiteSpace(date))
            {
                return this.BadRequest();
            }

            var searchDate = DateTime.Parse(date);

            var result = this.bugs.GetAfterDate(searchDate)
                .ProjectTo<BugResponcseModel>()
                .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpGet]
        public IHttpActionResult GetByStatus([FromUri] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return this.BadRequest();
            }

            var result = this.bugs.GetAllByStatus(status)
                .ProjectTo<BugResponcseModel>()
                .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult PostNewBug(SaveBugModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var bugId = this.bugs.Post(model.Text);

            return this.Ok(bugId);
        }

        [HttpPut]
        public IHttpActionResult PutStatus(int id, [FromUri] string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return this.BadRequest();
            }

            var bug = this.bugs.All().Where(b => b.Id == id).FirstOrDefault();

            if (bug == null)
            {
                return this.NotFound();
            }

            this.bugs.ChangeBugStatus(bug.Id, status);

            return this.Ok();
        }
    }
}