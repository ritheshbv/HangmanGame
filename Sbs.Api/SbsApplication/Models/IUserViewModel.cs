namespace SbsApplication.Models
{
    public interface IUserViewModel
    {
        string Address { get; set; }
        string LoginName { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        int UserId { get; set; }
    }
}