namespace Ordering.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string name, Object key): base($"Entity {name} - {key} is not found.")
        {
            
        }
    }
}
