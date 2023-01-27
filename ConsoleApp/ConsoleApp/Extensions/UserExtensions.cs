using ConsoleApp.Models.Domain;

namespace ConsoleApp.Extensions
{
    internal static class UserExtensions
    {
        public static bool IsStudent(this User user)
        {
            return !user.IsBot &&
                !user.IsAdmin &&
                !user.IsOwner &&
                !user.IsAppUser &&
                !user.IsPrimaryOwner;
        }
    }
}