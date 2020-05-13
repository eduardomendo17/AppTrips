using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppTrips.iOS.Renders;
using AppTrips.Models;
using AppTrips.Renders;
using CloudKit;
using CoreGraphics;
using Foundation;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace AppTrips.iOS.Renders
{
    public class CustomMapRenderer : MapRenderer
    {
        UIView customPinView;
        TripModel Trip;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                var nativeMap = Control as MKMapView;
                nativeMap.GetViewForAnnotation = null;
                nativeMap.DidSelectAnnotationView -= OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView -= OnDidDeselectAnnotationView;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                Trip = (e.NewElement as CustomMap).Trip;
                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
                nativeMap.DidSelectAnnotationView += OnDidSelectAnnotationView;
                nativeMap.DidDeselectAnnotationView += OnDidDeselectAnnotationView;
            }
        }

        protected override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;
            if (annotation is MKUserLocation) return null;

            annotationView = mapView.DequeueReusableAnnotation(Trip.Title);
            if (annotationView == null)
            {
                annotationView = new MarkerWindow(annotation, Trip.Title);
                annotationView.Image = UIImage.FromFile("pin.png");
                annotationView.CalloutOffset = new CGPoint(0, 0);
                ((MarkerWindow)annotationView).Name = "trip";
            }
            annotationView.CanShowCallout = true;
            return annotationView;
        }

        void OnDidSelectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            MarkerWindow customView = e.View as MarkerWindow;
            customPinView = new UIView();

            if (customView.Name.Equals("trip"))
            {
                customPinView.Frame = new CGRect(0, 0, 150, 84);
                var image = new UIImageView(new CGRect(0, 0, 200, 84));
                image.Image = UIImage.FromFile(Trip.ImageUrl);
                customPinView.AddSubview(image);
                customPinView.Center = new CGPoint(0, -(e.View.Frame.Height + 45));
                e.View.AddSubview(customPinView);
            }
        }

        void OnDidDeselectAnnotationView(object sender, MKAnnotationViewEventArgs e)
        {
            if (!e.View.Selected)
            {
                customPinView.RemoveFromSuperview();
                customPinView.Dispose();
                customPinView = null;
            }
        }
    }
}