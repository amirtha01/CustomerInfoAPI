using System.Collections.Generic;
using CustomerInfoAPI.Model;

namespace CustomerInfoAPI.Interface
{
    /// <summary>
    /// Interface with the member methods that needs to be implemented by the Data Access Layer - CustomerRepository
    /// </summary>
    public interface ICustomer
    {
        //Get the list of existing customers
        List<Customer> GetCustomerList();

        //Add new customer to the data repository
        void AddCustomer(Customer cust);

        //Verify if the new customer's email address already exists in the data repository
        bool CheckDuplicateEmailAddress(string email);
    }
}

