using Microsoft.EntityFrameworkCore;
using Shareplus.DataLayer.Data;
using Shareplus.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shareplus.DataLayer
{
    public class AuthDL : IAuthDL
    {
        private readonly DataContext _context;

        public AuthDL(DataContext context)
        {
            _context = context;
        }

        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            SignInResponse response = new SignInResponse
            {
                IsSuccess = true,
                Message = "Successful"
            };

            try
            {
                var user = await _context.UserDetails
                    .FirstOrDefaultAsync(u => u.UserName == request.UserName && 
                                              u.Password == request.Password && 
                                              u.Role == request.Role);

                if (user != null)
                {
                    response.Message = "Login Successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Login Unsuccessfully";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            SignUpResponse response = new SignUpResponse
            {
                IsSuccess = true,
                Message = "Successful"
            };

            try
            {
                if (!request.Password.Equals(request.ConfigPassword))
                {
                    response.IsSuccess = false;
                    response.Message = "Password & Confirm Password do not match";
                    return response;
                }

                var userDetail = new UserDetail
                {
                    UserName = request.UserName,
                    Password = request.Password,
                    Role = request.Role
                };

                await _context.UserDetails.AddAsync(userDetail);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
