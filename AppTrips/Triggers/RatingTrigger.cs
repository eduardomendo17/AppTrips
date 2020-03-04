﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppTrips.Triggers
{
    public class RatingTrigger : TriggerAction<Entry>
    {
        private string _oldValue = string.Empty;

        protected override void Invoke(Entry sender)
        {
            int n;
            var isNumeric = int.TryParse(sender.Text, out n);
            if (!string.IsNullOrWhiteSpace(sender.Text) &&
                (!isNumeric || n < 1 || n > 5))
            {
                sender.Text = _oldValue;
            }
            _oldValue = sender.Text;
        }
    }
}
