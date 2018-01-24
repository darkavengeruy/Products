namespace Products.Models
{
    using System;
    using Services;
    using ViewModels;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    public class Product
    {
        #region Services
        DialogService dialogService;
        NavigationService navigationService;
        #endregion

        #region Properties
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public decimal Precio { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastPurchase { get; set; }

        public double Stock { get; set; }

        public string Remarks { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(Image))
                {
                    return "noimage";
                }
                return string.Format(
                    "http://productsapi.azurewebsites.net/{0}",
                        Image.Substring(2));
            }
        }
        #endregion

        #region Constructors
        public Product()
        {
            dialogService = new DialogService();
            navigationService = new NavigationService();
        }
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return ProductId;
        }
        #endregion

        #region Commands

        public ICommand DeleteCommand
        {
            get
            {
                return new RelayCommand(Delete);
            }
        }

        async void Delete()
        {
            var response = await dialogService.ShowConfirm(
                    "Confirm",
                    "Are you sure to delete this record?");
            if (!response)
            {
                return;
            }
            await ProductsViewModel.GetInstance().Delete(this);
        }

        public ICommand EditCommand
        {
            get
            {
                return new RelayCommand(Edit);
            }
        }
        async void Edit()
        {
            MainViewModel.GetInstance().EditProduct =
                new EditProductViewModel(this);
            await navigationService.Navigate("EditProductView");
        }

        #endregion
    }
}
