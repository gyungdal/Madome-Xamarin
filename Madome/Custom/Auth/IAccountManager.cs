using System;
using System.Threading.Tasks;
using Madome.Enum.Auth;

namespace Madome.Custom.Auth
{
    public interface IAccountManager
    {
		/// <summary>
		/// SecureStorage에 저장된 Account 정보를 반환합니다.
		/// </summary>
		/// <param name="type">요청할 계정 정보의 종류</param>
		/// <returns>저장되어있는 정보</returns>
		string Get(AccountTokenType type);

		/// <summary>
		/// 저장된 데이터에 토큰이 있는지 확인
		/// </summary>
		/// <returns>Token의 유무</returns>
		bool HasToken { get; }

		/// <summary>
		/// 토큰 업데이트
		/// </summary>
		string UpdateToken { set; }

		/// <summary>
		/// 서버에서 발급된 토큰과 이메일, URL등 추후 앱 구동에 필요한 데이터들을 저장
		/// 이때, 기존 데이터와 충돌을 막기 위해서,기존 데이터는 삭제
		/// </summary>
		/// <param name="url">서버 주소</param>
		/// <param name="email">token 발급에 사용된 이메일</param>
		/// <param name="token">서버에서 발급된 Token</param>
		void Save(string url, string email, string token);

		/// <summary>
		/// 계정 데이터 삭제
		/// </summary>
		void Delete();
    }
}
