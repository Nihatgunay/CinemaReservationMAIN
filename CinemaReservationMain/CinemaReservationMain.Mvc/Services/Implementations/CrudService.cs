﻿using CinemaReservationMain.Mvc.ApiResponseMessages;
using CinemaReservationMain.Mvc.Areas.Admin.ViewModels.MovieVMs;
using CinemaReservationMain.Mvc.Services.Interfaces;
using RestSharp;

namespace CinemaReservationMain.Mvc.Services.Implementations
{
    public class CrudService : ICrudService
    {
        private readonly RestClient _restClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CrudService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _restClient = new RestClient(_configuration.GetSection("Api:URL").Value);
            var token = _httpContextAccessor.HttpContext.Request.Cookies["token"];

            if (token != null)
            {
                _restClient.AddDefaultHeader("Authorization", "Bearer " + token);
            }
        }

        public async Task Create<T>(string endpoint, T entity) where T : class
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(entity);

            var response = await _restClient.ExecuteAsync<ApiResponseMessage<T>>(request);
            if (!response.IsSuccessful) throw new Exception();
        }

        public async Task Delete<T>(string endpoint, int id)
        {
            var request = new RestRequest(endpoint, Method.Delete);

            var response = await _restClient.ExecuteAsync<ApiResponseMessage<T>>(request);
            if (!response.IsSuccessful) throw new Exception();
        }

        public async Task<T> GetAllAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
				var errorMessage = $"Error: {response.StatusCode}. Content: {response.Content}";
				throw new Exception(errorMessage);
            }

            return response.Data.Data;
        }

        public async Task<T> GetByIdAsync<T>(string endpoint, int id)
        {
            if (id < 1) throw new Exception();
            var request = new RestRequest(endpoint, Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception(response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception(response.Data.ErrorMessage);
                }
            }

            return response.Data.Data;
        }


        public async Task Update<T>(string endpoint, T entity) where T : class
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(entity);

            var response = await _restClient.ExecuteAsync<ApiResponseMessage<T>>(request);

            if (!response.IsSuccessful)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest && response.Data.PropertyName is not null)
                {
                    throw new Exception(response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception(response.Data.ErrorMessage);
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new Exception(response.Data.ErrorMessage);
                }
            }
        }
    }
}
