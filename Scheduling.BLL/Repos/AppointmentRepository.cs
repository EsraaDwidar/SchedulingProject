using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduling.BLL.Interfaces;
using Scheduling.DAL.Models;
using Scheduling.DAL.Data;

namespace Scheduling.BLL.Repos
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly SchedulingDbContext _dbContext;
        public AppointmentRepository(SchedulingDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var appointments = _dbContext.Appointments.SingleOrDefault(x => x.Id == id);
            _dbContext.Appointments.Remove(appointments);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _dbContext.Appointments.ToList();
        }

        public Appointment GetById(int id)
        {
            return _dbContext.Appointments.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Appointment> GetReminder(DateTime dateTime)
        {
            var reminder = _dbContext.Appointments.Where(u => u.ReminderDate.HasValue).ToList();
            return reminder;
        }

        public void Update(Appointment appointment)
        {
            _dbContext.Appointments.Update(appointment);
            _dbContext.SaveChanges();
        }
    }
}
