namespace Rabbit.Threading
{
    public class NullThreadSignal : IThreadSignal
    {
        public CancellationToken CancellationToken => CancellationToken.None;
    }
}
