using System;
using System.ArrayExtensions;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using ToyRobot.Library;
using ToyRobot.Library.Entities;
using ToyRobot.Library.Parsers;
using Assert = Xunit.Assert;

namespace ToyRobot.Tests
{
    [Binding, Scope(Feature = "FileParser")]
    public class FileParserSteps
    {

        private readonly ScenarioContext scenarioContext;

        public FileParserSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
                throw new ArgumentNullException(nameof(scenarioContext));

            this.scenarioContext = scenarioContext;
        }


        [Given(@"I have a command with the ""(.*)""")]
        public void GivenIHaveACommandWithThe(string arguments)
        {
            this.scenarioContext.Set(arguments.Replace(" ", ""), "arguments");
        }

        [When(@"I validate the command Move command parameters")]
        public void WhenIValidateTheCommandMoveCommandParameters()
        {
            var target = new FileParser();
            var obj = new PrivateObject(typeof(FileParser));


            var arguments = this.scenarioContext.Get<string>("arguments");
            var command = $"Move {arguments}".Split(' ');


            var retVal = obj.Invoke(
                "ValidateMoveCommand",
                new[] { typeof(string[]) },
                new object[] { command });

            this.scenarioContext.Set((Status)retVal, "status");
        }

        [When(@"I validate the command Left command parameters")]
        public void WhenIValidateTheCommandLeftCommandParameters()
        {
            var target = new FileParser();
            var obj = new PrivateObject(typeof(FileParser));


            var arguments = this.scenarioContext.Get<string>("arguments");
            var command = $"Move {arguments}".Split(' ');


            var retVal = obj.Invoke(
                "ValidateLeftTurnCommand",
                new[] { typeof(string[]) },
                new object[] { command });

            this.scenarioContext.Set((Status)retVal, "status");
        }

        [When(@"I validate the command Right command parameters")]
        public void WhenIValidateTheCommandRightCommandParameters()
        {
            var target = new FileParser();
            var obj = new PrivateObject(typeof(FileParser));


            var arguments = this.scenarioContext.Get<string>("arguments");
            var command = $"Move {arguments}".Split(' ');


            var retVal = obj.Invoke(
                "ValidateRightTurnCommand",
                new[] { typeof(string[]) },
                new object[] { command });

            this.scenarioContext.Set((Status)retVal, "status");
        }

        [When(@"I validate the command Report command parameters")]
        public void WhenIValidateTheCommandReportCommandParameters()
        {
            var target = new FileParser();
            var obj = new PrivateObject(typeof(FileParser));


            var arguments = this.scenarioContext.Get<string>("arguments");
            var command = $"Move {arguments}".Split(' ');


            var retVal = obj.Invoke(
                "ValidateReportCommand",
                new[] { typeof(string[]) },
                new object[] { command });

            this.scenarioContext.Set((Status)retVal, "status");
        }



        [When(@"I validate the Place command parameters")]
        public void WhenIValidateThePlaceCommandParameters()
        {
            var target = new FileParser();
            var obj = new PrivateObject(typeof(FileParser));


            var arguments = this.scenarioContext.Get<string>("arguments");
            var command = $"Place {arguments}".Split(' ');


            Bearing bearing = null;
            var retVal = obj.Invoke(
                "ValidatePlaceCommand",
                new[] { typeof(string[]), typeof(Bearing).MakeByRefType() },
                new object[] { command, bearing });

            this.scenarioContext.Set((Status)retVal, "status");
        }

        [Then(@"the status will contain the message ""(.*)""")]
        public void ThenTheStatusWillContainTheMessage(string message)
        {
            var status = this.scenarioContext.Get<Status>("status");
            Assert.Equal(message, status.Message);
        }

        [Then(@"the value of the status will be ""(.*)""")]
        public void ThenTheValueOfTheStatusWillBe(string statusValue)
        {
            var status = this.scenarioContext.Get<Status>("status");
            Assert.Equal(statusValue.ToEnum<Status.States>(), status.State);
        }

    }
}
