﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
