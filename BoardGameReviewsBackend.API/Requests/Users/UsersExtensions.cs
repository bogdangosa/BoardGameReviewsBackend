using BoardGameReviewsBackend.API.Requests.Reviews;
using BoardGameReviewsBackend.Business;
using BoardGameReviewsBackend.Data.Models;

namespace BoardGameReviewsBackend.API.Requests.Users;

public static class UsersExtensions
{
        public static User toModel(this SignupRequest request) => 
            new User
            {
                userId = 0,
                isAdmin = false,
                isVerified = false,
                password = request.password,
                email = request.email,
                username = request.username,
            };
}