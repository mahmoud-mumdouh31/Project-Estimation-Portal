using Domain.Abstraction;
using Domain.Entities.Project;
using Extension.ToolKit.BaseEntities;

namespace Domain.Entities.Lookups;

public class Clients : BaseEntity, ILookup
{
    public string Name { get; set; } = null!;
    public ICollection<Projects> Projects { get; set; } = [];



}