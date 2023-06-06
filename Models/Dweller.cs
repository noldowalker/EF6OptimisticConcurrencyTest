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
        
        //ToDo: колонка должна быть или с одинаковым названием, или как-то еще это все обдумать, как показывать платформе 
        //ToDo: что именно эта колонка такая, может ее в бейз модел включить, но тогда выпадут системные сущности.
        public string Version { get; private set; }
    }
}