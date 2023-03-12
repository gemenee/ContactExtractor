using PersonContactExtractor.Persistance;
using WebApplication.Dto;

namespace PersonContactExtractor.Services;

public class ResponseConverter : IResponseConverter
{
	public ResultEntity Convert(ResponseDto[] responses, int documentId)
	{
		var result = new ResultEntity
		{
			Persons = new List<PersonContacts>(),
			DocumentId = documentId
		};
		foreach (var response in responses)
		{
			result.Persons.Add(ConvertResponse(response));
		}

		return result;
	}

	private PersonContacts ConvertResponse(ResponseDto response)
	{
		var year = response.BirthDate?.Date?.Year > 0 ? response.BirthDate?.Date?.Year : null;

		DateTime? date = year.HasValue ? new DateTime(
			year.Value,
			response.BirthDate.Date?.Month ?? 1,
			response.BirthDate.Date?.Day ?? 1) : null;

		return new PersonContacts
		{
			FirstName = response.NameDto.First,
			MiddleName = response.NameDto.Middle,
			LastName = response.NameDto.Last,
			BirthDate = date,
			Phone = response.Contacts.Phone,
			Email = response.Contacts.Email,

			Organization = response.Organization is not null ? new OrganizationEntity
			{
				Name = response.Organization.OrgName,
				Subdivision = response.Organization.UnitDto.ToString()
			} : null,
			Position = response.Position?.ToString()
		};
	}
}
