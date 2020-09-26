using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System.Data.SqlClient;
//using WebApplication1.Model;

namespace WebApplication1
{
    public class Horo_AddPageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�ѦW", Prompt = "��J�ѥ��W��"), Required(ErrorMessage = "������J")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "���A"), Required(ErrorMessage = "�������")]
        public Statuses Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "�@��")]
        public string Author { get; set; }
        public string Pub { get; set; }
        public string Pubdate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        //public Model.SqlClass connect = new SqlClass();
        
        //public Book editbook { get; set; }
       

        public void OnGet(int no,string handler)
        {
            
            Message = "Ĳ�oOnGet";
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //���ޫ�˳��n���X��
            TempData.Keep("books");//�C�����X�ӫ᳣��ĳkeep��
            if (handler == "Edit")
            {
                ViewData["Title"] = "�s��ѥ�";
                //���� �o��n���ѽX
                Book editbook = new Book();
                editbook = Books[no - 1];
                Selection = editbook.Status;
                Author = editbook.Author;
                Keyword = editbook.Name;
            }
            else
            {
                ViewData["Title"] = "�s�W�ѥ�";
            }
        }

        public IActionResult OnPost(int no, string handler)
        {
            Books = JsonConvert.DeserializeObject<List<Book>>(TempData["books"].ToString());  //���ޫ�˳��n���X��
            TempData.Keep("books");// �C�����X�ӫ᳣��ĳkeep��
            if (ModelState.IsValid)
            {
                Book editbook = new Book();
                Message += editbook.Status;
                Message = "Ĳ�oOnPost";
                editbook.Status = Selection;
                editbook.Author = Author;
                editbook.Name = Keyword;
                if (handler == "Edit")
                {
                    //����w���ѥب��N
                    Books[no - 1] = editbook;
                }
                else
                {
                    Books.Add(editbook);
                    //ADD�s���ѥ�
                }
                Message += " �A��J���ҳq�L";
                //return Redirect("/horo_add");
                TempData["books"] = JsonConvert.SerializeObject(Books);
                return Redirect("/horoscope");
            }
            else
            {
                Message += "���ҨS�L";
                return Page();
            }
        }
    }
}
