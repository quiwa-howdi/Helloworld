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
        public Horoscope Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "作者")]
        public string Author { get; set; }
        public string Pub { get; set; }
        public string Pubdate { get; set; }
        public void OnGet(int no,string handler)
        {
            Message = "觸發OnGet";
            if (handler == "Edit")
            {
                ViewData["Title"] = "編輯書目";
                //取書 這邊要先解碼
                List<Book> books = TempData["books"] as List<Book>;
                Book editbook = books[no - 1];
                Selection = editbook.selction;
                Author = editbook.author;
                Keyword = editbook.keyword;

            }
            else
            {
                ViewData["Title"] = "新增書目";
            }
        }

        public void OnPost(string publisher)
        {
            if (ModelState.IsValid)
            {
                Message = "觸發OnPost";
                Pub = publisher;
                Pubdate = Request.Form["publishDate"];
                TempData["Keyword"] = Keyword;
                TempData["Selection"] = Selection.ToString();
                if (Author != null)
                {
                    TempData["Property"] = Author;
                }
                else
                {
                    TempData["Property"] = "";
                }

                Message += " ，輸入驗證通過";
                //return Redirect("/horo_add");
            }
            else
            {
                Message += "驗證沒過";
                //return Page();
            }
        }
    }
}
