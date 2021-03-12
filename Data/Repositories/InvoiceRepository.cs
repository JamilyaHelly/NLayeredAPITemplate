using Core.Models;
using Core.Repositories;

namespace Data.Repositories
{
    public class InvoiceRepository :Repository<Invoice>,IInvoiceRepository
    {
        
        private AppDbContext _appDbContext{get=>_context as AppDbContext;}
        public InvoiceRepository(AppDbContext context):base(context)
        {
            
        }

    }
}