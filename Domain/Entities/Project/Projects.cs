using Domain.Entities.Lookups;

namespace Domain.Entities.Project;

public class Projects
{
    public int ProjectId { get; set; }
        public string ProjectCode { get; set; } // Project number or reference
        public string ProjectName { get; set; }
        public int? ClientId { get; set; }
        public Client Client { get; set; }
        public decimal ContractValue { get; set; }
        public int DurationInMonths { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate => StartDate.AddMonths(DurationInMonths);
        public string? ManagerName { get; set; }
        public string? ManagerNotes { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        // Team composition (generalized)
        public int? TeamMembers { get; set; }
        public int? TechnicalStaff { get; set; }
        public int? SupportStaff { get; set; }
        public int? Supervisors { get; set; }

        public ProjectEstimation Estimation { get; set; }
        public ICollection<Signature> Signatures { get; set; }
}
