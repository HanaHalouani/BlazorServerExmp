using DataAccesslibrairy.Models;

namespace DataAccesslibrairy;

public interface IPeopleData
{
    Task<List<PeopleModel>> GetPeople();
    Task<List<PeopleModel>> GetPeopleById(int? personId);
    Task InsertPerson(PeopleModel person);
    Task UpdatePerson(PeopleModel person);
}