using MedicalApp_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_BusinessLayer.Contracts
{
    public interface IChatRepository
    {
        Task<IEnumerable<Chat>> GetAllToPatient(string patientId);
        Task<IEnumerable<Chat>> GetAllToClinic(string clinicId);
        Task<Chat> GetChatToPatientAndClinic(string patientId,string clinicId);
        Task<Chat?> GetChatByIdAsync(Guid id);
        void CreateChat(Chat chat);
    }
}
