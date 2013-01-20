using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;
using Microsoft.Xna.Framework.Media;

namespace TheReader.views
{
    public partial class camera : PhoneApplicationPage
    {
        PhotoCamera myCam;
        MediaLibrary mediaLib;
        public camera()
        {
            InitializeComponent();
            mediaLib = new MediaLibrary();
            myCam = new PhotoCamera(CameraType.Primary);
            myCam.CaptureCompleted += new EventHandler<CameraOperationCompletedEventArgs>(captureCompleted);
            myCam.CaptureImageAvailable += new EventHandler<ContentReadyEventArgs>(captureImageAvailable);
            viewfinderBrush.SetSource(myCam);
        }

        private void captureImageAvailable(object sender, ContentReadyEventArgs e)
        {
            string filename = "" + ".jpg";
            Dispatcher.BeginInvoke(delegate() {
                txtmsg.Text = "Image available";
            });
        }

        private void captureCompleted(object sender, CameraOperationCompletedEventArgs e)
        {
            Dispatcher.BeginInvoke(delegate() {
                txtmsg.Text = "Image captured";
            });
        }
    }
}