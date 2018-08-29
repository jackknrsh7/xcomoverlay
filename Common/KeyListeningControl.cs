using System.Windows.Controls;
using System.Windows.Input;

namespace Common
{
    public class KeyListeningControl : UserControl, IKeyListeningControl
    {
        public virtual void HandleKey(Key key)
        {
            
        }
    }
}