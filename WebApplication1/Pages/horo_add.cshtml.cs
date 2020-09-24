using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired

namespace WebApplication1
{

   
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�d�����",Prompt = "��J�P�y"), Required(ErrorMessage = "������J")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "�P�y�W��"), Required(ErrorMessage = "�������")]
        public string Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "�P�y�S��")]
        public string Property { get; set; }

        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            ViewData["Title"] = "�P�y����";
            //Keyword = TempData["Keyword"].ToString();
            Selection = TempData["Selection"].ToString();
            Property = TempData["Property"].ToString();
            

        }

        public void OnPostQuery()
        {
            Message = "Ĳ�oOnPostQuery";

            if (ModelState.IsValid)
            {
                Message += " �A��J���ҳq�L";
            }
            else
            {
                Message += "���ҨS�L";
            }
        }
        public IActionResult OnPostNew()
        {
            

            Message = "Ĳ�oOnPostNew";
            return Redirect("/form");
        }
        public void OnPostEdit()
        {
            Message = "Ĳ�oOnPostEdit";
        }
        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }

    }
}
