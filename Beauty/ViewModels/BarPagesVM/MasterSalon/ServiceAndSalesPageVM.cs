﻿using Beauty.EFDataAccessLibrary.Models;
using Beauty.Helpers;
using Beauty.ViewModels.Shared;
using System.Collections.Generic;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Beauty.Stores;

namespace Beauty.ViewModels.BarPagesVM.MasterSalon {
    public class ServiceAndSalesPageVM : BaseVM {
        public ServiceAndSalesPageVM() {
            PageLoadingCommand = new AsyncCommand(async () => {
                using (HttpHelper httpHelper = new HttpHelper()) {
                    WorkerServices = await httpHelper.GetRequest<IEnumerable<WorkerService>>($"https://api.beauty.dimanrus.ru/service/ServicesWorkersByUserId/{UserDataStore.UserId}");
                }
            });
        }
        #region Private fields
        IEnumerable<WorkerService> _workerServices;
        #endregion
        #region Properties
        public IEnumerable<WorkerService> WorkerServices {
            get => _workerServices;
            set => Set(ref _workerServices, value);
        }
        #endregion
    }
}