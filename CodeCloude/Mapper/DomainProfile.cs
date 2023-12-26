using AutoMapper;
using CodeCloude.Data.Entities;
using CodeCloude.Models;

namespace Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Addition_TermsVM, Addition_Terms>();
            CreateMap<Addition_Terms, Addition_TermsVM>();

            CreateMap<CategoriesVM, Categories>();
            CreateMap<Categories, CategoriesVM>();
            
            CreateMap<CountriesVM, Countries>();
            CreateMap<Countries, CountriesVM>();

            CreateMap<FavouritesVM, Favourites>();
            CreateMap<Favourites, FavouritesVM>();

            CreateMap<privacypolicyVM, privacypolicy>();
            CreateMap<privacypolicy, privacypolicyVM>();

            CreateMap<QuestionsVM, Questions>();
            CreateMap<Questions, QuestionsVM>();

            CreateMap<SliderVM, Slider>();
            CreateMap<Slider, SliderVM>();

            CreateMap<StoresVM, Stores>();
            CreateMap<Stores, StoresVM>();

            CreateMap<Terms_ConditionsVM, Terms_Conditions>();
            CreateMap<Terms_Conditions, Terms_ConditionsVM>();

            CreateMap<ContcatUsVM, ContcatUs>();
            CreateMap<ContcatUs, ContcatUsVM>();

              CreateMap<SubscriptionsVM, Subscriptions>();
            CreateMap<Subscriptions, SubscriptionsVM>();

           
              CreateMap<SubscripeRequestsVM, SubscripeRequests>();
            CreateMap<SubscripeRequests, SubscripeRequestsVM>();

              CreateMap<BankDetailsVM, BankDetails>();
            CreateMap<BankDetails, BankDetailsVM>();


                 CreateMap<User_FaviouritesVM, User_Faviourites>();
            CreateMap<User_Faviourites, User_FaviouritesVM>();

                 CreateMap<UserSubscriptionVM, UserSubscription>();
            CreateMap<UserSubscription, UserSubscriptionVM>();

           



        }
    }
}
