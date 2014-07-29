using SiteAngular.Core.Models;
using SiteAngular.Database.Migration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SiteAngular.ApiControllers
{
    //[RoutePrefix("Students")]
    public class StudentApiController : ApiController
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
        public async Task<HttpResponseMessage> Get(string id)
        {
            //Thread.Sleep(10000);
            return Request.CreateResponse<Students>(HttpStatusCode.OK, await Context.Set<Students>().FindAsync(new Guid(id)));

        }

        // POST: api/Values
        [Route("api/students")]
        public HttpResponseMessage Post([FromBody]Students Student)
        {
            if (Student == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            Context.Set<Students>().Add(Student);
            int result = Context.SaveChanges();
            return result > 0 ? Request.CreateResponse(HttpStatusCode.Created, Student) : Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError("Internal Service Error"));
        }

        // PUT: api/Values/5
        [Route("api/students/{id}")]
        [HttpPut]
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Students studentToupdate)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Model state Not valid");
            }
            if (studentToupdate == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            Students student = await Context.Set<Students>().FindAsync(new Guid(id));
            student.FirstName = studentToupdate.FirstName;
            student.LastName = studentToupdate.LastName;
            student.Address = studentToupdate.Address;
            student.DOB = studentToupdate.DOB;
            student.Phone = studentToupdate.Phone;

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
