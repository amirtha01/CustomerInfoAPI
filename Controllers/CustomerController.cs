using CustomerInfoAPI.Interface;
using CustomerInfoAPI.Model;
using CustomerInfoAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInfoAPI.Controllers
{
    /// <summary>
    /// Customer Controller with the Get and Post operations of the REST based Web API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
       //Instance of the Data Access Layer - CustomerRepository
       private ICustomer customerRepository = new CustomerRepository();

        /// <summary>
        /// Get the list of Customers from the Data repository - CustomerData.txt
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomerList()
        { 
            return customerRepository.GetCustomerList();        
        }

        /// <summary>
        /// Get the Customer Info from the client consuming the REST API and add the new customer info into the Data repository
        /// Business Rules: 
        /// 1. Email Address is required
        /// 2. Verify if the email address already exists in the Data repository. 
        /// Do not add duplicate customer information with the same Email Address 
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(400)]
        public IActionResult AddCustomer([FromBody] Customer newCustomer)
        {
            if (newCustomer == null)
            {
                return BadRequest("Customer data is null");
            }

            if (ModelState.IsValid)
            {
                bool emailExists = customerRepository.CheckDuplicateEmailAddress(newCustomer.EmailAddress);

                if (!emailExists)
                {
                    customerRepository.AddCustomer(newCustomer);
                }
                else
                {
                    return BadRequest("Email Address already available");
                }
                
            }
            else
            {
                return BadRequest("Model State is invalid");
            }            
                        
            return CreatedAtAction("AddCustomer", newCustomer);
        }

    }
}
