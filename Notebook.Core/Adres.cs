﻿namespace Notebook.Core
{
    public class Adres
    {
        public int Id { get; set; }
        public uint Index { get; set; } //TODO should be unique
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}