using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.Application.ViewModel.Author;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Services.Mappings
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<Author, AuthorResponseViewModel>();
            });

            CreateMap<Author, AuthorResponseViewModel>()
                .ForMember(x => x.Books, opt => opt.MapFrom(x => x.Books));

            CreateMap<AuthorResponseViewModel, Author>()
                .ForMember(x => x.Books, opt => opt.Ignore());

                
        }
    }
}