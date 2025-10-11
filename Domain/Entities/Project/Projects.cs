using Domain.Entities.Lookups;

namespace Domain.Entities.Project;

public class Projects
{
    public int ProjectId { get; set; }
    public string ProjectCode { get; set; }//numberproject and date 
    public string ProjectName { get; set; }
    public int? ClientId { get; set; }
    public Clients Clients { get; set; }
    public decimal ContractValue { get; set; }
    public int DurationInMonths { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate => StartDate.AddMonths(DurationInMonths);
    public string? OfficerName { get; set; }
    public string? OfficerDescription { get; set; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public int? Civilians { get; set; }            // مدنيون
    public int? Soldiers { get; set; }             // جنود
    public int? NonCommissionedOfficers { get; set; } // صف الضباط
    public int? Officers { get; set; }             // ضباط

    public ProjectEstimation Estimation { get; set; }
    public ICollection<Signature> Signatures { get; set; }
}