using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1
{

    public class Book
    {
        public int Idx { get; set; }
        public Statuses Status { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool Isshown { get; set; } = true;
        public Guid Id { get; set; }
    }

    public enum Statuses
    {
        [Display(Name = "其他")]
        Else,
        [Display(Name = "已被借閱")]
        Borrowed,
        [Display(Name = "書在館")]
        Unborrow,


    }//放在namespace下，而不是放到class內
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "書名", Prompt = "請填入書籍名稱"), Required(ErrorMessage = "{0}必須輸入")] //??可以直接套用欄位變數嗎
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "書籍狀態")]//, Required(ErrorMessage = "必須選擇")
        public Statuses Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "書籍作者")]
        public string Author { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public Model.SqlClass SqlClass = new SqlClass();

        public HoroscopePageModel() //建構子，頁面執行前先實作
        {
            // Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData.get 傳回 null
            ///先查看tempdata內有沒有資料，沒有的話初始化
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (TempData != null && TempData["books"] is string list)
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(list);
                TempData.Keep("books");
            }
            else  //初始化時，tempdata內無資料，(因為過去在建構子判別)
            {
                for (var i = 0; i < 5; i++)
                {
                    Books.Add(new Book() { Idx = 0, Status = (Statuses)(i % 3), Name = $"Bookname{i}", Author = $"Johnny{i}" }); // *****初始化條件可以後續優化****
                }

                //Books = SqlClass.Sqlquery();
                //TempData["books"] = JsonConvert.SerializeObject(Books);
            }
            base.OnPageHandlerExecuting(context);
        }

        public void OnGet()
        {
            Message = "觸發OnGet";
            ViewData["Title"] = "書籍借閱系統";
        }

        public void OnPostQuery()
        {
            Books.ForEach(x => x.Isshown = false);
            Books.Where(j => j.Status.Equals(Selection) && j.Name.Contains(Keyword ?? string.Empty) && j.Author.Contains(Author ?? string.Empty)).ToList().ForEach(k => k.Isshown = true);
            Message = "觸發OnPostQuery";
        }
        public void OnPostEdit(int no)//IActionResult
        {
            //TempData["books"] = Books;
            /////傳整本進tempdata 並且傳入button參數
            //TempData["No"] = no;  
            //Message = "觸發OnPostEdit";
        }
        public void OnPostDelete(int no)
        {
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //不管怎樣都要取出來
            TempData.Keep("books");// 每次取出來後都建議keep住
            Books.RemoveAt(no - 1);
            TempData["books"] = JsonConvert.SerializeObject(Books);
        }
        public void OnPost()
        {
            Message = "觸發OnPost";
        }
        

    }
}
