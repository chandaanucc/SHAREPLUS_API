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
    public class ViewFilesController : ControllerBase
    {
        private readonly DataContext _context;

        public ViewFilesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewPdf(int id)
        {
            var pdfFile = await _context.FileUploads.FindAsync(id); 
            if (pdfFile == null)
                return NotFound();

            return File(pdfFile.Data, "application/pdf");
        }
    }
}