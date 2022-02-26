using TechTalk.SpecFlow;
using Medea.Client;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Medea.Spec.Steps
{
    [Binding]
    public sealed class QueryStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private Session _session;
        private Query _query;

        public QueryStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"an empty database")]
        public void GivenAnEmptyDatabase()
        {
            _session = Session.Create("data:");
        }

        [Given(@"a database that contains")]
        public void GivenADatabaseThatContains(string multilineText)
        {
            _session = Session.Create("data:application/x-ndjson," + Uri.EscapeDataString(multilineText));
        }

        [When(@"I execute")]
        public void WhenIExecute(string multilineText)
        {
            _query = _session.Query(multilineText);
        }

        [Then(@"the results should be")]
        public void ThenTheResultsAre(string multilineText)
        {
            var actual = _query.Results.ToArray();
            var expected = multilineText.Split('\n').Select(l => JToken.Parse(l)).ToArray();

            Assert.AreEqual(expected, actual);
        }
    }
}
