using FluentAssertions;
using TechTalk.SpecFlow;
using Medea.Client;
using System.Linq;
using System.Web;

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
            _session = Session.Create("data:[]");
        }

        [Given(@"a database that contains")]
        public void GivenADatabaseThatContains(string multilineText)
        {
            _session = Session.Create("data:" + HttpUtility.UrlEncode(multilineText));
        }

        [When(@"I execute")]
        public void WhenIExecute(string multilineText)
        {
            _query = _session.Query(multilineText);
        }

        [Then(@"the results should be")]
        public void ThenTheResultsAre(string multilineText)
        {
            _query.Results.ToNdjson().Should().Be(multilineText);
        }
    }
}
