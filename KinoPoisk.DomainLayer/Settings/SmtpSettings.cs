﻿using AutoMapper.Configuration.Conventions;

namespace KinoPoisk.DomainLayer.Settings {
    public class SmtpSettings {
        public string FromName {get;set;}
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public int ConfirmEmailTokenValidityInDay { get; set; }
    }
}
