namespace Weat.UI.Identity
{
    public class WeatUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string Password{ get; set; }
        public string PreferredLanguageCode { get; set; }
        public string CivilityId { get; set; }
        public bool isActive { get; set; }
        public int ActivationCode { get; set; }
    }
}