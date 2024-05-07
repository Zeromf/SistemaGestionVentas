using Application.Interface.ICommand;
using Infraestructura.Persistence.Contexto;
using SistemaGestionVentasTP1.Model;


namespace Infraestructure.Command
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ContextDB _dbContext;

        public SaleRepository(ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddSale(Sale sale)
        {
            try
            {
                _dbContext.Sale.Add(sale);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se produjo un error al guardar la venta: " + ex.Message);
            }
        }
    }
}
