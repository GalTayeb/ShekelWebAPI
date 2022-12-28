using System.Data;
using System.Data.SqlClient;

namespace ShekelWebAPI.Models
{
    public class API
    {
        public GetResponse GetList(SqlConnection connection)
        {
            GetResponse getResponse = new GetResponse();
            SqlDataAdapter da = new SqlDataAdapter("SELECT g.groupCode,g.groupName,ftc.customerId FROM FactoriesToCustomer ftc LEFT JOIN Groups g ON ftc.groupCode=g.groupCode", connection);
            DataTable dt = new DataTable();
            List<Group> listGroups = new List<Group>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Customer customer = new Customer();
                    Group group = new Group();
                    group.GroupCode = Convert.ToInt32(dt.Rows[i]["GroupCode"]);
                    group.GroupName = Convert.ToString(dt.Rows[i]["GroupName"]);
                    group.CustomerId = Convert.ToString(dt.Rows[i]["CustomerId"]);
                    listGroups.Add(group);
                }
            }
            if (listGroups.Count > 0)
            {
                getResponse.StatusCode = 200;
                getResponse.StatusMessage = "OK";
                getResponse.List = listGroups;
            }
            else
            {
                getResponse.StatusCode = 100;
                getResponse.StatusMessage = "No data found";
                getResponse.List = null;
            }

            return getResponse;
        }

        public PostResponse AddCustomer(SqlConnection connection, Customer customer)
        {
            PostResponse postResponse = new PostResponse();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers VALUES ('" + customer.CustomerId + "','" + customer.Name + "','" + customer.Address + "','" + customer.Phone + "'); INSERT INTO FactoriesToCustomer VALUES (" + customer.GroupCode + "," + customer.FactoryCode + ",'" + customer.CustomerId + "');", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                postResponse.StatusCode = 200;
                postResponse.StatusMessage = "Customer added";
            }
            else
            {
                postResponse.StatusCode = 100;
                postResponse.StatusMessage = "No data inserted";
            }

            return postResponse;
        }

    }
}
