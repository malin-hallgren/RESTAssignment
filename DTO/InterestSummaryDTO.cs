namespace RESTAssignment.DTO
{
    public class InterestSummaryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public InterestSummaryDTO() { }
        public InterestSummaryDTO(RESTAssignment.Models.Interest interest)
        {
            Id = interest.Id;
            Name = interest.Name;
            Description = interest.Description;
        }
    }
}
