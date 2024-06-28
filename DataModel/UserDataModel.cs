using System.ComponentModel.DataAnnotations;

namespace DesafioUBC.DataModel
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
