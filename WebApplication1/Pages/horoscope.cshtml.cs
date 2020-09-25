using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; // Display�BRequired

namespace WebApplication1
{

    public enum Horoscope {
        [Display(Name = "����")]
        All,
        [Display(Name = "�w�Q�ɾ\")]
        Borrowed,
        [Display(Name = "�Ѧb�]")]
        Unborrow,


    }//��bnamespace�U�A�Ӥ��O���class��
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�ѦW",Prompt = "�ж�J���y�W��"), Required(ErrorMessage = "���y�W�٥�����J")] //??�i�H�����M������ܼƶ�
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "���y���A")]//, Required(ErrorMessage = "�������")
        public Horoscope Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "���y�@��")]
        public string Author { get; set; }

        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            ViewData["Title"] = "���y�ɾ\�t��";
            TempData["State"] = "";
        }

        public void OnPostQuery()
        {
            Message = "Ĳ�oOnPostQuery";

           
        }
        public IActionResult OnPostEdit()
        {
            TempData["State"] = "Edit";
            Message = "Ĳ�oOnPostEdit";
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
                               
                Message += " �A��J���ҳq�L";
                return Redirect("/horo_add");
            }
            else
            {
                Message += "���ҨS�L";
                return Page();
            }
            
        }
        public void OnPostNew()
        {
            Message = "Ĳ�oOnPostNew";
            if (ModelState.IsValid)
            {
                Message+= ",�ѦW��:"+(Horoscope)Selection; 
            }

                
        }
        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }

    }
}
