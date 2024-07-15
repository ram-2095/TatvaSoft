using Data_Access_Layer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Data_Access_Layer.Repository.Entities;
using Microsoft.EntityFrameworkCore;


namespace Web_API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MissionApplicationController : Controller
    {
        private readonly AppDbContext _cIDbContext;

        public MissionApplicationController(AppDbContext cIDbContext)
        {
            _cIDbContext = cIDbContext;
        }

        [HttpGet]
        [Route("GetMissionApplicationList")]
        //   [Authorize]

        public async Task<MissionApplicationResponse> GetMissionApplicationListAsync()
        {
            var getdata = await _cIDbContext.MissionApplication
                                            .Where(ma => !ma.IsDeleted)
                                            .ToListAsync();

            var response = new MissionApplicationResponse
            {
                Result = 1,
                Data = getdata,
                Message = "Success"
            };

            return response;
        }

        public class MissionApplicationResponse
        {
            public int Result { get; set; }
            public List<MissionApplication> Data { get; set; }
            public string Message { get; set; }
        }
    }
}
