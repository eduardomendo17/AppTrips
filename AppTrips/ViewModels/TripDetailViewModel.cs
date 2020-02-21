using AppTrips.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTrips.ViewModels
{
    public class TripDetailViewModel : BaseViewModel
    {
        string _Title;
        public string Title 
        { 
            get => _Title;
            set => SetProperty(ref _Title, value); 
        }

        public TripDetailViewModel()
        {
        }

        public TripDetailViewModel(TripModel trip)
        {
            Title = trip.Title;
        }
    }
}
