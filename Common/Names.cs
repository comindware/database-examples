// ***********************************************************************
// <author>Stepan Burguchev</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2015. All rights reserved.
// </copyright>
// <summary>
//   Names.cs
// </summary>
// ***********************************************************************

using Comindware.Logics;

namespace Comindware.Database.Examples
{
    internal static class Names
    {
        // Namespaces
        public static readonly QDomain Example;
        public static readonly QName DatabaseName;
        public static readonly QName Brain;
        public static readonly QName SecondDatabaseName;

        // Subjects
        public static readonly QName Frans;
        public static readonly QName Maria;
        public static readonly QName Jos;
        public static readonly QName Rita;
        public static readonly QName Geert;
        public static readonly QName Caroline;
        public static readonly QName Dirk;
        public static readonly QName Greta;
        public static readonly QName Paul;
        public static readonly QName Dp;

        // Predicates
        public static readonly QName Sex;
        public static readonly QName SpouseIn;
        public static readonly QName ChildIn;
        public static readonly QName Father;
        public static readonly QName Mother;
        public static readonly QName Parent;
        public static readonly QName Child;
        public static readonly QName Daughter;
        public static readonly QName Son;
        public static readonly QName Ancestor;
        public static readonly QName Descendent;
        public static readonly QName Grandfather;
        public static readonly QName Grandmother;
        public static readonly QName Grandparent;
        public static readonly QName Grandchild;
        public static readonly QName Granddaughter;
        public static readonly QName Grandson;

        // Objects
        public static readonly QName Female;
        public static readonly QName Male;

        static Names()
        {
            Example = Logics.Names.Internal.Uri.CreateDomain("http://www.example.com/logics/example#");
            Brain = Example.CreateName("brain");
            DatabaseName = Example.CreateName("database");
            SecondDatabaseName = Example.CreateName("secondDatabase");

            Frans = Example.CreateName("Frans");
            Maria = Example.CreateName("Maria");
            Jos = Example.CreateName("Jos");
            Rita = Example.CreateName("Rita");
            Geert = Example.CreateName("Geert");
            Caroline = Example.CreateName("Caroline");
            Dirk = Example.CreateName("Dirk");
            Greta = Example.CreateName("Greta");
            Paul = Example.CreateName("Paul");
            Dp = Example.CreateName("dp");

            Sex = Example.CreateName("sex");
            SpouseIn = Example.CreateName("spouseIn");
            ChildIn = Example.CreateName("childIn");
            Father = Example.CreateName("father");
            Mother = Example.CreateName("mother");
            Parent = Example.CreateName("parent");
            Child = Example.CreateName("child");
            Daughter = Example.CreateName("daughter");
            Son = Example.CreateName("son");
            Ancestor = Example.CreateName("ancestor");
            Descendent = Example.CreateName("descendent");
            Grandfather = Example.CreateName("grandfather");
            Grandmother = Example.CreateName("grandmother");
            Grandparent = Example.CreateName("grandparent");
            Grandchild = Example.CreateName("grandchild");
            Granddaughter = Example.CreateName("granddaughter");
            Grandson = Example.CreateName("grandson");

            Female = Example.CreateName("female");
            Male = Example.CreateName("male");
        }
    }
}
