﻿using System.ComponentModel.DataAnnotations;

namespace AonFreelancing.Models.Requests
{
    public record ResetPasswordReq(
        [Required, MinLength(6, ErrorMessage = "Too short password")]
        string Password,
    
        [Required, MinLength(6, ErrorMessage = "Too short password")]
        string ConfirmPassword,
    
        [Required, Phone, StringLength(14, MinimumLength = 14)]
        string PhoneNumber
    );
}
