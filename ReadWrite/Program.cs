// ***********************************************************************
// <author>Stepan Burguchev</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2015. All rights reserved.
// </copyright>
// <summary>
//   Program.cs
// </summary>
// ***********************************************************************
using System;
using System.Linq;
using Comindware.Logics;

namespace Comindware.Database.Examples.ReadWrite
{
    class Program
    {
        static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            // - N3-Interpreter
            // - Brain
            Initializer.Initialize();
            Logics.N3.Initializer.Initialize();
            Logics.Think.Initializer.Initialize();

            // Read/Write operations example
            using (var model = ModelManager.CreateInMemoryModel(Names.Frans))
            {
                var agePredicate = model.CreateName("age");

                // Writing...

                // using AddFact (recommended way)
                model.AddFact(Names.Caroline, Names.Mother, Names.Maria);
                // Directly, by adding a statement...
                model.AddStatement(Names.Maria, Names.Child, Names.Caroline);
                // or statements
                model.AddStatements(
                    new[]
                        {
                            new Statement(Names.Maria, Names.Child, Names.Geert)
                        });
                // Implying that the subject is model.Name
                model.AddFact(Names.Child, Names.Caroline);
                model.AddFact(agePredicate, 42);

                // Straightforward way to read...

                // Full statements
                var statements = model.GetStatements(Names.Caroline, Names.Mother);
                Console.WriteLine("Caroline's mother (GetStatements): {0}", Helpers.Beautify(statements.First().Object));
                // Or statement objects only
                var facts = model.GetFacts(Names.Caroline, Names.Mother);
                Console.WriteLine("Caroline's mother (GetFacts): {0}", Helpers.Beautify(facts.First()));
                // Getting single object
                var fact = model.GetFact(Names.Frans, Names.Child);
                Console.WriteLine("Frans's child (GetFact): {0}", Helpers.Beautify(fact));
                // Or single value
                var fransAge = model.GetFact<int>(Names.Frans, agePredicate);
                Console.WriteLine("Frans's age (GetFact<int>): {0}", fransAge);
                // Checking fact existence
                var mariaChildGreet = model.HasFact(Names.Maria, Names.Child, Names.Geert);
                Console.WriteLine("Maria has a child named Greet (HasFact): {0}", mariaChildGreet);
                // Getting subjects
                var carolineParent = model.GetSubjects(Names.Child, Names.Caroline);
                Console.WriteLine("Caroline's parents are (GetSubjects): ({0})", string.Join(" ", carolineParent.Select(Helpers.Beautify)));

                // Optimized way...

                // There are the same set of methods to make queries omitting inference engine (the Brain).
                // If database models are nested into each over and there are several brains in work, only the top-level brain is ignored.
                // If there are not brains in work, axioms database is considered as empty.
                var carolineMother = model.GetAxiom(Names.Frans, Names.Mother);
                Console.WriteLine("Caroline's mother (GetAxiom): {0}", Helpers.Beautify(carolineMother));
            }
        }
    }
}
