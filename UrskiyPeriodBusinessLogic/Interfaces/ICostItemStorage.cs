using System;
using System.Collections.Generic;
using UrskiyPeriodBusinessLogic.ViewModels;
using UrskiyPeriodBusinessLogic.BindingModels;

namespace UrskiyPeriodBusinessLogic.Interfaces
{
    public interface ICostItemStorage
    {
        CostItemViewModel GetElement(CostItemBindingModel model);

        void Insert(CostItemBindingModel model);

        void Update(CostItemBindingModel model);

        void Delete(CostItemBindingModel model);

        int Count();
    }
}
