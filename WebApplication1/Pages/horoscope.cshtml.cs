using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display、Required
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace WebApplication1
{

    public class Book
    {
        public int idx { get; set; }
        public Horoscope selction { get; set; }
        public string keyword { get; set; }
        public string author { get; set; }
        public bool isshown { get; set; } = true;
    }

    public enum Horoscope
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
        public Horoscope Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "書籍作者")]
        public string Author { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public HoroscopePageModel() //建構子，頁面執行前先實作
        {
            // Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData.get 傳回 null
            
            ///先查看tempdata內有沒有資料，沒有的話初始化
            //var a = TempData["x"];
            //TempData["x"] = a;
            //   var b = a.where(x)


        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (TempData != null && TempData["books"] is string list)
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(list);
                TempData.Keep("books");
            }
            else
            {
                for (var i = 0; i < 5; i++)
                {
                    Books.Add(new Book() { idx = 0, selction = (Horoscope)(i % 3), keyword = $"Bookname{i}", author = $"Johnny{i}" });
                }
                TempData["books"] = JsonConvert.SerializeObject(Books);
            }

            base.OnPageHandlerExecuting(context);
        }

        public void OnGet()
        {
            try
            {
                Message = "觸發OnGet";
                ViewData["Title"] = "書籍借閱系統";
                TempData["RRRRRRR"] = "";
            }
            catch (Exception ex)
            { 
            
            }
        }

        public void OnPostQuery()
        {
            Books.ForEach(x => x.isshown = false);
            Books.Where(j => j.selction.Equals(Selection) && j.keyword.Contains(Keyword ?? string.Empty ) && j.author.Contains(Author ?? string.Empty)).ToList().ForEach(k => k.isshown = true);
            Message = "觸發OnPostQuery";
        }
        public void OnPostEdit(int no)//IActionResult
        {
            //TempData["books"] = Books;
            /////傳整本進tempdata 並且傳入button參數
            //TempData["No"] = no;

         
            //Message = "觸發OnPostEdit";
           

        }
        public void OnPostNew()
        {
           
        }
        public void OnPost()
        {
            Message = "觸發OnPost";
        }

    }
}
