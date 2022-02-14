using Medea.Core.Compiler.Visitor;

namespace Medea.Core.Planner
{
    public interface IPattern : IQueryPlanNode
    {
        void Accept(IPatternVisitor visitor);
    }
}
