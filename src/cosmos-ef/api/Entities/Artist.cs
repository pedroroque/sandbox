namespace Api.Entities
{
    using System;

    public class Artist
    {
        public string Id { get; protected set; }
        public string Name { get; protected set; }

        public Artist(string name)
        {
            Id = name.Replace(' ','-').ToLower();
            Name = name;
        }

        public Artist() { }
    }
}