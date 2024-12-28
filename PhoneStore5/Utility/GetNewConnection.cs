using Microsoft.Data.SqlClient;

namespace PhoneStore5.Utility
{
    public class GetNewConnection
    {
        private readonly IConfiguration _configuration;

        public GetNewConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection NewConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
