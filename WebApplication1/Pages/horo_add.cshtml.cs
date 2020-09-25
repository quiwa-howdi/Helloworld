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
        public Horoscope Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "�@��")]
        public string Author { get; set; }
        public string Pub { get; set; }
        public string Pubdate { get; set; }
        public void OnGet(int no,string handler)
        {
            Message = "Ĳ�oOnGet";
            if (handler == "Edit")
            {
                ViewData["Title"] = "�s��ѥ�";
                //���� �o��n���ѽX
                List<Book> books = TempData["books"] as List<Book>;
                Book editbook = books[no - 1];
                Selection = editbook.selction;
                Author = editbook.author;
                Keyword = editbook.keyword;

            }
            else
            {
                ViewData["Title"] = "�s�W�ѥ�";
            }
        }

        public void OnPost(string publisher)
        {
            if (ModelState.IsValid)
            {
                Message = "Ĳ�oOnPost";
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

                Message += " �A��J���ҳq�L";
                //return Redirect("/horo_add");
            }
            else
            {
                Message += "���ҨS�L";
                //return Page();
            }
        }
    }
}
