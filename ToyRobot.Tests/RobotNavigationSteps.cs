// *
// * DESIGNSTREAKS CONFIDENTIAL
// * __________________
// *
// *  Copyright © Design Streaks - 2010 - 2020
// *  All Rights Reserved.
// *
// * NOTICE:  All information contained herein is, and remains
// * the property of DesignStreaks and its suppliers, if any.
// * The intellectual and technical concepts contained
// * herein are proprietary to DesignStreaks and its suppliers and may
// * be covered by Australian, U.S. and Foreign Patents,
// * patents in process, and are protected by trade secret or copyright law.
// * Dissemination of this information or reproduction of this material
// * is strictly forbidden unless prior written permission is obtained
// * from DesignStreaks.

using ToyRobot.Console;
using ToyRobot.Library;
using ToyRobot.Library.Commands;
using ToyRobot.Library.Entities;

namespace ToyRobot.Tests
{
    using System;
    using TechTalk.SpecFlow;
    using Xunit;

    [Binding, Scope(Feature = "RobotNavigation")]
    public class RobotNavigationSteps
    {

        private readonly ScenarioContext scenarioContext;

        public RobotNavigationSteps(ScenarioContext scenarioContext)
        {
            if (scenarioContext == null)
                throw new ArgumentNullException(nameof(scenarioContext));
            this.scenarioContext = scenarioContext;

            this.scenarioContext.Set(new Scene(), "scene");
            this.scenarioContext.Set(new Processor(), "processor");
        }

        [Given(@"I have a table of height (.*) and width (.*)")]
        public void GivenIHaveATableOfHeightAndWidth(int height, int width)
        {
            var scene = this.scenarioContext.Get<Scene>("scene");
            
            scene.Environment = new Library.Entities.Environment(height, width);
            this.scenarioContext.Set(scene, "scene");
        }

        [Given(@"the robot exists")]
        public void GivenTheRobotExists()
        {
            var scene = this.scenarioContext.Get<Scene>("scene");
            scene.Robot = new Robot(Guid.NewGuid());
            this.scenarioContext.Set(scene, "scene");
        }

        [Given(@"the robot is currently on the Table at (.*) and (.*) facing ""(.*)""")]
        public void GivenTheRobotIsCurrentlyOnTheTableAtAndFacing(int x, int y, string orientation)
        {
            var scene = this.scenarioContext.Get<Scene>("scene");

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);
            this.scenarioContext.Set(status.Data, "scene");
        }

        [Then(@"the Robot is on the Table at (.*) and (.*) facing ""(.*)""")]
        public void ThenTheRobotIsOnTheTableAtAndFacing(int x, int y, string orientation)
        {
            var status = this.scenarioContext.Get<Status<Scene>>("status");
            Assert.Equal(x, status.Data.Robot.Bearing?.Position.X);
            Assert.Equal(y, status.Data.Robot.Bearing?.Position.Y);
            Assert.Equal(orientation, status.Data.Robot.Bearing?.Orientation.ToString());
        }

        [Then(@"the status will contain the message ""(.*)""")]
        public void ThenTheStatusWillContainTheMessage(string message)
        {
            var status = this.scenarioContext.Get<Status<Scene>>("status");
            Assert.Equal(message, status.Message);
        }

        [Then(@"the value of the status will be ""(.*)""")]
        public void ThenTheValueOfTheStatusWillBe(string statusValue)
        {
            var status = this.scenarioContext.Get<Status<Scene>>("status");
            Assert.Equal(statusValue.ToEnum<Status.States>(), status.State);
        }

        [When(@"I move the robot forward")]
        public void WhenIMoveTheRobotForward()
        {
            var scene = this.scenarioContext.Get<Scene>("scene");

            var status = new MoveCommand().Execute(scene);

            this.scenarioContext.Set(status, "status");
            this.scenarioContext.Set(status.Data, "scene");
        }

        [When(@"I place the robot at (.*) and (.*) facing ""(.*)""")]
        public void WhenIPlaceTheRobotAtAndFacing(int x, int y, string orientation)
        {
            var scene = this.scenarioContext.Get<Scene>("scene");

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);

            this.scenarioContext.Set(status, "status");
            this.scenarioContext.Set(status.Data, "scene");
        }

        [When(@"I readd the robot at (.*) and (.*) facing ""(.*)""")]
        public void WhenIReaddTheRobotAtAndFacing(int x, int y, string orientation)
        {
            var scene = this.scenarioContext.Get<Scene>("scene");

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);

            this.scenarioContext.Set(status, "status");
            this.scenarioContext.Set(status.Data, "scene");
        }

        [When(@"I Report the Robot Position")]
        public void WhenIReportTheRobotPosition()
        {
            var scene = this.scenarioContext.Get<Scene>("scene");
            
            var status = new ReportCommand().Execute(scene);

            this.scenarioContext.Set(status, "status");
            this.scenarioContext.Set(status.Data, "scene");
        }

        [When(@"I turn the robot ""(.*)""")]
        public void WhenITurnTheRobot(string direction)
        {
            var scene = this.scenarioContext.Get<Scene>("scene");


            var status = new TurnCommand(direction.ToEnum<Direction>()).Execute(scene);

            this.scenarioContext.Set(status, "status");
            this.scenarioContext.Set(status.Data, "scene");
        }
    }
}