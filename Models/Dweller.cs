using System;
using System.ComponentModel.DataAnnotations;

namespace OldTechApp.Models
{
    [Serializable]
    public class Dweller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Version { get; private set; }
    }
}