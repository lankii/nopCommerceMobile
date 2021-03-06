﻿using nopCommerceMobile.Models.Catalog;
using nopCommerceMobile.Services.Catalog;
using nopCommerceMobile.Services.Customer;
using nopCommerceMobile.ViewModels.Base;

namespace nopCommerceMobile.ViewModels.Catalog
{
    public class CategoryViewModel : BaseViewModel
    {
        #region Fields

        private ICatalogService _catalogService;
        private ICustomerService _customerService;

        #endregion

        #region Ctor

        public CategoryViewModel()
        {
            if (_catalogService == null)
                _catalogService = LocatorViewModel.Resolve<ICatalogService>();

            if (_customerService == null)
                _customerService = LocatorViewModel.Resolve<ICustomerService>();
        }

        #endregion

        private CategoryModel _category;
        public CategoryModel Category
        {
            get => _category;
            set
            {
                _category = value;
                RaisePropertyChanged(() => Category);
            }
        }

        private bool _isRightModalVisible;
        public bool IsRightModalVisible
        {
            get => _isRightModalVisible;
            set
            {
                _isRightModalVisible = value;
                RaisePropertyChanged(()=> IsRightModalVisible);
            }
        }

        private bool _listViewMode;
        public bool ListViewModel
        {
            get => _listViewMode;
            set
            {
                _listViewMode = value;
                OnPropertyChanged(nameof(ListViewModel));
            }
        }

        public int CategoryId { get; set; }
        public bool GetProductsByCategoryId { get; set; }

        public void UpdateViewMode(bool isList)
        {
            App.CurrentCostumerSettings.ViewMode = isList ? "list" : "grid";
            _customerService.CreateOrUpdateCustomerSettings(true);
        }
    }
}
