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
using Microsoft.Kinect;

namespace KinectStreamTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor _sensor;
        MultiSourceFrameReader _reader;
        public MainWindow()
        {
            InitializeComponent();

            //initialise the kinect sensor
            _sensor = KinectSensor.GetDefault();

            //open the kinect sensor if not null
            if(_sensor != null)
            {
                _sensor.Open();
            }


            //Creates a new frame reader for correlating multiple frame sources.
            _reader = _sensor.OpenMultiSourceFrameReader(FrameSourceTypes.Color |
                                                         FrameSourceTypes.Depth |
                                                         FrameSourceTypes.Infrared);

            //     Event that fires whenever a frame is captured.
            //layman: Calls a method when receiving a frame of the FrameSourceTypes
            _reader.MultiSourceFrameArrived += Reader_MultiSourceFrameArrived;


        }

        public void Reader_MultiSourceFrameArrived(object sender, MultiSourceFrameArrivedEventArgs e)
        {
            //Get a reference to the multi-frame
            var reference = e.FrameReference.AcquireFrame();

            //Open color frame
            using (var frame = reference.ColorFrameReference.AcquireFrame())
            {
                if(frame != null)
                {
                    //Do something with the frame...
                }
            }

            //Open depth frame
            using (var frame = reference.DepthFrameReference.AcquireFrame())
            {
                if(frame != null)
                {
                    //do something with the frame...
                }
            }

            //Open Infrared frame
            using (var frame = reference.InfraredFrameReference.AcquireFrame())
            {
                if(frame!= null)
                {
                    //do something with the frame...
                }
            }


            



        }
        private ImageSource ToBitmap(ColorFrame frame)
        {
            int width = frame.FrameDescription.Width;
            int height = frame.FrameDescription.Height;

            //why bgra? it results in faster performance
            byte[] pixels = new byte[width * height * ((PixelFormats.Bgr32.BitsPerPixel + 7) / 8)];

            //kinect uses bgra
            if(frame.RawColorImageFormat == ColorImageFormat.Bgra)
            {

            }
        }



    }
}
