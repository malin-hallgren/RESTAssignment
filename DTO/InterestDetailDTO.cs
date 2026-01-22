using RESTAssignment.Models;
    
namespace RESTAssignment.DTO
{
    public class InterestDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<LinkSummaryDTO> LinksAdded { get; set; }

        public InterestDetailDTO() { }

        public InterestDetailDTO(Interest interest)
        {
            Id = interest.Id;
            Name = interest.Name;
            Description = interest.Description;
            LinksAdded = interest.LinksAdded
                .Select(link => new LinkSummaryDTO(link))
                .ToList();
        }
    }
}
