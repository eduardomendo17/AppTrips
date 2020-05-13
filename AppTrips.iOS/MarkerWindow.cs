using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MapKit;
using UIKit;

namespace AppTrips.iOS
{
    public class MarkerWindow : MKAnnotationView
    {
        public string Name { get; set; }

        public MarkerWindow(IMKAnnotation annotation, string id) : base(annotation, id)
        {
        }
    }
}