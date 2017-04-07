﻿namespace DAL.Interface.DTO
{
    public class DalUser : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public DalRole Role { get; set; }
    }
}