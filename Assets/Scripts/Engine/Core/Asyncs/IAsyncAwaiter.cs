using System.Runtime.CompilerServices;

namespace Engine.Core.Asyncs
{
    public interface IAsyncAwaiter<out T> : INotifyCompletion
    {
        bool IsCompleted { get; }
        T GetResult();
    }
}
