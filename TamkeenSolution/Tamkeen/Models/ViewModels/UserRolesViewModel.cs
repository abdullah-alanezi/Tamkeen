namespace Tamkeen.Models.ViewModels
{
    public class UserRolesViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CurrentRole { get; set; }
        public List<string> AllRoles { get; set; }
    }
}
