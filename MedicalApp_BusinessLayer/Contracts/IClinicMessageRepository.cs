using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IClinicMessageRepository
    {
        Task<IEnumerable<ClinicMessage>> GetClinicMessages(Guid chatId);
        void CreateMessage(ClinicMessage message);
        void DeleteMessage(ClinicMessage message);
    }
}
