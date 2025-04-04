using AutoMapper;
using WatchStore.API.Models;
using WatchStore.API.Models.DTO;

namespace WatchStore.API.Mappings
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Watch, WatchDTO>().ReverseMap();
            CreateMap<Watch, AddWatchRequestDTO>().ReverseMap();
            CreateMap<Watch, UpdateWatchRequestDTO>().ReverseMap();
            CreateMap<Brand, BrandsDTO>().ReverseMap();
            CreateMap<Brand, AddBrandRequest>().ReverseMap();
            CreateMap<Brand, UpdateBrandRequest>().ReverseMap();
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, AddCustomerRequest>().ReverseMap();
            CreateMap<Customer, UpdateCustomerRequestDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, AddOrderRequest>().ReverseMap();
            CreateMap<Order, UpdateOrderRequestDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, AddReviewRequestDTO>().ReverseMap();

        }
    }
}
