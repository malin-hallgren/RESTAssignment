using RESTAssignment.Models;

namespace RESTAssignment.DTO
{
    public class LinkSummaryDTO
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public string AddedBy { get; set; }

        public LinkSummaryDTO() { }

        public LinkSummaryDTO(Link link)
        {
            Id = link.Id;
            Url = link.Url;
            AddedBy = link.Person.FirstName + " " + link.Person.LastName;
        }
    }
}
