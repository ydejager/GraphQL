using System;

namespace EfGraphQl.Data
{
    public class Task
    {
        public Guid Id { get; private set; }

        public Task(Guid id) => Id = id;
    }
}