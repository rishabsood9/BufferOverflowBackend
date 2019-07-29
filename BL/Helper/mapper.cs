using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Entities;
using Shared.DTO;

namespace BL.Helper
{
    public static class EntityMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(map => {
                map.CreateMap<UserDTO, UserEntity>().ReverseMap();
                map.CreateMap<AnswerDTO, AnswerEntity>().ReverseMap();
                map.CreateMap<QuestionDTO, QuestionEntity>().ReverseMap();
                map.CreateMap<VoteDTO, VoteEntity>().ReverseMap();
            });
        }
    }
}
