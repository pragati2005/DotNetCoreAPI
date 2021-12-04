using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcorewebapi.Controller
{
    [ApiController]
    // The below route being applied at class is valid for all action methods and hence is base route for class.
    [Route("[Controller]")]
    public class ValuesController : ControllerBase
    {
        // multiple URL for single action method :
        [Route("api/get-all")]
        // This route is directly accessed by /getall (not full : /values/ required)
        [Route("~/getall")]
        [Route("api/1/get-all")]
        public String GetAll()
        {
            return "The string returned from Values controller GetAll action method";
        }
        [Route("api/getallauthors")]
        [Route("~/getallauthors")]   // This route is directly accessed by /getallauthors (not full : /values/ required)
        public String GetAllAuthors()
        {
            return "The string returned from Values controller Get All Authors";
        }
        [Route("api/getbooks/{id}")]
        public String GetBooksById(int id)
        {
            return "Get books by id"+" "+id;
        }
        [Route("api/getbooks/{id}/author/{authorid}")]
        public String GetAuthorsById(int id,int authorid)
        {
            return "Get books by id" + " " + id+" and the author is : "+ authorid;
        }
        // Example of query string :
   // pass URL as : https://localhost:44390/Values/api/getallinfo?name=%22Pragati%//22&id=1&authorid=2&rating=4
        [Route("api/getallinfo")]
        public String GetAuthorsById(int id, int authorid , String name, int rating)
        {
            return "Get books by id" + " " + id + " and the author is : " + authorid + "The name is : "+name+
                "The rating is : "+rating;
        }
    }
}
