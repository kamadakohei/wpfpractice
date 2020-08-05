using System;

namespace WpfApp9.Models
{
    internal class Person
    {
        public string FamilyName { get; set; }

        public string FirstName { get; set; }

        public string FullName { get { return this.FamilyName + this.FirstName; } }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsAuthenticated { get; set; }
    }
}