using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Common;
using Compass;

namespace OverlayMain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LowLevelKeyboardListener m_Listener;

        public MainWindow()
        {
            InitializeComponent();

            m_Listener = new LowLevelKeyboardListener();

            m_Listener.OnKeyPressed += OnListenerKeyDown;
            m_Listener.HookKeyboard();
        }

        private void Disposed(object sender, EventArgs e)
        {
            m_Listener.UnHookKeyboard();
            m_Listener.OnKeyPressed -= OnListenerKeyDown;
        }

        private void OnListenerKeyDown(object sender, KeyPressedArgs e)
        {
            foreach (var visual in this.GetChildren())
            {
                if (visual is KeyListeningControl control)
                {
                    control.HandleKey(e.KeyPressed);
                }
            }
        }
    }
}
