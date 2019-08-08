using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Realms;

namespace TWG.Models
{
    public class TodoItem : RealmObject
    {
        public string Name { get; set; }

        public bool Done { get; set; }
    }
}