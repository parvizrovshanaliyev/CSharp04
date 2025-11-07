namespace SampleCrudOperations.Models
{
    /// <summary>
    /// Represents a customer entity in the database
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}