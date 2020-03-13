using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTrips.Models
{
    public class TripModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime TripDate { get; set; }
        public string Notes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }

        public TripModel()
        {
        }

        public ObservableCollection<TripModel> GetAll()
        {
            return new ObservableCollection<TripModel>
            {
                new TripModel
                {
                    ID = 1,
                    Title = "Nueva York desde Api",
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
                },
                new TripModel
                {
                    ID = 4,
                    Title = "Sin foto",
                    Rating = 3,
                    Notes = "No tengo la foto todavia",
                    TripDate = new DateTime(2017, 5, 10),
                    Latitude = 19.34665653,
                    Longitude = -10.565657890,
                    ImageUrl = ""
                }
            };
        }
    }
}
