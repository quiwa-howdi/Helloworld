using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Data.SqlClient;
//using WebApplication1.Model;

namespace WebApplication1
{
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "書名", Prompt = "填入書本名稱"), Required(ErrorMessage = "必須輸入")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "狀態"), Required(ErrorMessage = "必須選擇")]
        public Statuses Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "作者")]
        public string Author { get; set; }
        public string Pub { get; set; }
        public string Pubdate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        //public Model.SqlClass connect = new SqlClass();
        
        //public Book editbook { get; set; }
       

        public void OnGet(int no,string handler)
        {
            
            Message = "觸發OnGet";
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //不管怎樣都要取出來
            TempData.Keep("books");//每次取出來後都建議keep住
            if (handler == "Edit")
            {
                ViewData["Title"] = "編輯書目";
                //取書 這邊要先解碼
                Book editbook = new Book();
                editbook = Books[no - 1];
                Selection = editbook.Status;
                Author = editbook.Author;
                Keyword = editbook.Name;
            }
            else
            {
                ViewData["Title"] = "新增書目";
            }
        }

        public IActionResult OnPost(int no, string handler)
        {
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //不管怎樣都要取出來
            TempData.Keep("books");// 每次取出來後都建議keep住
            if (ModelState.IsValid)
            {
                Book editbook = new Book();
                Message += editbook.Status;
                Message = "觸發OnPost";
                editbook.Status = Selection;
                editbook.Author = Author;
                editbook.Name = Keyword;
                if (handler == "Edit")
                {
                    //把指定的書目取代
                    Books[no - 1] = editbook;
                }
                else
                {
                    Books.Add(editbook);
                    //ADD新的書目
                }
                Message += " ，輸入驗證通過";
                //return Redirect("/horo_add");
                TempData["books"] = JsonConvert.SerializeObject(Books);
                return Redirect("/horoscope");
            }
            else
            {
                Message += "驗證沒過";
                return Page();
            }
        }
    }
}
