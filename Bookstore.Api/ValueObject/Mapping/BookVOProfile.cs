using AutoMapper;
using Bookstore.Application.ViewModel.Book;

namespace Bookstore.Api.ValueObject.Mapping
{
    public class BookVOProfile : Profile
    {
        public BookVOProfile()
        {
            CreateMap<EditorBookValueObject, EditorBookViewModel>().ReverseMap();
        }
    }
}