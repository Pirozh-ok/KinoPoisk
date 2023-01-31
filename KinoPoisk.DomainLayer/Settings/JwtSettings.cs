namespace KinoPoisk.DomainLayer.Settings {
    public class JwtSettings {
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string TokenValidityInSecond { get; set; }
    public string Key { get; set; }
    public int RefreshTokenValidityInDays { get; set; }
    public int ConfirmEmailTokenValidityInDay { get; set; }
    }
}
