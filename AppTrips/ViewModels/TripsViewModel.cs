using AppTrips.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace AppTrips.ViewModels
{
    public class TripsViewModel : BaseViewModel
    {
        static TripsViewModel _instance;

        ObservableCollection<TripModel> _Trips;
        public ObservableCollection<TripModel> Trips 
        { 
            get => _Trips; 
            set => SetProperty(ref _Trips, value); 
        }

        public TripsViewModel()
        {
            // Indicamos a esta variable apunte a esta instancia
            _instance = this;

            Trips = new ObservableCollection<TripModel>
            {
                new TripModel
                {
                    ID = 1,
                    Title = "Nueva York",
                    Rating = 4,
                    Notes = "Estatua de la libertad",
                    TripDate = new DateTime(2020, 2, 18),
                    Latitude = 23.45453675,
                    Longitude = -12.454666,
                    ImageUrl = "https://larepublica.es/wp-content/uploads/2017/06/Captura-de-pantalla-2017-06-21-a-las-14.12.05.jpg"
                },
                new TripModel
                {
                    ID = 2,
                    Title = "Paris",
                    Rating = 5,
                    Notes = "Torre Eiffel",
                    TripDate = new DateTime(2019, 12, 24),
                    Latitude = 31.3556537,
                    Longitude = -16.354666,
                    ImageUrl = "https://i.ytimg.com/vi/AlnmjcIzdOU/maxresdefault.jpg"
                },
                new TripModel
                {
                    ID = 3,
                    Title = "Checoslovaquia",
                    Rating = 3,
                    Notes = "Checoslovacos",
                    TripDate = new DateTime(2017, 5, 10),
                    Latitude = 19.34665653,
                    Longitude = -10.565657890,
                    ImageUrl = "https://i.blogs.es/56ded0/ral128531876.800x600w/original.jpg"
                }
            };
        }

        public static TripsViewModel GetInstance()
        {
            if (_instance == null) _instance = new TripsViewModel();
            return _instance;
        }

        public async void AddNewTrip(TripModel newTrip)
        {
            newTrip.ID = Trips.Count + 1;
            Trips.Add(newTrip);
            await Application.Current.MainPage.DisplayAlert("AppTrips", "El viaje fue creado exitosamente", "Ok");
        }

        public async void ModifyTrip(TripModel oldTrip)
        {
            for(int index = 0; index < Trips.Count; index++)
            {
                if (Trips[index].ID == oldTrip.ID)
                {
                    Trips[index] = oldTrip;
                    await Application.Current.MainPage.DisplayAlert("AppTrips", "El viaje fue modificado exitosamente", "Ok");
                    return;
                }
            }
        }
    }
}
