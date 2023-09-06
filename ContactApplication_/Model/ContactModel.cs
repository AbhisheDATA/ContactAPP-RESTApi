namespace ContactApplication_.Model
{
    public class ContactModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}