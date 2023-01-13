namespace KinoPoisk.DomainLayer.DTOs.TokensDTO {
    public class RefreshTokenDTO {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
