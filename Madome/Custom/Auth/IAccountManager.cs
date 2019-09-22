using System;
namespace Madome.Custom.Auth
{
    public interface IAccountManager
    {
        void Save(string name, string phone, string affiliation, string position, bool isEtri);
        string Name { get; }
        string Phone { get; }
        string Affiliation { get; }
        bool isEtri { get; }
        string Position { get; }
        bool LoginExists { get; }
        void Delete();
    }
}
