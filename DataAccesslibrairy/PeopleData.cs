using DataAccesslibrairy.Models;

namespace DataAccesslibrairy
{
    public class PeopleData : IPeopleData
    {
        private readonly ISqlDataAccess _db;

        public PeopleData(ISqlDataAccess db)
        {
            _db = db;
        }


        public async Task<List<PeopleModel>> GetPeople()
        {
            string sql = "select * from dbo.Person";
            return await _db.LoadData<PeopleModel, dynamic>(sql, new { });

        }

        public async Task<List<PeopleModel>> GetPeopleById(int? personId)
        {
            string sql = $"select * from dbo.Person where Id = {personId}";
            return await _db.LoadData<PeopleModel, dynamic>(sql, new { });

        }

        public async Task InsertPerson(PeopleModel person)
        {
            string sql = @"insert into dbo.Person (FirstName, LastName, Email) 
                            values (@FirstName,@LastName,@Email); ";
            _db.SaveData<PeopleModel, dynamic>(sql, person);
        }
        public async Task UpdatePerson(PeopleModel person)
        {
            string sql = $"update dbo.Person set FirstName = '{person.FirstName}',LastName = '{person.LastName}',Email = '{person.Email}' where  Id = {person.Id}; ";
            await _db.SaveData<PeopleModel, dynamic>(sql, person);


        }
    }
}
