using Medea.Core.Planner;
using Medea.Core.Planner.Operator;

namespace Medea.Core.Compiler.Visitor
{
    public class OperatorToCodeVisitor : IOperatorVisitor
    {
        public object ClassBody { get; set; }

        public OperatorToCodeVisitor()
        {
            ClassBody = @"
                public void Open()
                {
                    Open1();
                }

                public IEnumerable<JToken> Next()
                {
                    return Next1();
                }

                public void Close()
                {
                    Close1();
                }
            ";
        }

        public void Visit(ConstantExpressionScan queryOperator)
        {
            ClassBody += @"
                private JToken[] _tmp1;
                private bool _tmp2;

                private void Open1()
                {
                    _tmp1 = new JToken[] { new JValue(1) };
                    _tmp2 = false;
                }

                private IEnumerable<JToken> Next1()
                {
                    if (!_tmp2)
                    {
                        _tmp2 = true;
                        return _tmp1;
                    }
                    else
                    {
                        return null;
                    }
                }

                private void Close1()
                {
                    _tmp1 = null;
                }
            ";
        }
    }
}