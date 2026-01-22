using RESTAssignment.Models;

namespace RESTAssignment.DTO
{
    public class LinkDetailDTO
    {
        public string Url { get; set; }
        public string InterestName { get; set; }

        public string PersonName { get; set; }

        public LinkDetailDTO() { }

        public LinkDetailDTO(Link link)
        {
            PersonName = link.Person.FirstName + " " + link.Person.LastName;
            InterestName = link.Interest.Name;
            Url = link.Url;
        }
    }
}
