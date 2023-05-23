using NuGet.Packaging.Signing;
using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Models
{
    public class Person: KeyBasedModel<long>
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Invalid FirstName")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "InValid Lastname")]
        public string LastName { get; set; }

        public string DisplayName => FirstName + ", " + LastName;
        public DateTime Birthday { get; set; }
        public string? Hobbies { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}
