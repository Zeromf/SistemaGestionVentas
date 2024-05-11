using SistemaGestionVentasTP1.Model;
using System.Collections.Generic;
using System;

namespace Application.Interface.IPrinter
{
    public interface ISaleConsole
    {
        public void SalePrint(Sale sale);
        public void SaleDetail(Sale sale);
        public bool ConfirmSaleRegistration();

        public void SalesConfirm(bool sales);

        public void SaleNotProduct();

    }
}
