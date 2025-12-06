namespace SampleCrudOperations.Models
{
    /// <summary>
    /// Represents a customer entity in the database
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}