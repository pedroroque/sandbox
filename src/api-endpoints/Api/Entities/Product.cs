namespace Api.Entities
{
    using System;

    public class Product
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}