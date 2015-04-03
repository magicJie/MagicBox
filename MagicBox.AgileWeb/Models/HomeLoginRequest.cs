﻿using System.ComponentModel.DataAnnotations;

namespace MagicBox.AgileWeb.Models
{
    public class HomeLoginRequest
    {
        public HomeLoginRequest()
        {
            UserName = string.Empty;
            Password = string.Empty;
        }
        [StringLength(32)]
        [Required]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9._]+\.[A-Za-z]{2,4}", ErrorMessage = "邮箱地址格式不正确")]
        [DataType(DataType.EmailAddress)]
        public string UserName{ get; set; }

        [StringLength(32)]
        [Required]
        [Display(Name = "登录密码")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void Trim()
        {
            if (!string.IsNullOrEmpty(UserName)) UserName = UserName.Trim();
            if (!string.IsNullOrEmpty(Password)) Password = Password.Trim();
        }
    }
}
