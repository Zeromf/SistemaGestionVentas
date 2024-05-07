using SistemaGestionVentasTP1.Model;

namespace Application.Interface.IPrinter
{
    public interface ISaleConsole
    {
        public void SalePrint(Sale sale);
        public void SaleDetail(Sale sale);
    }
}
