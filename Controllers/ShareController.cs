using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shareplus.DataLayer.Data;
using Shareplus.DataLayer.DTOs;
using Shareplus.DataLayer.Models;
using System.IO;
using System.Threading.Tasks;

namespace Shareplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShareFilesController : ControllerBase
    {
        private readonly DataContext _context;

        public ShareFilesController(DataContext context)
        {
            _context = context;
        }

    }

}
