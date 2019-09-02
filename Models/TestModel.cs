using System;
using System.Collections.Generic;

namespace simple_redis_api.Models
{
    public class TestModel
    {
        public TestModel()
        {

        }

        public TestModel(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }

    public class ResponseModel
    {
        public ResponseModel(double totalSeconds, List<TestModel> model)
        {
            Model = model;
            TotalSeconds = totalSeconds;
        }
        public double TotalSeconds { get; set; }

        public List<TestModel> Model { get; set; }
    }
}