using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired

namespace WebApplication1
{
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�P�y�W��"), Required(ErrorMessage = "������J")]
        public string keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }
        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            ViewData["Title"] = "�P�y����";
        }

        public void OnPostQuery()
        {
            Message = "Ĳ�oOnPostQuery";
        }

        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }
    }
}
