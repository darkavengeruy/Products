﻿namespace Products.ViewModels
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Services;

    public class MainViewModel
    {
        #region Services
        NavigationService navigationService;
        #endregion

        #region Properties
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CategoriesViewModel Categories
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        public ProductsViewModel Products
        {
            get;
            set;
        }

        public NewCategoryViewModel NewCategory
        {
            get;
            set;
        }

        public EditCategoryViewModel EditCategory
        {
            get;
            set;
        }

        public NewProductViewModel NewProduct
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public EditProductViewModel EditProduct
        {
            get;
            set;
        }

        #endregion

        #region Constructors

        public MainViewModel()
        {
            instance = this;

            navigationService = new NavigationService();

            Login = new LoginViewModel();
        }
        #endregion

        #region Sigleton
        static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Commands
        public ICommand NewCategoryCommand
        {
            get
            {
                return new RelayCommand(GoNewCategory);
            }
        }

        async private void GoNewCategory()
        {
            NewCategory = new NewCategoryViewModel();
            await navigationService.Navigate("NewCategoryView");
        }

        public ICommand NewProductCommand
        {
            get
            {
                return new RelayCommand(GoNewProduct);
            }
        }

        async private void GoNewProduct()
        {
            NewProduct = new NewProductViewModel();
            await navigationService.Navigate("NewProductView");
        }
        #endregion
    }
}
