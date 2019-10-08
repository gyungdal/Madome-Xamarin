using System;
using System.Threading.Tasks;

namespace Madome.Custom.Auth
{
    public interface IAccountManager
    {
		/// <summary>
		/// 저장된 서버의 URL을 반환
		/// </summary>
		/// <returns>서버의 URL</returns>
		public string Url();

		/// <summary>
		/// 마지막으로 발급된 서버 토큰을 반환
		/// </summary>
		/// <returns>마지막으로 발급된 Token</returns>
		public string Token();

		/// <summary>
		/// 마지막 토큰을 발급할때 사용한 Email을 반환
		/// </summary>
		/// <returns>마지막 토큰을 발급할때 사용한 Email</returns>
		public string Email();

		/// <summary>
		/// 서버에서 발급된 토큰과 이메일, URL등 추후 앱 구동에 필요한 데이터들을 저장
		/// 이때, 기존 데이터와 충돌을 막기 위해서,기존 데이터는 삭제
		/// </summary>
		/// <param name="url">서버 주소</param>
		/// <param name="email">token 발급에 사용된 이메일</param>
		/// <param name="token">서버에서 발급된 Token</param>
		public void Save(string url, string email, string token);

		/// <summary>
		/// 저장된 데이터에 토큰이 있는지 확인
		/// </summary>
		/// <returns>Token의 유무</returns>
		public bool HasToken();

		/// <summary>
		/// 저장된 데이터에서 토큰만 삭제
		/// </summary>
		public void DeleteToken();

		/// <summary>
		/// 데이터 전체 삭제
		/// </summary>
		public void Delete();
    }
}
