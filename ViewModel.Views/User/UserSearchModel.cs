namespace ViewModel.Views.User
{
    public class UserSearchModel: BaseParamModel
    {
        public string Email { get; set; }

        public bool? IsMailActivated { get; set; }

        public bool? IsMobileActivated { get; set; }

    }
}
