using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required

namespace WebApplication1
{
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "星座名稱"), Required(ErrorMessage = "必須輸入")]
        public string keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "觸發OnGet";
            ViewData["Title"] = "星座介紹";
        }

        public void OnPostQuery()
        {
            Message = "觸發OnPostQuery";
        }

        public void OnPost()
        {
            Message = "觸發OnPost";
        }
    }
}
