﻿namespace MimoDomain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<CourseProgress> CourseProgress { get; set; } = new List<CourseProgress>();
    }
}
