using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibilty
{
    //Sube Müdürü
    public class Manager : Employee
    {
        private readonly Context _context;

        public Manager(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 250000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount = model.Amount;
                customerProcess.EmployeeName = "Ömer Faruk Gözegir";
                customerProcess.Description = "Talep edilen tutar sube müdürü  tarafından ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount = model.Amount;
                customerProcess.EmployeeName = "Ömer Faruk Gözegir";
                customerProcess.Description = "Talep edilen tutar sube müdürü tarafından ödenemedi, ve işlem bölge müdürüne gönderildi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);

            }
        }
    }
}
