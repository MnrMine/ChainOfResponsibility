using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibilty
{
    public class ManagerAssistant : Employee
//SubeMüdürYardımcısı
    {
        private readonly Context _context;

        public ManagerAssistant(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount =model.Amount;
                customerProcess.EmployeeName = "Elif Çalış";
                customerProcess.Description = "Talep edilen tutar şube müdür yardımcısı tarafından ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount = model.Amount;
                customerProcess.EmployeeName = "Elif Çalış";
                customerProcess.Description = "Talep edilen tutar şube müdür yardımcısı tarafından ödenemedi, işlem şube müdürüne aktarıldı";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }
    }
}
