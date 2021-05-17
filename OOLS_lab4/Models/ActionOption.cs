using DevExpress.Mvvm;
using OOLS_lab4.Models.Beasts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOLS_lab4.Models
{
    public class ActionOption
    {
        public string Text { get; set; }
        public DelegateCommand Command { get; set; }
        protected ActionOption(string text)
        {
            Text = text;
        }
        public ActionOption(string text, DelegateCommand command)
        {
            Text = text;
            Command = command;
        }
    }

    //public class BeastActionOption : ActionOption
    //{
    //    public Beast Beast;
    //    public BeastActionOption(string text, DelegateCommand<Beast> command, Beast beast) : base(text)
    //    {
    //        Beast = beast;
    //    }
    //}
}
