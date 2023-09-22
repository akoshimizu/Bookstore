using AutoMapper;
using Bookstore.Application.ViewModel.Book;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Services.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, EditorBookViewModel>().ReverseMap();
        }
    }
}