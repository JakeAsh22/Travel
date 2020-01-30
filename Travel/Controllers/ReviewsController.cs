using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Travel.Models;
using Microsoft.EntityFrameworkCore;

namespace Travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private TravelContext _db;
        public ReviewsController(TravelContext db)
        {
            _db = db;
        }

        //GET api Reviews list
        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get(string individualreview, int placeid, int reviewid)
        {
            var query = _db.Reviews.AsQueryable();
            if (individualreview != null)
            {
                query = query.Where(entry => entry.individualReview == individualreview);
            }
             if (placeid != 0)
            {
                query = query.Where(entry => entry.PlaceId == placeid);
            }
            if (reviewid != 0)
            {
                query = query.Where(entry => entry.ReviewId == reviewid);
            }
            return query.ToList();
        }
        
        //Posting a new city
        [HttpPost]
        public void Post([FromBody] Review review)
        {
            _db.Reviews.Add(review);
            _db.SaveChanges();
        }

        //GETTING single review from db
        [HttpGet("{id}")]
        public ActionResult<Review> Get(int id)
        {
            return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
        }

        [HttpPut("{id}/{name}")]
        public void Put (int id, [FromBody] Review review, string name)
        {
            if (review.Name == name)
            {
                 review.ReviewId = id;
                _db.Entry(review).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        [HttpDelete("{id}/{name}")]
        public void Delete (int id, string name)
        {
            var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
            if (reviewToDelete.Name == name)
            { 
            _db.Reviews.Remove(reviewToDelete);
            _db.SaveChanges();
            }
        }

    }
}