
using System.ComponentModel.DataAnnotations;


namespace RepositoryPatternWithUOW.Core.Models
{
	public class Author
	{
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; } = null!;
	}
}
