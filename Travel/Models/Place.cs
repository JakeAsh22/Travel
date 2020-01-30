using System.Collections.Generic;
using Travel.Controllers;
namespace Travel.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        //Sharon's addition
        public virtual ICollection<Review> Reviews { get; set; }
        public Place()
        {
            this.Reviews = new HashSet<Review>();
        }


    }
}