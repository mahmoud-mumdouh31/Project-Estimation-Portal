namespace Domain.Entities.Project;

public class Signature
{
    public int SignatureId { get; set; } 

    public int ProjectId { get; set; }
    public Projects Projects { get; set; } = null!;

    public string Name { get; set; } = null!;
    public string JobTitle { get; set; } = null!; 
    public string? Notes { get; set; } 
}