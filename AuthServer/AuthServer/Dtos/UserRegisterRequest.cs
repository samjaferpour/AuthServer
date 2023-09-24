namespace AuthServer.Dtos
{
    public class UserRegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
