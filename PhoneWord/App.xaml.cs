﻿namespace PhoneWord
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new PhonewordTranslator();
           //MainPage = new NavigationPage(new AppShell());
        }
    }
}