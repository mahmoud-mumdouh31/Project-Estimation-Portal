using Extension.ToolKit.BaseEntities;

namespace Domain.Abstraction;
public interface ILookup : IBaseEntity
{
    string Name { get; set; }
}