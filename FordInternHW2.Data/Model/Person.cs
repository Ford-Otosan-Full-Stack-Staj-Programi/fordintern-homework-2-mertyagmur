using FordInternHW2.Base.Model;

namespace FordInternHW2.Data.Model
{
    public class Person: BaseModel
    {
        public string AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; } 
        public DateTime DateOfBirth { get; set; }
    }
}
