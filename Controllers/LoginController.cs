// using Microsoft.AspNetCore.Mvc;
// using LoginAPI.Models;
// using LoginAPI.Data;
// using System.Linq;
// using Microsoft.EntityFrameworkCore;

// namespace LoginAPI.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class LoginController : ControllerBase
//     {
//         private readonly ApplicationDbContext _context;

//         public LoginController(ApplicationDbContext context)
//         {
//             _context = context;
//         }

//         [HttpPost("register")]
//         public IActionResult Register([FromBody] User user)
//         {
//             // Check if the user already exists
//             var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username || u.Password == user.Password);

//             if (existingUser != null)
//             {
//                 if (existingUser.Username == user.Username)
//                 {
//                     return Conflict("User with the same username already exists");
//                 }
//                 else if (existingUser.Password == user.Password)
//                 {
//                     return Conflict("User with the same password already exists. Please use a different password.");
//                 }
//             }

//             // Set the IsRegistered flag during registration
//             user.IsRegistered = true;

//             _context.Users.Add(user);
//             _context.SaveChanges();

//             return Ok("User Registered");
//         }

//         [HttpPost]
//         public IActionResult Login([FromBody] User login)
//         {
//             var user = _context.Users
//                 .Where(u => u.Username == login.Username && u.Password == login.Password)
//                 .FirstOrDefault();

//             if (user == null)
//             {
//                 return Unauthorized();
//             }

//             return Ok("Login Successful");
//         }

//         [HttpPost("logout")]
//         public IActionResult Logout()
//         {
//             // Perform logout actions here, such as clearing authentication tokens or session data
//             // For simplicity, this example just returns a message
//             return Ok("Logout Successful");
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;


using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Shareplus.DataLayer.Data;
using Shareplus.Models;

// Include this namespace for authorization attributes

namespace Shareplus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        // Login endpoint
        [HttpPost("login")]
        public IActionResult Login([FromBody] Admin login)
        {
            var user = _context.Admins.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok("Login Successful");
        }

        // Logout endpoint
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Perform logout actions here
            return Ok("Logout Successful");
        }

        // Register endpoint for admin
        [HttpPost("register-admin")]
        public IActionResult RegisterAdmin([FromBody] Admin admin)
        {
            // Check if the admin already exists
            var existingAdmin = _context.Admins.FirstOrDefault(a => a.Username == admin.Username);
            if (existingAdmin != null)
            {
                return Conflict("Admin already exists");
            }

            // Set IsRegistered flag for admin (if needed)
            admin.IsRegistered = true;

            // Add the admin to the database
            _context.Admins.Add(admin);
            _context.SaveChanges();

            return Ok("Admin registered successfully");
        }
        [HttpPost("add-associate")]
[AllowAnonymous]
public IActionResult AddAssociate([FromBody] Associate associate)
{
    // Get the admin name from the Associate object
    string adminName = associate.Admin;

    // Check if the admin exists in the Admin table
    var admin = _context.Admins.FirstOrDefault(a => a.Username == adminName);

    if (admin == null)
    {
        return BadRequest("Admin does not exist");
    }

    // Set the Admin property of the associate to the admin object
    associate.Admin = adminName;

    // Add the associate to the database
    _context.Associates.Add(associate);
    _context.SaveChanges();

    return Ok("Associate added successfully");
}




    }
}

