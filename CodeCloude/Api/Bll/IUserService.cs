using CodeCloude.Api.Models;
using CodeCloude.API.Models;
using CodeCloude.Extend;
using CodeCloude.Models;


namespace CodeCloude.Api.Services.BLL
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> ConfirmEmailAsync(string userId , string token);
        Task<UserManagerResponse> ForgetPasswordAsync(string Email, IFormFileCollection attachments);
        Task<UserManagerResponse> ResetPasswordAsync(ResetPasswordModel model);
        Task<UserModel> GetAccount(string id);
        Task<EditeAccountCustomRespon> EditeProffile(EditeProfileModel model);
        public IEnumerable<ApplicationUser> Getusers();
         Task<UserManagerResponse> EditePassword(EditePassword model);
        Task Addsubscripe(AddUserSubscriptionModel model);

    }
}
