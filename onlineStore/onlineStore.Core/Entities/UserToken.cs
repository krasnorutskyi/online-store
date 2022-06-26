namespace onlineStore.Core.Entities
{
    public class UserToken : EntityBase
    {
        public string RefreshToken { get; set; }
        
        public DateTime RefreshTokenExpireTime { get; set; }
    }
}