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

    [Binding]
    public class RobotNavigationSteps
    {
        public RobotNavigationSteps()
        {
            ScenarioContext.Current["scene"] = new Scene();
            ScenarioContext.Current["processor"] = new Processor();
        }

        [Given(@"I have a table of height (.*) and width (.*)")]
        public void GivenIHaveATableOfHeightAndWidth(int height, int width)
        {
            var scene = (Scene)ScenarioContext.Current["scene"];
            scene.Environment = new Library.Entities.Environment(height, width);
            ScenarioContext.Current["scene"] = scene;
        }

        [Given(@"the robot exists")]
        public void GivenTheRobotExists()
        {
            var scene = (Scene)ScenarioContext.Current["scene"];
            scene.Robot = new Robot(Guid.NewGuid());
            ScenarioContext.Current["scene"] = scene;
        }

        [Given(@"the robot is currently on the Table at (.*) and (.*) facing ""(.*)""")]
        public void GivenTheRobotIsCurrentlyOnTheTableAtAndFacing(int x, int y, string orientation)
        {
            var scene = (Scene)ScenarioContext.Current["scene"];

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);
            ScenarioContext.Current["scene"] = status.Data;
        }

        [Then(@"the Robot is on the Table at (.*) and (.*) facing ""(.*)""")]
        public void ThenTheRobotIsOnTheTableAtAndFacing(int x, int y, string orientation)
        {
            var status = (Status<Scene>)ScenarioContext.Current["status"];
            Assert.Equal(x, status.Data.Robot.Bearing?.Position.X);
            Assert.Equal(y, status.Data.Robot.Bearing?.Position.Y);
            Assert.Equal(orientation, status.Data.Robot.Bearing?.Orientation.ToString());
        }

        [Then(@"the status will contain the message ""(.*)""")]
        public void ThenTheStatusWillContainTheMessage(string message)
        {
            var status = (Status<Scene>)ScenarioContext.Current["status"];
            Assert.Equal(message, status.Message);
        }

        [Then(@"the value of the status will be ""(.*)""")]
        public void ThenTheValueOfTheStatusWillBe(string statusValue)
        {
            var status = (Status<Scene>)ScenarioContext.Current["status"];
            Assert.Equal(statusValue.ToEnum<Status.States>(), status.State);
        }

        //[Then(@"the scene Bearing will ""(.*)""")]
        //public void ThenTheSceneBearingWill(string exist)
        //{
        //    var status = (Status<ToyRobot.Scene>)ScenarioContext.Current["status"];
        //    if(exist != "true")
        //        Assert.Null(status.Data.Bearing);
        //}

        //[Then(@"if the scene Bearing does ""(.*)"", the Robot is on the Table at (.*) and (.*) facing ""(.*)""")]
        //public void ThenIfTheSceneBearingDoesTheRobotIsOnTheTableAtAndFacing(string exist, int x, int y, string orientation)
        //{
        //    var status = (Status<ToyRobot.Scene>)ScenarioContext.Current["status"];
        //    if (exist == "true")
        //    {
        //        Assert.Equal(x, status.Data.Bearing.Position.X);
        //        Assert.Equal(y, status.Data.Bearing.Position.Y);
        //        Assert.Equal(orientation, status.Data.Bearing.Orientation.ToString());

        //    }
        //    else
        //        Assert.Null(status.Data.Bearing);
        //}


        [When(@"I move the robot forward")]
        public void WhenIMoveTheRobotForward()
        {
            var scene = (Scene)ScenarioContext.Current["scene"];

            var status = new MoveCommand().Execute(scene);

            ScenarioContext.Current["status"] = status;
            ScenarioContext.Current["scene"] = status.Data;
        }

        [When(@"I place the robot at (.*) and (.*) facing ""(.*)""")]
        public void WhenIPlaceTheRobotAtAndFacing(int x, int y, string orientation)
        {
            var scene = (Scene)ScenarioContext.Current["scene"];

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);

            ScenarioContext.Current["status"] = status;
            ScenarioContext.Current["scene"] = status.Data;
        }

        [When(@"I readd the robot at (.*) and (.*) facing ""(.*)""")]
        public void WhenIReaddTheRobotAtAndFacing(int x, int y, string orientation)
        {
            var scene = (Scene)ScenarioContext.Current["scene"];

            var status = new PlaceCommand(new Bearing(x, y, orientation.ToEnum<Orientation>())).Execute(scene);

            ScenarioContext.Current["status"] = status;
            ScenarioContext.Current["scene"] = status.Data;
        }

        [When(@"I Report the Robot Position")]
        public void WhenIReportTheRobotPosition()
        {
            var scene = (Scene)ScenarioContext.Current["scene"];
            
            var status = new ReportCommand().Execute(scene);

            ScenarioContext.Current["status"] = status;
            ScenarioContext.Current["scene"] = status.Data;
        }

        [When(@"I turn the robot ""(.*)""")]
        public void WhenITurnTheRobot(string direction)
        {
            var scene = (Scene)ScenarioContext.Current["scene"];


            var status = new TurnCommand(direction.ToEnum<Direction>()).Execute(scene);

            ScenarioContext.Current["status"] = status;
            ScenarioContext.Current["scene"] = status.Data;
        }
    }
}