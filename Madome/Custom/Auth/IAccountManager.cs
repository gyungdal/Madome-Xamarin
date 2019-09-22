using System;
namespace Madome.Custom.Auth
{
    public interface IAccountManager
    {
		void Save(string name, string id, string email, DateTime createdAt);
        string Name { get; }
        string Id { get; }
        string Email{ get; }
		DateTime CreatedAt{ get; }
        string Position { get; }
        void Delete();
    }
}
