﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ATB;

namespace _WebFramework.Views.Home
{
    public class CheckboxesView : BaseView
    {
        private CheckboxesViewElements Elements { get; } = new CheckboxesViewElements();
        public CheckboxesView(WebDriver driver) : base(driver) { }

        public bool Checkbox1IsSelected() => Actions.IsSelected(Elements.Checkbox1);
        public bool Checkbox2IsSelected() => Actions.IsSelected(Elements.Checkbox2);
    }
}