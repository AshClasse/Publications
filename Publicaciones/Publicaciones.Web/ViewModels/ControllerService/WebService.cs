using Newtonsoft.Json;
using Publicaciones.Application.DTO.BasesDto;
using Publicaciones.Web.Responses.Core;

namespace Publicaciones.Web.ViewModels.ControllerService
{
    public class WebService : IWebService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public WebService( IConfiguration configuration)
        {
            _httpClient = new HttpClient (new HttpClientHandler());
            _configuration = configuration;
        }

        public BaseResponse<T> GetData<T>(string URL)
        {
            BaseResponse<T> baseres = new BaseResponse<T>();

            using (var response = _httpClient.GetAsync($"{URL}").Result)
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string APIres = response.Content.ReadAsStringAsync().Result;
                        baseres = JsonConvert.DeserializeObject<BaseResponse<T>>(APIres);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message.ToString());
                };
            }

            return baseres;
        }

        public T PostData<T>(string URL, object model)
        {
            try
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");

                using (var response = _httpClient.PostAsync(URL, content).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        var responseData = JsonConvert.DeserializeObject<BaseResponse<T>>(apiResponse);

                        if (!responseData.Success)
                        {
                            throw new ApplicationException(responseData.Message.ToString());
                        }
                        return responseData.Data;

                    }
                    else
                    {
                        throw new ApplicationException("Error connecting to API.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
