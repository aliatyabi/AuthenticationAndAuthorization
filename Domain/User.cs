using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain
{
    public class User : Entity
    {
        public User()
        {

        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [JsonIgnore]
        public string? Password { get; set; }
    }
}
