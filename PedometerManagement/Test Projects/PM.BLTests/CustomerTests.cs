using Core.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PM.BL.Tests
{
    [TestClass()]
    public class CustomerTests
    {
        #region Happy Path Tests
        [TestMethod]
        public void CalculatePercentOfGoalSteps_Valid()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expected = 40M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalSteps_ValidAndSame()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expected = 100M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Boundary Tests
        [TestMethod]
        public void CalculatePercentOfGoalSteps_ValidActualIsZero()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expected = 0M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Invalid Argument Tests - Option 1
        [TestMethod]
        public void CalculatePercentOfGoalSteps_GoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";
            decimal expected = 0M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalSteps_GoalIsNotNumeric()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = "one";
            string actualSteps = "2000";
            decimal expected = 0M;

            //-- Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region Invalid Argument Tests - Option 2
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void CalculatePercentOfGoalSteps_GoalIsNull()
        //{
        //    //-- Arrange
        //    var customer = new Customer();
        //    string goalSteps = null;
        //    string actualSteps = "2000";

        //    //-- Act
        //    var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

        //    //-- Assert
        //}

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void CalculatePercentOfGoalSteps_GoalIsNotNumeric()
        //{
        //    //-- Arrange
        //    var customer = new Customer();
        //    string goalSteps = "one";
        //    string actualSteps = "2000";

        //    //-- Act
        //    var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

        //    //-- Assert
        //}
        #endregion

        #region Returning Multiple Values - ref
        [TestMethod()]
        public void CalculatePercentOfGoalStepsRef_GoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";
            decimal expected = 0M;

            // Declared an initialized
            string message = "";
            string expectedMessage = "Goal steps must be entered";

            //-- Act
            var actual = customer.CalculatePercentOfGoalStepsRef(goalSteps, actualSteps, ref message);

            //-- Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, message);
        }
        #endregion

        #region Returning Multiple Values - out
        [TestMethod()]
        public void CalculatePercentOfGoalStepsOut_GoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";
            decimal expected = 0M;

            // Declared but not initialized
            string message;
            string expectedMessage = "Goal steps must be entered";

            //-- Act
            var actual = customer.CalculatePercentOfGoalStepsOut(goalSteps, actualSteps, out message);

            //-- Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, message);
        }
        #endregion

        #region Returning Multiple Values - Tuple
        [TestMethod()]
        public void CalculatePercentOfGoalStepsTuple_GoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";
            var expected = Tuple.Create(0M, "Goal steps must be entered");

            //-- Act
            var actual = customer.CalculatePercentOfGoalStepsTuple(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected.Item1, actual.Item1);
            Assert.AreEqual(expected.Item2, actual.Item2);
        }
        #endregion

        #region Returning Multiple Values - Object
        [TestMethod()]
        public void CalculatePercentOfGoalStepsOR_GoalIsNull()
        {
            //-- Arrange
            var customer = new Customer();
            string goalSteps = null;
            string actualSteps = "2000";
            var expected = new OperationResult<decimal>(0M, "Goal steps must be entered");

            //-- Act
            var actual = customer.CalculatePercentOfGoalStepsOR(goalSteps, actualSteps);

            //-- Assert
            Assert.AreEqual(expected.Value, actual.Value);
            Assert.AreEqual(expected.MessageList.Count(), actual.MessageList.Count());
            for (int i = 0; i < expected.MessageList.Count(); i++)
            {
                Assert.AreEqual(expected.MessageList[i], actual.MessageList[i]);
            }
        }
        #endregion
    }
}
