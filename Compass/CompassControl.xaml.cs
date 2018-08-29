using Common;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Compass
{
    /// <summary>
    /// Interaction logic for CompassControl.xaml
    /// </summary>
    public partial class CompassControl : KeyListeningControl
    {
        private int m_ImageId;

        public CompassControl()
        {
            InitializeComponent();
            LoadImageFromId();
        }

        public override void HandleKey(Key keyPressed)
        {
            switch (keyPressed)
            {
                case Key.Q:
                    OnQPressed();
                    break;
                case Key.E:
                    OnEPressed();
                    break;
                default:
                    break;
            }
        }

        private void OnQPressed()
        {
            UnrotateImageId();
            LoadImageFromId();
        }

        private void OnEPressed()
        {
            RotateImageId();
            LoadImageFromId();
        }

        private void RotateImageId()
        {
            if (m_ImageId == 3)
                m_ImageId = 0;
            else
                m_ImageId++;
        }

        private void UnrotateImageId()
        {
            if (m_ImageId == 0)
                m_ImageId = 3;
            else
                m_ImageId--;
        }

        private void LoadImageFromId()
        {
            switch (m_ImageId)
            {
                case 0:
                    Compass.Source = new BitmapImage(new Uri("Resource/TopRight.png", UriKind.Relative));
                    break;
                case 1:
                    Compass.Source = new BitmapImage(new Uri("Resource/BottomRight.png", UriKind.Relative));
                    break;
                case 2:
                    Compass.Source = new BitmapImage(new Uri("Resource/BottomLeft.png", UriKind.Relative));
                    break;
                case 3:
                    Compass.Source = new BitmapImage(new Uri("Resource/TopLeft.png", UriKind.Relative));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
