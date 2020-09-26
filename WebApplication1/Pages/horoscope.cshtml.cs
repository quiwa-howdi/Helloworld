using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired
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
        public Statuses Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "���y�@��")]
        public string Author { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
        public Model.SqlClass SqlClass = new SqlClass();

        public HoroscopePageModel() //�غc�l�A��������e����@
        {
            // Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData.get �Ǧ^ null
            ///���d��tempdata�����S����ơA�S�����ܪ�l��
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            if (TempData != null && TempData["books"] is string list)
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(list);
                TempData.Keep("books");
            }
            else  //��l�ƮɡAtempdata���L��ơA(�]���L�h�b�غc�l�P�O)
            {
                for (var i = 0; i < 5; i++)
                {
                    Books.Add(new Book() { Idx = 0, Status = (Statuses)(i % 3), Name = $"Bookname{i}", Author = $"Johnny{i}" }); // *****��l�Ʊ���i�H�����u��****
                }

                //Books = SqlClass.Sqlquery();
                //TempData["books"] = JsonConvert.SerializeObject(Books);
            }
            base.OnPageHandlerExecuting(context);
        }

        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            ViewData["Title"] = "���y�ɾ\�t��";
        }

        public void OnPostQuery()
        {
            Books.ForEach(x => x.Isshown = false);
            Books.Where(j => j.Status.Equals(Selection) && j.Name.Contains(Keyword ?? string.Empty) && j.Author.Contains(Author ?? string.Empty)).ToList().ForEach(k => k.Isshown = true);
            Message = "Ĳ�oOnPostQuery";
        }
        public void OnPostEdit(int no)//IActionResult
        {
            //TempData["books"] = Books;
            /////�Ǿ㥻�itempdata �åB�ǤJbutton�Ѽ�
            //TempData["No"] = no;  
            //Message = "Ĳ�oOnPostEdit";
        }
        public void OnPostDelete(int no)
        {
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //���ޫ�˳��n���X��
            TempData.Keep("books");// �C�����X�ӫ᳣��ĳkeep��
            Books.RemoveAt(no - 1);
            TempData["books"] = JsonConvert.SerializeObject(Books);
        }
        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }
        

    }
}
