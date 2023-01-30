using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IPatientMessageRepository
    {
        Task<IEnumerable<PatientMessage>> GetPatientMessages(Guid chatId);
        void CreateMessage(PatientMessage message);
        void DeleteMessage(PatientMessage message);
    }
}
