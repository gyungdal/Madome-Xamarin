using System;
namespace Madome.Custom.Auth
{
    public interface IAccountManager
    {
		void Save(string name, string id, string email, DateTime createdAt){
			Save(name, id, email, createdAt, false);
		}
        void Save(string name, string id, string email, DateTime createdAt, bool loginExists);
        string Name { get; }
        string Id { get; }
        string Email{ get; }
		DateTime CreatedAt{ get; }
        string Position { get; }
        bool LoginExists { get; }
        void Delete();
    }
}
