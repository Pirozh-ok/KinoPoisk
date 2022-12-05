using KinoPoisk.DomainLayer.Entities;

namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class AuthResponseDTO<TData> {
        public TData Data { get; set; }
        public string AccessToken { get; set; }
    }
}
