﻿namespace Notebook.Application.DTOs
{
    public class AddressDto
    {
        public int Id { get; set; }
        public uint Index { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}