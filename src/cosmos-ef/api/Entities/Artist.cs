namespace Api.Entities
{
    using System;

    public class Artist
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Artist(string name)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
        }
    }
}