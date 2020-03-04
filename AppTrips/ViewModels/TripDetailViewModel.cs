using AppTrips.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppTrips.ViewModels
{
    public class TripDetailViewModel : BaseViewModel
    {
        private int id;

        Command _saveCommand;
        public Command SaveCommand => _saveCommand ?? (_saveCommand = new Command(SaveAction));
        /*public Command SaveCommand 
        {
            get
            {
                if (_saveCommand != null) return new Command(SaveAction);
                return _saveCommand;
            }
        }*/

        string _Title;
        public string Title 
        { 
            get => _Title;
            set => SetProperty(ref _Title, value); 
        }

        string _Notes;
        public string Notes
        {
            get => _Notes;
            set => SetProperty(ref _Notes, value);
        }

        DateTime _TripDate;
        public DateTime TripDate
        {
            get => _TripDate;
            set => SetProperty(ref _TripDate, value);
        }

        double _Latitude;
        public double Latitude
        {
            get => _Latitude;
            set => SetProperty(ref _Latitude, value);
        }

        double _Longitude;
        public double Longitude
        {
            get => _Longitude;
            set => SetProperty(ref _Longitude, value);
        }

        int _Rating;
        public int Rating
        {
            get => _Rating;
            set => SetProperty(ref _Rating, value);
        }

        string _ImageUrl;
        public string ImageUrl
        {
            get => _ImageUrl;
            set => SetProperty(ref _ImageUrl, value);
        }

        public TripDetailViewModel()
        {
        }

        public TripDetailViewModel(TripModel trip)
        {
            if (trip != null)
            {
                id = trip.ID;
                Title = trip.Title;
                Notes = trip.Notes;
                Latitude = trip.Latitude;
                Longitude = trip.Longitude;
                Rating = trip.Rating;
                TripDate = trip.TripDate;
                ImageUrl = trip.ImageUrl;
            }
        }

        private async void SaveAction()
        {
            IsBusy = true;
            if (id == 0)
            {
                TripsViewModel.GetInstance().AddNewTrip(new TripModel
                {
                    Title = this.Title,
                    Notes = this.Notes,
                    Latitude = this.Latitude,
                    Longitude = Longitude,
                    Rating = Rating,
                    TripDate = TripDate,
                    ImageUrl = ImageUrl
                });
            }
            else
            {
                TripsViewModel.GetInstance().ModifyTrip(new TripModel
                {
                    ID = id,
                    Title = this.Title,
                    Notes = this.Notes,
                    Latitude = this.Latitude,
                    Longitude = Longitude,
                    Rating = Rating,
                    TripDate = TripDate,
                    ImageUrl = ImageUrl
                });
            }

            // Emulamos que esta haciendo algo
            await Task.Delay(5000);

            IsBusy = false;
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
