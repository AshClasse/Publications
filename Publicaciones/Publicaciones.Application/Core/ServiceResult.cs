
namespace Publicaciones.Application.Core
{
	public class ServiceResult
	{
		public bool Success { get; set; } = true;
		public string Message { get; set; }
		public dynamic? Data { get; set; }
	}
}
