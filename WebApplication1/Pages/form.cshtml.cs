using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{

    public enum Sex { none, Male, Female }//放在namespace下，而不是放到class內
    public class FormPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "姓名"),Required(ErrorMessage = "必須輸入")]
        public string Name { get; set; }
        
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }

        

      
        
        public void OnGet()
        {
            ViewData["Title"] = "標題";
            Message = "目前剛觸發OnGet";
        }
        public void OnPostSub(string phone)
        {
            string Email = Request.Form["email"];
            Message = "觸發OnPost, phone=" + phone+",Name="+Name+",Email="+Email;
        }
        //-------------------單獨onpost
        public void OnPostDelete()
        {
            Message = "觸發OnPostDelete";
        }

        public void OnPostEdit()
        {
            Message = "觸發OnPostEdit";
        }

        public void OnPostView()
        {
            Message = "觸發OnPostView";
        }

    }
}
