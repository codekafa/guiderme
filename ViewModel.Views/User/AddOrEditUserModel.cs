using Microsoft.AspNetCore.Http;

namespace ViewModel.Views.User
{
    public class AddOrEditUserModel : BaseParamModel
    {
        public long ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMailActivated { get; set; }
        public bool IsMobileActivated { get; set; }
        public string PhotoUrl { get; set; }
        public IFormFile Photo { get; set; }
    }
}
