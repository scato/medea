using System;
using System.Buffers;
using System.IO;
using System.Linq;
using System.Reflection;
using Medea.Core.Compiler.Visitor;
using Medea.Core.Planner;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Compiler
{
    public class QueryPlanCompiler
    {
        private Random _random;

        public QueryPlanCompiler()
        {
            _random = new Random();
        }

        public ICompiledQueryStage CompileQueryStage(QueryStage queryStage)
        {
            string className = GenerateClassName();

            var visitor = new OperatorToClassBodyVisitor(queryStage.RootNode);
            queryStage.RootNode.Accept(visitor);
            var classBody = visitor.Result;

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@$"
                using System.Collections.Generic;
                using Medea.Core.Compiler;
                using Medea.Core.FileStorage;
                using Medea.Core.JavaScript;
                using Newtonsoft.Json.Linq;

                namespace Medea.CompiledCode
                {{
                    public class {className} : ICompiledQueryStage
                    {{
                        {classBody}
                    }}
                }}
            ");

            CSharpCompilation compilation = CreateCompilation(syntaxTree);
            return CreateInstance(className, compilation);
        }

        private string GenerateClassName()
        {
            var buffer = new byte[32];
            _random.NextBytes(buffer);
            var id = BitConverter.ToString(buffer).Replace("-", "");

            return "CompiledQueryStage" + id;
        }

        private static CSharpCompilation CreateCompilation(SyntaxTree syntaxTree)
        {
            var assemblyName = Path.GetRandomFileName();
            var references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(
                    AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .Where(a => a.FullName.StartsWith("System.Runtime, "))
                        .Single()
                        .Location
                ),
                MetadataReference.CreateFromFile(
                    AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .Where(a => a.FullName.StartsWith("netstandard, "))
                        .Single()
                        .Location
                ),
                MetadataReference.CreateFromFile(
                    AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .Where(a => a.FullName.StartsWith("System.Linq.Expressions, "))
                        .Single()
                        .Location
                ),
                MetadataReference.CreateFromFile(
                    AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .Where(a => a.FullName.StartsWith("System.ComponentModel.TypeConverter, "))
                        .Single()
                        .Location
                ),
                MetadataReference.CreateFromFile(
                    AppDomain
                        .CurrentDomain
                        .GetAssemblies()
                        .Where(a => a.FullName.StartsWith("System.ObjectModel, "))
                        .Single()
                        .Location
                ),
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ICompiledQueryStage).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(JToken).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Uri).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(ReadOnlySequence<>).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(File).Assembly.Location)
            };

            return CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );
        }

        private static ICompiledQueryStage CreateInstance(string className, CSharpCompilation compilation)
        {
            using (var ms = new MemoryStream())
            {
                var result = compilation.Emit(ms);

                if (!result.Success)
                {
                    throw new AggregateException(
                        $"Unable to parse query stage: {compilation.SyntaxTrees.Single().ToString()}",
                        result.Diagnostics.Select(diagnostic => new ArgumentException(diagnostic.ToString()))
                    );
                }

                ms.Seek(0, SeekOrigin.Begin);
                var assembly = Assembly.Load(ms.ToArray());

                return (ICompiledQueryStage) assembly.CreateInstance("Medea.CompiledCode." + className);
            }
        }
    }
}
