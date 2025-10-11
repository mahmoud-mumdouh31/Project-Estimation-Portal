namespace Domain.Entities.Project;

public class ProjectEstimation
{
    public int EstimationId { get; set; }
    public int ProjectId { get; set; }
    public Projects Project { get; set; }


    // Percent values (0-100)
    public decimal FixedAssetsPercent { get; set; } // 0 or 5
    public decimal RawMaterialsPercent { get; set; }
    public decimal LaborPercent { get; set; } = 4;
    public decimal IncentivesPercent { get; set; } = 10;
    public decimal OperatingExpensesPercent { get; set; } = 65;
    // البنود الإضافية المطلوبة
    public decimal EquipmentDepreciationPercent { get; set; } = 2; // إهلاك معدات ق.م
    public decimal AccommodationRecoveryPercent { get; set; } = 2; // إسترداد تكلفة إعاشة
    public decimal AdministrativeExpensesPercent { get; set; } = 2; // مصروفات إدارية
    public decimal InsurancePercent { get; set; } = 0; // تأمين
    public decimal GeneralSurplusPercent { get; set; } = 10; // فائض عام

}