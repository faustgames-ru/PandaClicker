using Engine.Core.Asyncs;

namespace Engine.Core.Actions
{
    public interface IActionEntry
    {
        AsyncState State { get; }
        void Invoke();
    }
}
