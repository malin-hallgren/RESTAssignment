using RESTAssignment.Models;

namespace RESTAssignment.DTO
{
    public class PersonDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public List<InterestSummaryDTO> Interests { get; set; }

        public PersonDetailDTO() { }

        public PersonDetailDTO(Person person)
        {
            Id = person.Id;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Phone = person.Phone;
            Interests  = person.PersonInterests
                .Select(pi => new InterestSummaryDTO(pi.Interest))
                .ToList();
        }
    }
}
