using AppTrips.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppTrips.Services
{
    public class ApiService
    {
        private string ApiUrl = "http://192.168.14.27/WebApiExample/";

        public ApiService()
        { 
        }

        public async Task<ApiResponse> GetDataAsync<T>(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };
                var response = await client.GetAsync(controller);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSuccess = false,
                        Message = result
                    };
                }

                var data = JsonConvert.DeserializeObject<ObservableCollection<T>>(result);
                return new ApiResponse
                {
                    IsSuccess = true,
                    Message = "Los viajes se obtuvieron correctamente",
                    Result = data
                };
            }
            catch (System.Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }

        public async Task<ApiResponse> PostDataAsync(string controller)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new System.Uri(ApiUrl)
                };

                var response = await client.PostAsync(controller, null);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new ApiResponse
                    {
                        IsSuccess = false,
                        Message = result.ToString(),
                        Result = null
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse>(result);
            }
            catch (System.Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    Result = null
                };
            }
        }
    }
}
