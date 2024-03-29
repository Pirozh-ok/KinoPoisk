﻿using KinoPoisk.DomainLayer.DTOs.UserDTO;
using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.PresentationLayer.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KinoPoisk.PresentationLayer.Controllers {
    [Authorize]
    public class AccountController : BaseController {
        private readonly IUserService _userService;

        public AccountController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserDTO userDto) {
            var result = await _userService.CreateAsync(userDto);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromQuery] LoginDTO loginData) {
            var result = await _userService.LoginAsync(loginData);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [AllowAnonymous]
        [HttpGet("login-google")]
        public async Task<IActionResult> GoogleLogin() {
            //return string for redirect to google authorization
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login-google/{token}")]
        public async Task<IActionResult> GoogleLogin([FromRoute] string token) {
            //check got on front data from google and generate access token
            var result = await _userService.AuthorizationWithGoogle(token);
            return GetResult(result, (int)HttpStatusCode.Created);
        }

        [HttpPut("confirm-email")]
        public async Task<IActionResult> ConfirmEmail() {
            var result = await _userService.ConfirmEmailAsync();
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, string email) {
            var result = await _userService.VerificationConfirmationTokenAsync(token, email);
            return GetResult(result, (int)HttpStatusCode.OK);
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromQuery] string email) {
            var result = await _userService.SendResetPasswordEmailAsync(email);
            return GetResult(result, (int)HttpStatusCode.NoContent);
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordData) {
            var result = await _userService.ResetPasswordAsync(resetPasswordData);
            return GetResult(result, (int)HttpStatusCode.NoContent); 
        }
    }
}
