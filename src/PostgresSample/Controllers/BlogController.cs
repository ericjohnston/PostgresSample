using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using PostgresSample.Models;
using Microsoft.Data.Entity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PostgresSample.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private BloggingContext dbContext;

        public BlogController(BloggingContext context)
        {
            dbContext = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var blogs = dbContext.Blogs.Include(b => b.Posts).AsEnumerable<Blog>();

            return Ok(blogs);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Blog blog;

            try {
                blog = dbContext.Blogs.Include(b => b.Posts).Where(b => b.BlogId == id).FirstOrDefault<Blog>();
            } catch(Exception ex)
            {
                return HttpBadRequest(ex);
            }

            if(blog != null)
            {
                return Ok(blog);
            } else
            {
                return HttpNotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Blog blog)
        {
            try
            {
                dbContext.Blogs.Add(blog);
                dbContext.SaveChanges();
            } catch(Exception ex)
            {
                return HttpBadRequest(ex);
            }

            return Created(Url.Action("Get", "Blog", blog.BlogId), blog);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var blog = dbContext.Blogs.Where(b => b.BlogId == id).FirstOrDefault();

                if(blog == null)
                {
                    return HttpNotFound(id);
                } else
                {
                    dbContext.Blogs.Remove(blog);
                    dbContext.SaveChanges();
                }
            } catch(Exception ex)
            {
                return HttpBadRequest(ex);
            }

            return Ok();
        }
    }
}
