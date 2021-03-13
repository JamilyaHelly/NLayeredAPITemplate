using Core.Models;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;

namespace Service.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {
        public InvoiceService(IUnitOfWork unitOfWork, IRepository<Invoice> repository) : base(unitOfWork, repository)
        {
        }
    }
}