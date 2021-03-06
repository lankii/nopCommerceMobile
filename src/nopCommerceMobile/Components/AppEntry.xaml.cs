﻿using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using nopCommerceMobile.Extensions;
using nopCommerceMobile.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nopCommerceMobile.Components
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppEntry : ContentView
    {
        public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(AppEntry), string.Empty, BindingMode.Default);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(AppEntry), Color.FromHex("1e5474"), BindingMode.Default);
        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(int), typeof(AppEntry), 22, BindingMode.Default);
        public static readonly BindableProperty IconFontFamilyProperty = BindableProperty.Create(nameof(IconFontFamily), typeof(IconFontFamilyEnum), typeof(AppEntry), IconFontFamilyEnum.Ionics, BindingMode.Default, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (AppEntry)bindable;

            if ((string)newValue == "FontAwesome")
            {
                entry.FontAwesomeFontFamily.IsVisible = true;
                entry.IoniconsFontFamily.IsVisible = false;
            }
            else
            {
                entry.FontAwesomeFontFamily.IsVisible = false;
                entry.IoniconsFontFamily.IsVisible = true;
            }
        });
        public static readonly BindableProperty IconColorProperty = BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(AppEntry), Color.FromHex("1e5474"), BindingMode.Default);
        public static readonly BindableProperty BorderCornerRadiusProperty = BindableProperty.Create(nameof(BorderCornerRadius), typeof(float), typeof(AppEntry), 8f, BindingMode.Default);
        public static readonly BindableProperty IsRequiredProperty = BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(AppEntry), false, BindingMode.Default, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (AppEntry)bindable;
            entry.UpdateRequiredIcon();
        });
        public static readonly BindableProperty IsRequiredIconVisibleProperty = BindableProperty.Create(nameof(IsRequiredIconVisible), typeof(bool), typeof(AppEntry), false, BindingMode.Default, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (AppEntry)bindable;
            entry.UpdateRequiredIcon();
        });
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(AppEntry), string.Empty, BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var entry = (AppEntry)bindable;
            entry.UpdateRequiredIcon();
        });
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(AppEntry), string.Empty, BindingMode.Default);
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(AppEntry), false, BindingMode.Default);
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(Type), typeof(EntryTypeEnum), typeof(AppEntry), EntryTypeEnum.Default, BindingMode.Default);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public int IconSize
        {
            get => (int)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public IconFontFamilyEnum IconFontFamily
        {
            get => (IconFontFamilyEnum)GetValue(IconFontFamilyProperty);
            set => SetValue(IconFontFamilyProperty, value);
        }

        public Color IconColor
        {
            get => (Color)GetValue(IconColorProperty);
            set => SetValue(IconColorProperty, value);
        }

        public float BorderCornerRadius
        {
            get => (float)GetValue(BorderCornerRadiusProperty);
            set => SetValue(BorderCornerRadiusProperty, value);
        }

        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        public bool IsRequiredIconVisible
        {
            get => (bool)GetValue(IsRequiredIconVisibleProperty);
            set => SetValue(IsRequiredIconVisibleProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public AppEntry()
        {
            InitializeComponent();
            FontAwesomeFontFamily.IsVisible = IconFontFamily == IconFontFamilyEnum.FontAwesome;
            IoniconsFontFamily.IsVisible = IconFontFamily == IconFontFamilyEnum.Ionics;
        }

        public EntryTypeEnum Type
        {
            get => (EntryTypeEnum)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        private void Icon_Tapped(object sender, EventArgs e)
        {
            Entry.Focus();
        }

        private void UpdateRequiredIcon()
        {
            if (Type == EntryTypeEnum.Email)
            {
                //https://stackoverflow.com/questions/201323/how-to-validate-an-email-address-using-a-regular-expression?rq=1
                //add email validation to display required field TODO
                IsRequiredIconVisible = IsRequired && Text.IsNullOrEmpty();
            }
            else
            {
                IsRequiredIconVisible = IsRequired && Text.IsNullOrEmpty();
            }
        }
    }
}