using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1_API.Models;

namespace Task1_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        APIContext db;
        public CourseController(APIContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Course>> get()
        {
            var crs =db.Courses.ToList();
            if(crs== null)
            {
                return NotFound();
            }
            else
                return Ok(crs);
            
        }

        [HttpDelete]
        public ActionResult deleteCourse(int id)
        {
            Course crs = db.Courses.Find(id);
            if (crs == null) { return NotFound(); }
            else
            {
                db.Courses.Remove(crs);
                db.SaveChanges();
                return Ok(crs);
            }
        }
        //to update
        [HttpPut]
        public ActionResult put(int id, Course crs)
        {
            //if(id !=crs.id)
            //{
            //    return BadRequest();
            //}
            //else

            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(crs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else return BadRequest();
        }

        //add
        [HttpPost]
        public ActionResult post(Course crs)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Courses.Add(crs);
                    db.SaveChanges();
                    return Created("url", crs);

                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else return BadRequest();
        }

        //getbyid
        [HttpGet("{id:int}")]
        public ActionResult getById(int id)
        {
            Course crs = db.Courses.Find(id);
            if (crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }

        //getbyname
        [HttpGet("{name:alpha}")]
        public ActionResult getbyName(string name)
        {
            Course crs = db.Courses.Where(n => n.Crs_Name == name).FirstOrDefault();
            if (crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }

    }
}
