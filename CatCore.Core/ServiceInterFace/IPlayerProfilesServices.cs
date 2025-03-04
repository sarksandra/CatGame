using Cat.Core.Domain;


namespace Cat.Core.ServiceInterface
{
    public interface IPlayerProfilesServices
    {
        Task<PlayerProfile> Create(string useridfor);
    }
}
