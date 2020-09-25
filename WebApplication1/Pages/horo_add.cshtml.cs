using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required
using Microsoft.AspNetCore.Http.Extensions;

namespace WebApplication1
{

   
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "書名",Prompt = "填入書本名稱"), Required(ErrorMessage = "必須輸入")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "狀態"), Required(ErrorMessage = "必須選擇")]
        public string Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "作者")]
        public string Author { get; set; }

        public void OnGet()
        {
            Message = "觸發OnGet";
            if (TempData["State"].ToString() == "Edit")
            {
                ViewData["Title"] = "編輯書目";
                Selection = TempData["Selection"].ToString();
                Author = TempData["Property"].ToString();
                
            }
            else
            {
                ViewData["Title"] = "新增書目";
            }


        }

        public void OnPostQuery()
        {
            Message = "觸發OnPostQuery";

            if (ModelState.IsValid)
            {
                Message += " ，輸入驗證通過";
            }
            else
            {
                Message += "驗證沒過";
            }
        }
        public IActionResult OnPostNew()
        {
            

            Message = "觸發OnPostNew";
            return Redirect("/form");
        }
        public void OnPostEdit()
        {
            Message = "觸發OnPostEdit";
        }
        public void OnPost()
        {
            Message = "觸發OnPost";
        }

    }
}
