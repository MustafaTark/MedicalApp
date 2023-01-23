using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApp_DataLayer.Configrations
{
    public class RoleConfigrations : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole { Name = "Patient", NormalizedName = "PATIENT" },
                new IdentityRole { Name = "Clinic", NormalizedName = "CLINIC" }, 
                new IdentityRole { Name = "Pharmacy", NormalizedName = "PHARMACY" }
                );
        }
    }
}
