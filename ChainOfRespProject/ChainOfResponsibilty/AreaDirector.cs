using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibilty
{
    //Bülge Müdürü
    public class AreaDirector : Employee
    {
        private readonly Context _context;
        public AreaDirector(Context context)
        {
            _context = context;
        }
        public override void ProcessRequest(CustomerProcessViewModel model)
        {
            if (model.Amount <= 350000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount = model.Amount;
                customerProcess.EmployeeName = "Ersen  Kaçar";
                customerProcess.Description = "Talep edilen tutar bölge yöneticisi tarafından ödendi";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Name = model.Name;
                customerProcess.Amount = model.Amount;
                customerProcess.EmployeeName = "Ersen Kaçar";
                customerProcess.Description = "Günlük ödeme limitlerini aştığı için ödeme yapılamadı, müsteriye bilgi verildi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
       
    }
