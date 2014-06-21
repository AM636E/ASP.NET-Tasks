using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Translator.Service.TranslatorService;
//using TranslatorService;

namespace Translator
{
    public partial class TranslatorForm : System.Web.UI.Page
    {
        private YandexTranslatorService service;
        private Dictionary<string, string> countriesFrom;
        public Dictionary<string, string> Languages
        {
            get
            {
                if (Cache["languags"] == null)
                {
                    Cache["languags"] = ((Translator.Service.TranslatorService.YandexTranslatorService)service).GetLanguages();
                }

                return (Dictionary<string, string>)(Cache["languags"]);
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            string baseUrl = System.Configuration.ConfigurationManager.AppSettings["TranslatorBaseUrl"];
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["TranslatorApiKey"];

            service = new Translator.Service.TranslatorService.YandexTranslatorService(baseUrl, apiKey);
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.lbxCountries.DataSource = this.Languages;
            this.lbxCountries.DataBind();

            int selected = 0;
            if (this.Request.Cookies["lbxCountries"] != null)
            {
                selected = Convert.ToInt32(this.Request.Cookies["lbxCountries"].Value);
            }

            if (IsPostBack)
            {                
                selected = GetSelectedIndex(Request["lbxCountries"]);
                HttpCookie cookie = new HttpCookie("lbxCountries", this.GetSelectedIndex(Request["lbxCountries"]).ToString());
                cookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(cookie);
                int selectedTo = 0;
                if(Request.Cookies["translate"]!= null)
                {
                    if(Request.Cookies["translateTo"].Value.Split(':')[0] == selected.ToString())
                    {
                        selectedTo = Convert.ToInt32(Request.Cookies["translateTo"].Value.Split(':')[1]);
                    }
                }
                this.lbxCountriesTo.SelectedIndex = selectedTo;

                if (Request["lbxCountriesTo"] != null)
                {
                    try
                    {
                        HttpCookie toCookie = new HttpCookie("translateTo", selected + ":" + this.GetSelectedIndex(Request["lbxCountriesTo"]).ToString());
                        toCookie.Expires = DateTime.Now.AddDays(365);
                        Response.Cookies.Add(toCookie);
                        this.lblResult.Text = service.Translate(Request["lbxCountries"], this.txtTranslate.Text, Request["lbxCountriesTo"]);
                    }
                    catch (Exception ex)
                    {
                        this.lblResult.Text = ex.Message;
                    }
                }

            }


            this.lbxCountries.SelectedIndex = selected;

            this.lbxCountriesTo.DataSource = service.GetAvailableLangs(GetByIndex(selected));
            this.lbxCountriesTo.DataBind();

        }

        protected void Page_Render(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DataBind();
            }
        }


        protected string GetByIndex(int index)
        {
            return this.Languages.Keys.ElementAt(index);
        }

        protected int GetSelectedIndex(string lang)
        {
            int index = 0;

            foreach (var language in this.Languages.Keys)
            {
                if (language == lang)
                {
                    return index;
                }
                index++;
            }
            return 0;
        }

        protected void btnTranslate_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                this.lblResult.Text = ex.Message;
            }

        }

    }
}