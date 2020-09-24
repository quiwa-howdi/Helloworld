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
        [Display(Name = "���Ϯy ")]
        Aries,
        [Display(Name = "�����y")]
        Taurus,
        [Display(Name = "���l�y")]
        Gemini,
        [Display(Name = "���ɮy")]
        Cancer,
        [Display(Name = "��l�y")]
        Leo,
        [Display(Name = "�B�k�y")]
        Virgo,
        [Display(Name = "�ѯ��y")]
        Libra,
        [Display(Name = "���Ȯy")]
        Scorpio,
        [Display(Name = "�g��y")]
        Sagittarius,
        [Display(Name = "���~�y")]
        Capricorn,
        [Display(Name = "���~�y")]
        Aquarius,
        [Display(Name = "�����y")]
        Pisces

    }//��bnamespace�U�A�Ӥ��O���class��
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "�d�����",Prompt = "��J�P�y"), Required(ErrorMessage = "������J")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "�P�y�W��"), Required(ErrorMessage = "�������")]
        public Horoscope Selection { get; set; } //?�~��Onull�A�~��Q�P�O�A�_�h�|�Q��ȩάOempty
        [BindProperty]
        [Display(Name = "�P�y�S��")]
        public string Property { get; set; }

        public void OnGet()
        {
            Message = "Ĳ�oOnGet";
            ViewData["Title"] = "�P�y����";
        }

        public void OnPostQuery()
        {
            Message = "Ĳ�oOnPostQuery";

           
        }
        public IActionResult OnPostNew()
        {
            Message = "Ĳ�oOnPostNew";
            if (ModelState.IsValid)
            {
                
                TempData["Keyword"] = Keyword;
                //TempData["Message"] = Message;
                TempData["Selection"] = Selection.ToString();
                if (Property != null)
                {
                    TempData["Property"] = Property;
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
        public void OnPostEdit()
        {
            Message = "Ĳ�oOnPostEdit";
            if (ModelState.IsValid)
            {
                Message+= ",�P�y�W�٬�:"+(Horoscope)Selection; 
            }

                
        }
        public void OnPost()
        {
            Message = "Ĳ�oOnPost";
        }

    }
}
