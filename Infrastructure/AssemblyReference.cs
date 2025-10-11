using System.Reflection;

namespace Infrastructure;
public sealed class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}