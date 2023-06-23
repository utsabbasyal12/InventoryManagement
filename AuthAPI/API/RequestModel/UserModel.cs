using System.ComponentModel.DataAnnotations.Schema;

namespace AuthAPI.API.RequestModel
{
    [Table("tblUser", Schema = "Auth")]
    public class UserModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        // Add other properties as needed
    }
}
