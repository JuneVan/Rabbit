namespace Rabbit.Threading
{
    public interface IThreadSignal
    {
        CancellationToken CancellationToken { get; }
    }
}
