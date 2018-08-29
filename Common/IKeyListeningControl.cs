using System.Windows.Input;

namespace Common
{
    public interface IKeyListeningControl
    {
        void HandleKey(Key key);
    }
}