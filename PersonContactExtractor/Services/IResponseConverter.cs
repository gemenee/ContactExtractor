using PersonContactExtractor.Persistance;
using WebApplication.Dto;

namespace PersonContactExtractor.Services
{
	public interface IResponseConverter
	{
		ResultEntity Convert(ResponseDto[] responses, int documentId);
	}
}