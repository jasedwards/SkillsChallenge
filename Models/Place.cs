﻿namespace InterviewTest.Models
{
    public class Place
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string DisplayAddress => City + ", " + State;
    }
}
