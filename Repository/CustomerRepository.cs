using CustomerInfoAPI.Interface;
using CustomerInfoAPI.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomerInfoAPI.Repository
{
    /// <summary>
    /// Data Access Layer (DAL) to be used by the CustomerController to perform the following data operations:
    /// 1. Get the list of existing customers
    /// 2. Save the new customer to the data repository
    /// 3. Check if the customer email address already exists in the data repository
    /// </summary>
    public class CustomerRepository : ICustomer
    {
        string dataFileName = "Data/CustomerData.txt";
                
        /// <summary>
        /// Add new customers to the data repository (CustomerData.txt file)
        /// </summary>
        /// <param name="newCustomer"></param>
        public void AddCustomer(Customer newCustomer)
        {            
            //Read the Data file with Json data
            var json = System.IO.File.ReadAllText(dataFileName);

            // De-serialize Json string to object or create new list when the json string is empty
            var custList = JsonConvert.DeserializeObject<List<Customer>>(json)?? new List<Customer>();

            //Add customer to the list
            custList.Add(newCustomer);

            //Serialize the Customer list to a JSOM string
            json = JsonConvert.SerializeObject(custList);

            //Write the Json string to the CustomerData.txt file
            System.IO.File.WriteAllText(dataFileName, json);
        }

        /// <summary>
        /// Check if the customer email address already exists in the data repository
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool CheckDuplicateEmailAddress(string emailAddress)
        {
            //Read the Data file with Json data
            string jsonStr = File.ReadAllText(dataFileName);

            if (!string.IsNullOrEmpty(jsonStr))
            {
                //Create JArray from the JSon String
                var custJsonArr = JArray.Parse(jsonStr);
                
                foreach (JObject obj in custJsonArr)
                {
                    //Verify if email address exists
                    if (obj["EmailAddress"].ToString() == emailAddress)
                    {
                        return true;
                    }
                }
            }
           
            return false;
        }

        /// <summary>
        /// Get the list of existing customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomerList()
        {
            List<Customer> customerList = new List<Customer>();

            //Read the Data file with Json data
            string json = File.ReadAllText(dataFileName);

            //Deserialize the Json string into a list of type Customer
            var custList = JsonConvert.DeserializeObject<List<Customer>>(json)?? new List<Customer>();

            customerList = custList;

            //Return the list of customers to controller
            return customerList;
        }
    }
}
