using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenU.Api
{
    public class OpenUApi : IDisposable
    {
        public OpenuCredentials Credentials { get; set; }
        public bool IsAuthenticated
        {
            get
            {
                return !String.IsNullOrWhiteSpace(token);
            }
        }

        private HttpClient httpClient;
        private string token;

        const string ApiBaseUrl = "https://sheilta.apps.openu.ac.il/Main/api/MobileApi";

        public OpenUApi(OpenuCredentials credentials)
        {
            Credentials = credentials;
            httpClient = new HttpClient();
        }

        public async Task<OpenuLoginResult> AuthenticateAsync()
        {
            if (Credentials == null) throw new NullReferenceException("Credentials cannot be null");

            var data = new Dictionary<string, string>()
            {
                {"username", Credentials.UserName },
                {"studentId", Credentials.IdNumber },
                {"password", Credentials.Password },
                {"deviceId", "undefined" },
            };
            var httpResponse = await httpClient.PostAsync(ApiBaseUrl + "/Login", new FormUrlEncodedContent(data));

            var result = JsonConvert.DeserializeObject<OpenuLoginResult>(await httpResponse.Content.ReadAsStringAsync());
            if (result.Status == LoginStatus.Success)
            {
                token = result.Token.Substring(4); // cut "sso " prefix of token from server
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("sso", token); // add token to http client auth header
            }
            return result;
        }

        public void Logout()
        {
            token = null;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(""); // remove auth header
        }

        public async Task<List<OpenuCourseListEntry>> GetCoursesAsync()
        {
            if (!IsAuthenticated) throw new InvalidOperationException("Autentication is required for this action.");

            var httpResponse = await httpClient.GetAsync(ApiBaseUrl + "/Courses");
            return JsonConvert.DeserializeObject<List<OpenuCourseListEntry>>(await httpResponse.Content.ReadAsStringAsync());
        }



        public async Task<OpenuCourseDetails> GetCourseDetailsAsync(string courseId, string semester)
        {
            if (!IsAuthenticated) throw new InvalidOperationException("Autentication is required for this action.");


            var data = new Dictionary<string, string>()
            {
                {"id", courseId },
                {"semester", semester },
            };
            var httpResponse = await httpClient.PostAsync(ApiBaseUrl + "/CourseDetails", new FormUrlEncodedContent(data));
            return JsonConvert.DeserializeObject<OpenuCourseDetails>(await httpResponse.Content.ReadAsStringAsync());
        }

        public async Task<List<OpenuMessage>> GetMessagesAsync()
        {
            if (!IsAuthenticated) throw new InvalidOperationException("Autentication is required for this action.");

            var httpResponse = await httpClient.GetAsync(ApiBaseUrl + "/Messages");
            return JsonConvert.DeserializeObject<List<OpenuMessage>>(await httpResponse.Content.ReadAsStringAsync());
        }

        public async Task<List<OpenuActivity>> GetActivitiesAsync()
        {
            if (!IsAuthenticated) throw new InvalidOperationException("Autentication is required for this action.");

            var httpResponse = await httpClient.GetAsync(ApiBaseUrl + "/Activities");
            return JsonConvert.DeserializeObject<List<OpenuActivity>>(await httpResponse.Content.ReadAsStringAsync());
        }

        public void Dispose()
        {
            Logout();
            httpClient.Dispose();
        }

    }
}
