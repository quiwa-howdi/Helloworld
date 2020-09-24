using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required

namespace WebApplication1
{

   
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "查詢欄位",Prompt = "填入星座"), Required(ErrorMessage = "必須輸入")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "星座名稱"), Required(ErrorMessage = "必須選擇")]
        public string Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "星座特質")]
        public string Property { get; set; }

        public void OnGet()
        {
            Message = "觸發OnGet";
            ViewData["Title"] = "星座介紹";
            //Keyword = TempData["Keyword"].ToString();
            Selection = TempData["Selection"].ToString();
            Property = TempData["Property"].ToString();
            

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
