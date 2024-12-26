using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduling.DAL.Models;

namespace Scheduling.BLL.Interfaces
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(int id);
        void Add(Appointment appointment);
        void Update(Appointment appointment);
        void Delete(int id);
        IEnumerable<Appointment> GetReminder(DateTime dateTime);
    }
}
