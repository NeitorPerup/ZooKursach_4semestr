using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.Interfaces
{
    public interface IReserveStorage
    {
        List<ReserveViewModel> GetFullList();

        List<ReserveViewModel> GetFilteredList(ReserveBindingModel model);

        ReserveViewModel GetElement(ReserveBindingModel model);

        void Insert(ReserveBindingModel model);

        void Update(ReserveBindingModel model);

        void Delete(ReserveBindingModel model);
    }
}
