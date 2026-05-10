using System.Net.Http.Json;
using QRcodeAttendance.Models.Admin;

namespace QRcodeAttendance.Services
{
    public class AdminService
    {
        private readonly HttpClient _http;

        public AdminService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<SectionModel>> GetSectionsAsync()
        {
            return await _http.GetFromJsonAsync<List<SectionModel>>("api/Admin/sections")
                   ?? new List<SectionModel>();
        }

        public async Task<List<SubjectModel>> GetSubjectsAsync()
        {
            return await _http.GetFromJsonAsync<List<SubjectModel>>("api/Admin/subjects")
                   ?? new List<SubjectModel>();
        }

        public async Task<bool> CreateSubjectAsync(CreateSubjectModel model)
        {
            var response = await _http.PostAsJsonAsync("api/Admin/subjects", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<AdminStudentModel>> GetPendingStudentsAsync()
        {
            return await _http.GetFromJsonAsync<List<AdminStudentModel>>("api/Admin/pending-students")
                   ?? new List<AdminStudentModel>();
        }

        public async Task<List<AdminStudentModel>> GetStudentsAsync()
        {
            return await _http.GetFromJsonAsync<List<AdminStudentModel>>("api/Admin/students")
                   ?? new List<AdminStudentModel>();
        }

        public async Task<HttpResponseMessage> CreateTeacherAsync(AdminTeacherCreateModel model)
        {
            return await _http.PostAsJsonAsync("api/Admin/teachers", model);
        }

        public async Task<HttpResponseMessage> CreateStudentAsync(AdminStudentCreateModel model)
        {
            return await _http.PostAsJsonAsync("api/Admin/students", model);
        }

        public async Task<HttpResponseMessage> ApproveStudentAsync(int userId)
        {
            return await _http.PutAsync($"api/Admin/approve-student/{userId}", null);
        }

        public async Task<HttpResponseMessage> RejectStudentAsync(int userId)
        {
            return await _http.PutAsync($"api/Admin/reject-student/{userId}", null);
        }

        public async Task<bool> RemoveTeacherAsync(int teacherId)
        {
            var response = await _http.PutAsync($"api/Admin/teachers/{teacherId}/remove", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DropStudentAsync(int studentId)
        {
            var response = await _http.PutAsync($"api/Admin/students/{studentId}/drop", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RestoreUserAsync(int userId)
        {
            var response = await _http.PutAsync($"api/Admin/users/{userId}/restore", null);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateSectionAsync(CreateSectionModel model)
        {
            var response = await _http.PostAsJsonAsync(
                $"{ApiConfig.BaseUrl}/api/Admin/sections",
                model
            );

            return response.IsSuccessStatusCode;
        }
    }
}