using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BusinessLayer
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string EmailAddress { get; set; }

        public string  FirstName { get; set; }

        public string LastName { get; set; }

        public void ValidateEmail()
        {
        }

		public decimal CalculatePercentofGoalSteps(string goalSteps, string actualSteps)
		{
			decimal goalStepsCount = 0;
			decimal actualStepsCount = 0;

			if (string.IsNullOrWhiteSpace(goalSteps)) throw new ArgumentException("Goal must be entered", "goalSteps");
			if (string.IsNullOrWhiteSpace(actualSteps)) throw new ArgumentException("Actual steps must be entered", "actualSteps");

			if (!decimal.TryParse(goalSteps, out goalStepsCount)) throw new ArgumentException("Goal must be numeric", "goalSteps");
			if (!decimal.TryParse(actualSteps, out actualStepsCount)) throw new ArgumentException("Actual steps must be numeric", "actualSteps");

			return CalculatePercentofGoalSteps(goalStepsCount, actualStepsCount);

		}
		public decimal CalculatePercentofGoalSteps(decimal goalSteps, decimal actualSteps)
		{
			if (goalSteps <= 0) throw new ArgumentException("GoalSteps must me greater than 0", "goalSteps");

			return actualSteps / goalSteps * 100;
		}
    }
}
