using System;
using System.Collections.Generic;

namespace ShowBiz.Models
{
    public abstract class Production
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }

        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Rating> Ratings { get; set; } = new List<Rating>(); // Production:Rating = 1:n 
    }

    public class Series : Production
    {
        public int EpisodeCounts { get; set; }
    }

    public class Movie : Production
    {
        public TimeSpan Duration { get; set; }
    }

    // 극중인물

    public class Character 
    {
        public int Id { get; set; }
        public int ProductionId { get; set; } // EF Core의 규칙을 그대로 쓸거라면, 속성 이름이 중요 `[EntityName]Id` 로 되어야 함. 아니면, C# Attribute 를 써야함.  
        public string Name { get; set; }
        public int ActorId { get; set; } // [EntityName]Id 
        
        public Production Production { get; set; } // Character:Production = 1:1
        public Actor Actor { get; set; } // Character:Actor = 1:1 or n:1 
    }

    // 배우.

    public class Actor 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<Character> Characters { get; set; } = new List<Character>(); // Actor:Character = 1:n
    }

    public class Rating
    {
        public int Id { get; set; }
        public int ProductionId { get; set; }
        public int Stars { get; set; }
        public string Source { get; set; }
        
        public Production Production { get; set; } // Rating:Production = 1:1 or n:1
    }
}