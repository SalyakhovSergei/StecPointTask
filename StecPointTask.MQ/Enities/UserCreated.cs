﻿namespace StecPointTask.MQ.Enities
{
    public interface UserCreated
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public OrganizationCreated Organization { get; set; }
    }
}