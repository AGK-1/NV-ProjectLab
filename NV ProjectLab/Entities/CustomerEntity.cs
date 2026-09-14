public class CustomerEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }

    public CustomerStatus Status { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

}

