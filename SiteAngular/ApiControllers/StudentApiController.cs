using SiteAngular.Core.Models;
using SiteAngular.Database.Migration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SiteAngular.ApiControllers
{
    //[RoutePrefix("Students")]
    public class StudentApiController : BaseApiController
    {
        private SiteAngularContext Context { get; set; }
        public StudentApiController()
        {
            Context = new SiteAngularContext();
        }
        // GET: api/Values
        [Route("api/students")]
        public IEnumerable<Students> Get()
        {
            //Thread.Sleep(10000);
            return Context.Set<Students>();
        }

        // GET: api/Values
        [Route("api/students/{id}")]
        public async Task<IHttpActionResult> Get(string id)
        {
            Guid StudentId;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out StudentId))
                return BadRequest("Invalid student id.");
            Students student = await Context.Set<Students>().FindAsync(new Guid(id));
            if (student == null)
            {
                return BadRequest("Student Not Found");
            }
            return Ok<Students>(await Context.Set<Students>().FindAsync(new Guid(id)));
        }

        // POST: api/Values
        [Route("api/students")]
        public HttpResponseMessage Post([FromBody]Students Student)
        {
            if (!ModelState.IsValid)
                return ModelStateErrorResult(HttpStatusCode.BadRequest, ModelState);
            Context.Set<Students>().Add(Student);
            int result = Context.SaveChanges();
            if (result > 0)
            {
                return Request.CreateResponse<Students>(Student);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server error");
            //return result > 0 ? Request.CreateResponse(HttpStatusCode.Created, Student) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError("Internal Service Error"));
        }

        // PUT: api/Values/5
        [Route("api/students/{id}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Students student)
        {
            Guid StudentId;
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out StudentId))
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Student Id not valid");
            if (!ModelState.IsValid)
                return ModelStateErrorResult(HttpStatusCode.BadRequest, ModelState);
            if (student == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);

            Context.Entry(student).State = EntityState.Modified;
            try
            {
                int result = await Context.SaveChangesAsync();
                return result > 0 ? Request.CreateResponse<Students>(HttpStatusCode.OK, student) : Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<Exception>(ex);
            }
        }

        // DELETE: api/Values/5
        [Route("api/students/{id}")]
        public async Task<HttpResponseMessage> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("This is a not a valid student"));
            Students Student = await Context.Set<Students>().FindAsync(new Guid(id));
            if (Student == null)
                return Request.CreateErrorResponse(HttpStatusCode.Gone, new HttpError("This student already has been deleted"));
            Context.Set<Students>().Remove(Student);
            try
            {
                int result = await Context.SaveChangesAsync();
                return result > 0 ? Request.CreateErrorResponse(HttpStatusCode.OK, "Student has been successfully deleted") : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError("Server error.Please try after some time."));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<Exception>(ex);
            }
        }
    }
}
