

namespace RESTAssignment.DTO
{
    public class PersonSummaryDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public PersonSummaryDTO() { }

        public PersonSummaryDTO(RESTAssignment.Models.Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Phone = person.Phone;
        }
    }
}
