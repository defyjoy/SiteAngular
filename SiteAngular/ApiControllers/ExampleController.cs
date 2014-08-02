using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SiteAngular.Core.Models;
using SiteAngular.Database.Migration;

namespace SiteAngular.ApiControllers
{
    public class ExampleController : ApiController
    {
        private SiteAngularContext db = new SiteAngularContext();

        // GET: api/Students
        public IQueryable<Students> GetStudents()
        {
            return db.Students;
        }

        // GET: api/Students/5
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> GetStudents(Guid id)
        {
            Students students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            return Ok(students);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudents(Guid id, Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != students.StudentGuid)
            {
                return BadRequest();
            }

            db.Entry(students).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> PostStudents(Students students)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(students);
            await db.SaveChangesAsync();
            
            return CreatedAtRoute("DefaultApi", new { id = students.StudentGuid }, students);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Students))]
        public async Task<IHttpActionResult> DeleteStudents(Guid id)
        {
            Students students = await db.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            db.Students.Remove(students);
            await db.SaveChangesAsync();

            return Ok(students);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentsExists(Guid id)
        {
            return db.Students.Count(e => e.StudentGuid == id) > 0;
        }
    }
}