using AppTrips.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppTrips.ViewModels
{
    public class TripsViewModel : BaseViewModel
    {

        List<TripModel> _Trips;
        public List<TripModel> Trips 
        { 
            get => _Trips; 
            set => SetProperty(ref _Trips, value); 
        }

        public TripsViewModel()
        {
            Trips = new List<TripModel>
            {
                new TripModel
                {
                    Title = "Nueva York",
                    Rating = 4,
                    Notes = "Estatua de la libertad",
                    TripDate = new DateTime(2020, 2, 18),
                    Latitude = 23.45453675,
                    Longitude = -12.454666
                },
                new TripModel
                {
                    Title = "Paris",
                    Rating = 5,
                    Notes = "Torre Eiffel",
                    TripDate = new DateTime(2019, 12, 24),
                    Latitude = 31.3556537,
                    Longitude = -16.354666
                },
                new TripModel
                {
                    Title = "Checoslovaquia",
                    Rating = 3,
                    Notes = "Checoslovacos",
                    TripDate = new DateTime(2017, 5, 10),
                    Latitude = 19.34665653,
                    Longitude = -10.565657890
                }
            };

        }
    }
}
