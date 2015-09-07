namespace PM.BL
{
    /// <summary>
    /// Manages the repository of customer information
    /// </summary>
    public class CustomerRepository
    {
        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="customer"></param>
        public void Add(Customer customer)
        {
            // -- If this is a new customer, create the customer record --
            // Determine whether the customer is an existing customer.
            // If not, validate entered customer information
            // If not valid, notify the user.
            // If valid,
            // Open a connection
            // Set stored procedure parameters with the customer data.
            // Call the save stored procedure.

        }

        /// <summary>
        /// Updates customer information.
        /// </summary>
        public void Update()
        {
            // Open a connection
            // Set stored procedure parameters with the customer data.
            // Call the save stored procedure.
        }
    }
}
