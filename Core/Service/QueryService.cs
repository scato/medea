﻿using System.Collections.Generic;
using Medea.Core.Executor;
using Medea.Core.Parser;
using Medea.Core.Planner;
using Medea.Core.Planner.Operator;
using Newtonsoft.Json.Linq;

namespace Medea.Core.Service
{
    public class QueryService
    {
        private QueryPlanner _planner;
        private IQueryPlanExecutor _executor;

        public QueryService()
        {
            _planner = new QueryPlanner();
            _executor = new LocalExecutor();
        }

        public IEnumerable<JToken> Execute(string queryString)
        {
            var lexer = new MedeaLexer(queryString);
            var parser = new MedeaParser(lexer);
            var result = parser.Parse();
            
            var queryPlan = _planner.CreatePlan(result);
            var results = _executor.Execute(queryPlan);

            return results;
        }
    }
}
