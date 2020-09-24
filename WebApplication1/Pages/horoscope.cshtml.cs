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
        [Display(Name = "牧羊座 ")]
        Aries,
        [Display(Name = "金牛座")]
        Taurus,
        [Display(Name = "雙子座")]
        Gemini,
        [Display(Name = "巨蟹座")]
        Cancer,
        [Display(Name = "獅子座")]
        Leo,
        [Display(Name = "處女座")]
        Virgo,
        [Display(Name = "天秤座")]
        Libra,
        [Display(Name = "天蠍座")]
        Scorpio,
        [Display(Name = "射手座")]
        Sagittarius,
        [Display(Name = "摩羯座")]
        Capricorn,
        [Display(Name = "水瓶座")]
        Aquarius,
        [Display(Name = "雙魚座")]
        Pisces

    }//放在namespace下，而不是放到class內
    public class HoroscopePageModel : PageModel
    {
        [BindProperty]
        [Display(Name = "查詢欄位",Prompt = "填入星座"), Required(ErrorMessage = "必須輸入")]
        public string Keyword { get; set; }
        [BindProperty]
        public string Message { get; set; }

        [BindProperty]
        [Display(Name = "星座名稱"), Required(ErrorMessage = "必須選擇")]
        public Horoscope Selection { get; set; } //?才能是null，才能被判別，否則會被填值或是empty
        [BindProperty]
        [Display(Name = "星座特質")]
        public string Property { get; set; }

        public void OnGet()
        {
            Message = "觸發OnGet";
            ViewData["Title"] = "星座介紹";
        }

        public void OnPostQuery()
        {
            Message = "觸發OnPostQuery";

           
        }
        public IActionResult OnPostNew()
        {
            Message = "觸發OnPostNew";
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
                               
                Message += " ，輸入驗證通過";
                return Redirect("/horo_add");
            }
            else
            {
                Message += "驗證沒過";
                return Page();
            }
            
        }
        public void OnPostEdit()
        {
            Message = "觸發OnPostEdit";
            if (ModelState.IsValid)
            {
                Message+= ",星座名稱為:"+(Horoscope)Selection; 
            }

                
        }
        public void OnPost()
        {
            Message = "觸發OnPost";
        }

    }
}
