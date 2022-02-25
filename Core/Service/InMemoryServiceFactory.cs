using System;
using Medea.Core.Compiler;
using Medea.Core.DataStorage;
using Medea.Core.Executor;
using Medea.Core.FileStorage;
using Medea.Core.JavaScript;
using Medea.Core.Planner;

namespace Medea.Core.Service
{
    public class InMemoryServiceFactory
    {
        private QueryPlanner _queryPlanner;
        private QueryPlanCompiler _queryPlanCompiler;
        private JavaScriptFacade _javaScriptFacade;
        private FileStorageFacade _fileStorageFacade;
        private DataStorageFacade _dataStorageFacade;
        private LocalExecutor _localExecutor;
        private DatabaseService _databaseService;
        private QueryService _queryService;

        public QueryPlanner CreateQueryPlanner() =>
            _queryPlanner ??= new QueryPlanner();

        public QueryPlanCompiler CreateQueryPlanCompiler() =>
            _queryPlanCompiler ??= new QueryPlanCompiler();

        public JavaScriptFacade CreateJavaScriptFacade() =>
            _javaScriptFacade ??= new JavaScriptFacade();

        public FileStorageFacade CreateFileStorageFacade() =>
            _fileStorageFacade ??= new FileStorageFacade();

        public DataStorageFacade CreateDataStorageFacade() =>
            _dataStorageFacade ??= new DataStorageFacade();

        public LocalExecutor CreateLocalExecutor() =>
            _localExecutor ??= new LocalExecutor(
                CreateQueryPlanCompiler(),
                CreateDataStorageFacade(),
                CreateFileStorageFacade(),
                CreateJavaScriptFacade()
            );

        public QueryService CreateQueryService() =>
            _queryService ??= new QueryService(
                CreateQueryPlanner(),
                CreateLocalExecutor()
            );

        public DatabaseService CreateDatabaseService() =>
            _databaseService ??= new DatabaseService(
                CreateDataStorageFacade()
            );
    }
}
