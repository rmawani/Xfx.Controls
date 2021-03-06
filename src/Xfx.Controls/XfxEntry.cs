﻿using System;
using Xamarin.Forms;

namespace Xfx
{
    public class XfxEntry : Entry
    {
        public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(nameof(ErrorText),
            typeof (string),
            typeof (XfxEntry),
            default(string), propertyChanged: OnErrorTextChangedInternal);

        /// <summary>
        ///    Error text for the entry. An empty string removes the error. This is a bindable property.
        /// </summary>
        public string ErrorText
        {
            get { return (string) GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        /// <summary>
        /// Raised when the value of the error text changes
        /// </summary>
        public event EventHandler<TextChangedEventArgs> ErrorTextChanged;

        private static void OnErrorTextChangedInternal(BindableObject bindable, object oldvalue, object newvalue)
        {
            var materialEntry = (XfxEntry)bindable;
            materialEntry.OnErrorTextChanged(bindable, oldvalue, newvalue);
            materialEntry.ErrorTextChanged?.Invoke(materialEntry, new TextChangedEventArgs((string)oldvalue, (string)newvalue));
        }

        protected virtual void OnErrorTextChanged(BindableObject bindable, object oldvalue, object newvalue) { }
    }
}