using AutoMapper;
using TaskNode.Dtos;
using TaskNode.Models;

namespace TaskNode.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<TodoItem, TodoItemDto>();
        CreateMap<TodoItemDto, TodoItem>();
        CreateMap<TodoItemCreateDto, TodoItem>();
        CreateMap<TodoItemUpdateDto, TodoItem>();
    }
}