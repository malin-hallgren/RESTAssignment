namespace RESTAssignment.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Link> LinksAdded { get; set; }

        public List<PersonInterest> PersonInterests { get; set; }
    }
}
