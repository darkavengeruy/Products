namespace Products.Views
{
    using System;
    using Xamarin.Forms;

    public class CategoriesView : ContentPage
    {
        public CategoriesView()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

