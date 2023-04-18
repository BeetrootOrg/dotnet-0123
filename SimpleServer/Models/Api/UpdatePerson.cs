using System;

namespace SimpleServer.Models.Api
{
    public class UpdatePersonRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime? Dob { get; init; }
        public bool? Verified { get; init; }
        public string Email { get; init; }
        public byte? Age { get; init; }
    }

    public class UpdatePersonResponse
    {
        public string[] UpdatedFields { get; init; }
    }

    public class UpdatePersonInternalServerResponse
    {
        public string Message { get; init; }
    }
}
