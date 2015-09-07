using Core.Common;
using System;

namespace PM.BL
{
    /// <summary>
    /// Manages a single customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the customer's id.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer's email address.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName { get; set; }

        #region Try 1
        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        {
            return Math.Round(decimal.Parse(actualSteps) / decimal.Parse(goalSteps) * 100M, 2);
        }
        #endregion

        #region Try 2 - Option 1
        ///// <summary>
        ///// Calculates the percent of the step goal reached.
        ///// </summary>
        //public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        //{
        //    if (string.IsNullOrWhiteSpace(goalSteps)) return 0M;
        //    if (string.IsNullOrWhiteSpace(actualSteps)) return 0M;

        //    decimal goalStepCount = 0;
        //    if (!decimal.TryParse(goalSteps, out goalStepCount)) return 0M;

        //    decimal actualStepCount = 0;
        //    if (!decimal.TryParse(actualSteps, out actualStepCount)) return 0M;

        //    return Math.Round(actualStepCount / goalStepCount * 100M, 2);
        //}
        #endregion

        #region Try 2 - Option 2
        ///// <summary>
        ///// Calculates the percent of the step goal reached.
        ///// </summary>
        //public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        //{
        //    // Uses the new "nameof" keyword
        //    if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentNullException("Goal must be entered", 
        //                                                                                nameof(goalSteps));
        //    if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentNullException("Actual steps must be entered",
        //                                                                                nameof(actualSteps));

        //    decimal goalStepCount = 0;
        //    if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric",
        //                                                                                    nameof(goalSteps));

        //    decimal actualStepCount = 0;
        //    if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric",
        //                                                                                        nameof(actualSteps));

        //    return Math.Round(actualStepCount / goalStepCount * 100M, 2);
        //}
        #endregion

        #region Try 3
        ///// <summary>
        ///// Calculates the percent of the step goal reached.
        ///// </summary>
        //public decimal CalculatePercentOfGoalSteps(string goalSteps, string actualSteps)
        //{

        //    if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentNullException("Goal must be entered",
        //                                                                                nameof(goalSteps));
        //    if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentNullException("Actual steps must be entered",
        //                                                                                nameof(actualSteps));

        //    decimal goalStepCount = 0;
        //    if (!decimal.TryParse(goalSteps, out goalStepCount)) throw new ArgumentException("Goal must be numeric",
        //                                                                                nameof(goalSteps));

        //    decimal actualStepCount = 0;
        //    if (!decimal.TryParse(actualSteps, out actualStepCount)) throw new ArgumentException("Actual steps must be numeric",
        //                                                                                nameof(actualSteps));

        //    return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        //}

        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        private decimal CalculatePercentOfGoalSteps(decimal goalStepCount, decimal actualStepCount)
        {
            if (goalStepCount <= 0) throw new ArgumentException("Goal must be greater than 0", nameof(goalStepCount));

            return Math.Round(actualStepCount / goalStepCount * 100, 2);
        }
        #endregion

        #region Returning Multiple Values - ref
        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public decimal CalculatePercentOfGoalStepsRef(string goalSteps, string actualSteps, ref string message)
        {
            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                message = "Goal steps must be entered";
                return 0M;
            }
            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                message = "Actual steps must be entered";
                return 0M;
            }

            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount))
            {
                message = "Goal steps must be numeric";
                return 0M;
            }

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount))
            {
                message = "Actual steps must be numeric";
                return 0M;
            }

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }
        #endregion

        #region Returning Multiple Values - out
        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public decimal CalculatePercentOfGoalStepsOut(string goalSteps, string actualSteps, out string message)
        {
            // Message must be assigned somewhere in this method.
            message = "";

            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                message = "Goal steps must be entered";
                return 0M;
            }
            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                message = "Actual steps must be entered";
                return 0M;
            }

            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount))
            {
                message = "Goal steps must be numeric";
                return 0M;
            }

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount))
            {
                message = "Actual steps must be numeric";
                return 0M;
            }

            return CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
        }
        #endregion

        #region Returning Multiple Values - Tuple
        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public Tuple<decimal, string> CalculatePercentOfGoalStepsTuple(string goalSteps, string actualSteps)
        {
            var message = "";
            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                message = "Goal steps must be entered";
                return Tuple.Create(0m, message);
            }
            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                message = "Actual steps must be entered";
                return Tuple.Create(0m, message);
            }

            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount))
            {
                message = "Goal steps must be numeric";
                return Tuple.Create(0m, message);
            }

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount))
            {
                message = "Actual steps must be numeric";
                return Tuple.Create(0m, message);
            }

            return Tuple.Create(CalculatePercentOfGoalSteps(goalStepCount, actualStepCount), message);
        }
        #endregion

        #region Returning Multiple Values - Object
        /// <summary>
        /// Calculates the percent of the step goal reached.
        /// </summary>
        public OperationResult<decimal> CalculatePercentOfGoalStepsOR(string goalSteps, string actualSteps)
        {
            var operationResult = new OperationResult<decimal>(0m, "");

            if (string.IsNullOrWhiteSpace(goalSteps))
            {
                operationResult.AddMessage("Goal steps must be entered");
                return operationResult;
            }
            if (string.IsNullOrWhiteSpace(actualSteps))
            {
                operationResult.AddMessage("Actual steps must be entered");
                return operationResult;
            }

            decimal goalStepCount = 0;
            if (!decimal.TryParse(goalSteps, out goalStepCount))
            {
                operationResult.AddMessage("Goal steps must be numeric");
                return operationResult;
            }

            decimal actualStepCount = 0;
            if (!decimal.TryParse(actualSteps, out actualStepCount))
            {
                operationResult.AddMessage("Actual steps must be numeric");
                return operationResult;
            }

            operationResult.Value = CalculatePercentOfGoalSteps(goalStepCount, actualStepCount);
            return operationResult;
        }
        #endregion

        #region ValidateEmail
        /// <summary>
        /// Validates the customer email address.
        /// </summary>
        /// <returns></returns>
        public OperationResult<bool> ValidateEmail()
        {
            var op = new OperationResult<bool>();

            if (string.IsNullOrWhiteSpace(this.EmailAddress))
            {
                op.Value = false;
                op.AddMessage("Email address is null");
            }

            if (op.Value)
            {
                var isValidFormat = true;
                // Code here that validates the format of the email
                // using Regular Expressions.
                if (!isValidFormat)
                {
                    op.Value = false;
                    op.AddMessage("Email address is not in a correct format");
                }
            }

            if (op.Value)
            {
                var isRealDomain = true;
                // Code here that confirms whether domain exists.
                if (!isRealDomain)
                {
                    op.Value = false;
                    op.AddMessage("Email address does not include a valid domain");
                }
            }
            return op;
        }
        #endregion
    }
}

