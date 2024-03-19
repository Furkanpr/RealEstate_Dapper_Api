using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using Dapper;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        // Ekleme işlemi
        public async void CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category(CategoryName, CategoryStatus) values (@categoryName,@categoryStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("categoryStatus",true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
        // Silme İşlemi
        public async void DeleteCategory(int id)
        {
            string query = "Delete From Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
            using (var connections = _context.CreateConnection()) 
            { 
                await connections.ExecuteAsync(query,paramaters);
            }


        }
        // Listeleme işlemi
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select * From Category";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }
        // Seçilen ürüne göre arama işlemi
        public async Task<GetByIDCategoryDto> GetCategory(int id)
        {
            string query = "Select * From Category Where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryID", id);
            using (var connection = _context.CreateConnection())
            {
               var values= await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDto>(query, paramaters);
                return values;
            }
        }

        // Güncelleme İşlemi
        public async void UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "Update Category Set CategoryName=@categoryName, CategoryStatus=@categoryStatus where CategoryID=@categoryID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName",categoryDto.CategoryName);
            paramaters.Add("@categoryStatus", categoryDto.CategoryStatus);
            paramaters.Add("@categoryID", categoryDto.CategoryID);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, paramaters);
            }

        }
    }
}
