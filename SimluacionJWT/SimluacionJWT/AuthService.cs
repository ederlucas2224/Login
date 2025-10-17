using System.Security.Cryptography;

namespace SimluacionJWT
{
	public class AuthService
	{
		private readonly string _genericUsername = "Eder";
		private readonly string _genericPassword = "1234";
		private readonly string _genericRol = "Programador";

		private string _token;
		private DateTime _tokenExpiration;

		public bool Login(string username, string password)
		{
			if (username == _genericUsername && password == _genericPassword)
			{
				_token = GenerateToken();
				_tokenExpiration = DateTime.UtcNow.AddMinutes(2);
				return true;
			}
			return false;
		}

		public string GetToken()
		{
			if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpiration)
				return _token;
			return null;
		}

		public DateTime? GetTokenExpiration()
		{
			if (!string.IsNullOrEmpty(_token) && DateTime.UtcNow < _tokenExpiration)
				return _tokenExpiration;
			return null;
		}

		private string GenerateToken()
		{
			using var rng = RandomNumberGenerator.Create();
			var bytes = new byte[32];
			rng.GetBytes(bytes);
			return "SINNTEC" + Convert.ToBase64String(bytes);
		}
	}
}
