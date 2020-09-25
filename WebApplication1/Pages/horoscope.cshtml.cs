using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required

namespace WebApplication1
{

    public enum Horoscope {
        [Display(Name = "全部")]
        All,
        [Display(Name = "已被借閱")]
        Borrowed,
        [Display(Name = "書在館")]
        Unborrow,


    }//放在namespace下，而不是放到class內
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "書名",Prompt = "請填入書籍名稱"), Required(ErrorMessage = "書籍名稱必須輸入")] //??可以直接套用欄位變數嗎
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "書籍狀態")]//, Required(ErrorMessage = "必須選擇")
        public Horoscope Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "書籍作者")]
        public string Author { get; set; }

        public void OnGet()
        {
            Message = "觸發OnGet";
            ViewData["Title"] = "書籍借閱系統";
            TempData["State"] = "";
        }

        public void OnPostQuery()
        {
            Message = "觸發OnPostQuery";

           
        }
        public IActionResult OnPostEdit()
        {
            TempData["State"] = "Edit";
            Message = "觸發OnPostEdit";
            if (ModelState.IsValid)
            {
                
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
                return Redirect("/horo_add");
            }
            else
            {
                Message += "驗證沒過";
                return Page();
            }
            
        }
        public void OnPostNew()
        {
            Message = "觸發OnPostNew";
            if (ModelState.IsValid)
            {
                Message+= ",書名為:"+(Horoscope)Selection; 
            }

                
        }
        public void OnPost()
        {
            Message = "觸發OnPost";
        }

    }
}
