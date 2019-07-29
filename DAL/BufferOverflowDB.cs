using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BufferOverflowDB:DbContext
    {
        public BufferOverflowDB() : base("BufferOverflowDB")
        {

        }


        public DbSet<UserEntity> UserDb { get; set; }
        public DbSet<AnswerEntity> AnswerDb { get; set; }
        public DbSet<QuestionEntity> QuestionDb { get; set; }
        public DbSet<VoteEntity> VoteDb { get; set; }
    }
}
