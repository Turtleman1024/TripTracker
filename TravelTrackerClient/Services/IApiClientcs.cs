using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TravelTrackerAPI.Models;

namespace TravelTrackerClient.Services
{
    public interface IApiClient
    {
        Task<List<Trip>> GetTripsAsync();
        Task<Trip> GetTripByIdAsync(int id);
        Task PutTripAync(Trip tripToUpdate);
        Task PostTripAsync(Trip tripToAdd);
    }

    public class ApiClient : IApiClient
    {
        private readonly HttpClient _HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<Trip> GetTripByIdAsync(int id)
        {
            var response = await _HttpClient.GetAsync($"/api/Trips/{id}");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<Trip>();
        }

        public async Task<List<Trip>> GetTripsAsync()
        {
            var response = await _HttpClient.GetAsync("/api/Trips");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsJsonAsync<List<Trip>>();
        }

        public async Task PostTripAsync(Trip tripToAdd)
        {
            var response = await _HttpClient.PostJsonAsync("/api/Trips/", tripToAdd);
            
            response.EnsureSuccessStatusCode();
        }

        public async Task PutTripAync(Trip tripToUpdate)
        {
            var response = await _HttpClient.PutJsonAsync($"/api/Trips/{tripToUpdate.Id}", tripToUpdate);
            
            response.EnsureSuccessStatusCode();
        }
    }
}
