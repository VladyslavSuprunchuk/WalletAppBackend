using AutoMapper;
using WalletAppBackend.Core.Models;
using WalletAppBackend.DatabaseProvider.Models;

namespace WalletAppBackend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Card, CardClient>();
            CreateMap<User, UserClient>().ForMember(x => x.Points, opt => opt.Ignore());
            CreateMap<UserClient, User>();
            CreateMap<TransactionClient, Transaction>();
            CreateMap<Transaction, TransactionClient>();
        }
    }
}
