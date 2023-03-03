namespace Rabbit.Authorization
{
    public class NullIdentifier : IIdentifier
    {
        public int? UserId => null;
    }
}
