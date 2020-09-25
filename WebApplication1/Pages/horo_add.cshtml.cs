using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired
using Microsoft.AspNetCore.Http.Extensions;

namespace WebApplication1
{

   
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�ѦW",Prompt = "��J�ѥ��W��"), Required(ErrorMessage = "������J")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "���A"), Required(ErrorMessage = "�������")]
        public string Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "�@��")]
        public string Author { get; set; }

        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            if (TempData["State"].ToString() == "Edit")
            {
                ViewData["Title"] = "�s��ѥ�";
                Selection = TempData["Selection"].ToString();
                Author = TempData["Property"].ToString();
                
            }
            else
            {
                ViewData["Title"] = "�s�W�ѥ�";
            }


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
