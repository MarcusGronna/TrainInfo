using Domain.Entities;
//using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
            private Mock_Db _db;
        
            
            public TrainsController(Mock_Db db)
            {
            _db = db;
            }

        [HttpGet]
        public List<Train> GetAll()
        {
            return _db.trainList;
        }
            
        
    }
}
