using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{

    public enum Sex { none, Male, Female }//��bnamespace�U�A�Ӥ��O���class��
    public class FormPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�m�W"),Required(ErrorMessage = "������J")]
        public string Name { get; set; }
        
        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public int CategoryId { get; set; }

        

      
        
        public void OnGet()
        {
            ViewData["Title"] = "���D";
            Message = "�ثe��Ĳ�oOnGet";
        }
        public void OnPostSub(string phone)
        {
            string Email = Request.Form["email"];
            Message = "Ĳ�oOnPost, phone=" + phone+",Name="+Name+",Email="+Email;
        }
        //-------------------��Wonpost
        public void OnPostDelete()
        {
            Message = "Ĳ�oOnPostDelete";
        }

        public void OnPostEdit()
        {
            Message = "Ĳ�oOnPostEdit";
        }

        public void OnPostView()
        {
            Message = "Ĳ�oOnPostView";
        }

    }
}
