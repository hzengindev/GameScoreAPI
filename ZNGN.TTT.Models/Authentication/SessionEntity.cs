namespace ZNGN.TTT.Models.Authentication
{
    public class SessionEntity
    {
        public long ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public long ApplicationID { get; set; }
    }
}