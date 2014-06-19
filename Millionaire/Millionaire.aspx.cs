using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Millionaire
{
    public partial class Millionaire : System.Web.UI.Page
    {
        private static List<Question> Questions
        {
            get
            {
                return _questions;
            }
        }
        private static List<Question> _questions = new List<Question>() 
                {
                    new Question() {Text = "2+2", Variants = new List<string>(){"2", "3", "4", "5"}, Right = 2},
                    new Question() {Text = "2+3", Variants = new List<string>(){"2", "3", "4", "5"}, Right = 3},
                    new Question() {Text = "2+4", Variants = new List<string>(){"2", "3", "6", "5"}, Right = 2},
                    new Question() {Text = "2+5", Variants = new List<string>(){"2", "3", "7", "5"}, Right = 2},
                    new Question() {Text = "2+6", Variants = new List<string>(){"2", "3", "8", "5"}, Right = 2},
                    new Question() {Text = "2+7", Variants = new List<string>(){"2", "3", "9", "5"}, Right = 2},
                };
        private int _index;
        private Question _question;
        private int _score;

        protected void Page_Load(Object element, EventArgs args)
        {
            if (this.ViewState["score"] == null)
            {
                this.ViewState["score"] = 0;
                this.ViewState["question"] = 0;
            }
            this._index = (int)this.ViewState["question"];
            this._score = (int)this.ViewState["score"];
            if (this.IsPostBack && this.SetQuestion())
            {
                bool isRight = CheckAnswer();                

                if (isRight)
                {
                    this.ViewState["score"] = this._score + 100;
                    this.ViewState["question"] = ++this._index;
                //    this.lblStatus.Text = "OK";
                    this.lblStatus.Attributes.Add("class", "ok");
                }
                else
                {
                //    this.lblStatus.Text = "Wrong answer";
                    this.lblStatus.Attributes.Add("class", "wrong");
                }
            }
            this.DataBind();
            if ((int)this.ViewState["score"] < Millionaire.Questions.Count() * 100)
            {
                if (this.SetQuestion())
                {
                    RenderQuestion();
                }
            }
            else
            {
                this.form1.InnerHtml = "<div>You win</div>";
            }
        }

        private bool SetQuestion()
        {
            if (_index < Millionaire.Questions.Count())
            {
                this._question = Millionaire.Questions[_index];
                return true;
            }
            return false;
        }

        private bool CheckAnswer()
        {
            var answer = this.rblAnswers.SelectedValue;
            return this._question.Right.ToString() == answer;
        }

        protected void RenderQuestion()
        {
            int index = 0;
            this.lblQuestionText.Text = String.Format("{0} ?", this._question.Text);
            this.lblQuestionNum.Text = String.Format("Question num {0}", this._index);
            this.rblAnswers.Items.Clear();
            foreach (string variant in this._question.Variants)
            {
                this.rblAnswers.Items.Add(new ListItem() { Value = (index++).ToString(), Text = variant });
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }
    }
}