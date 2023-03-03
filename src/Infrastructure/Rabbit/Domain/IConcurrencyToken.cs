namespace Rabbit.Domain
{
    public interface IConcurrencyToken
    {
        string ConcurrencyStamp { get; set; }
    }
}
