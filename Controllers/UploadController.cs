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
    public class UploadFilesController : ControllerBase
    {
        private readonly DataContext _context;

        public UploadFilesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPdf([FromForm] UploadDTO pdfUploadDto)
        {
            if (pdfUploadDto.File == null || pdfUploadDto.File.Length == 0)
                return BadRequest("Upload a valid PDF file.");

            using var memoryStream = new MemoryStream();
            await pdfUploadDto.File.CopyToAsync(memoryStream);
            var pdfFile = new PDFile
            {
                FileName = pdfUploadDto.File.FileName,
                Data = memoryStream.ToArray()
                //ContentType = pdfUploadDto.File.ContentType
            };
            _context.FileUploads.Add(pdfFile); 
            await _context.SaveChangesAsync();

            var pdfFileDto = new UploadDTO
            {
                Id = pdfFile.Id,
                FileName = pdfFile.FileName
                //ContentType = pdfFile.ContentType
            };

            return Ok(pdfFileDto);
        }

        
    }
}
