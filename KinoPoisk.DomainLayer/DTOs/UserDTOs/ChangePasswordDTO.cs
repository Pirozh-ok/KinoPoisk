﻿namespace KinoPoisk.DomainLayer.DTOs.UserDTO {
    public class ChangePasswordDTO {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
