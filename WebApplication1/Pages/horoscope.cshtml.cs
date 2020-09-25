using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired
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
        [Display(Name = "��L")]
        Else,
        [Display(Name = "�w�Q�ɾ\")]
        Borrowed,
        [Display(Name = "�Ѧb�]")]
        Unborrow,


    }//��bnamespace�U�A�Ӥ��O���class��
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�ѦW", Prompt = "�ж�J���y�W��"), Required(ErrorMessage = "{0}������J")] //??�i�H�����M������ܼƶ�
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "���y���A")]//, Required(ErrorMessage = "�������")
        public Horoscope Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "���y�@��")]
        public string Author { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();

        public HoroscopePageModel() //�غc�l�A��������e����@
        {
            // Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData.get �Ǧ^ null
            
            ///���d��tempdata�����S����ơA�S�����ܪ�l��
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
                Message = "Ĳ�oOnGet";
                ViewData["Title"] = "���y�ɾ\�t��";
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
            Message = "Ĳ�oOnPostQuery";
        }
        public void OnPostEdit(int no)//IActionResult
        {
            //TempData["books"] = Books;
            /////�Ǿ㥻�itempdata �åB�ǤJbutton�Ѽ�
            //TempData["No"] = no;

         
            //Message = "Ĳ�oOnPostEdit";
           

        }
        public void OnPostNew()
        {
           
        }
        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }

    }
}
