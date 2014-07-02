using System;

namespace WebApp.Models
{
    public class AbstractIdentificable
    { 
        [Identity]
        public int Id { get; set; }
    }

    public class IdentityAttribute : Attribute{
    }
}