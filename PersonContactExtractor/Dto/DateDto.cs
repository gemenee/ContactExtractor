namespace WebApplication.Dto
{

	public class BirthDateDto { 
		public DateDto Date { get; set; }
	}

	public class DateDto
	{
		public int? Year { get; set; }
		public int? Month { get; set; }
		public int? Day { get; set; }
	}
}