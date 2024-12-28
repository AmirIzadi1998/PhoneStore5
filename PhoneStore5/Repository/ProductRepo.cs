using Dapper;
using PhoneStore5.Models;
using PhoneStore5.Utility;

namespace PhoneStore5.Repository
{
    public class ProductRepo : IProduct
    {
        private readonly GetQueryDapper _queryDapper;
        private readonly GetNewConnection _connection;

        public ProductRepo(GetQueryDapper queryDapper, GetNewConnection connection)
        {
            _queryDapper = queryDapper;
            _connection = connection;
        }

        public async Task Insert(PhoneProduct model)
        {
            var query = _queryDapper.QueryInsert();

            using (var connection = _connection.NewConnection())
            {
                await connection.ExecuteAsync(query, model);
            }
        }

        public async Task<PhoneProduct> GetById(int Id)
        {
           
            using (var connection = _connection.NewConnection())
            {
                var query = _queryDapper.GetById();
                var result = await connection.QuerySingleOrDefaultAsync<PhoneProduct>(query, new { Id = Id });
            return result;
            }
        }

        public async Task<List<PhoneProduct>> GetAll()
        {
            using (var connection = _connection.NewConnection())
            {
                var query = _queryDapper.QueryGetAll();
                var result = await connection.QueryAsync<PhoneProduct>(query);
                return result.ToList();
            }
        }

        public async Task Delete(int Id)
        {
            using (var connection = _connection.NewConnection())
            {
                var query = _queryDapper.Delete();
                await connection.ExecuteAsync(query, new { Id = Id });
            }
        }

        public async Task Update(PhoneProduct phoneProduct)
        {
            using (var connection = _connection.NewConnection())
            {
                var query = _queryDapper.QueryUpdate();
                await connection.ExecuteAsync(query, phoneProduct);
            }
        }

        public async Task<PhoneProduct> Search(int Id)
        {
            using (var connection = _connection.NewConnection())
            {
                var query = _queryDapper.QuerySearch();
                return await connection.QuerySingleOrDefaultAsync<PhoneProduct>(query, new { Id = Id });
            }
        }
    }
}