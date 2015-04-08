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
using Comindware.Common;
using Comindware.Logics;
using Comindware.Logics.NTriples;
using Comindware.Logics.Think;
using Initializer = Comindware.Logics.Initializer;

namespace Comindware.Database.Examples.Rules
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            // - N3-Interpreter
            // - Brain
            Initializer.Initialize();
            Logics.N3.Initializer.Initialize();
            Logics.Think.Initializer.Initialize();

            // Simple inference example
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(@"
                    @prefix : <http://www.example.com/logics/example#>.

                    :Paul :mother :Rita.
                    :Rita :mother :Caroline.

                    {
                        ?x :mother ?y.
                        ?y :mother ?z.
                    }
                    =>
                    {
                        ?x :grandmother ?z
                    }.

                ".ParseString());

                var grandmother = model.GetFact(Names.Paul, Names.Grandmother);
                Console.WriteLine("Paul's grandmother is: {0}", Helpers.Beautify(grandmother));
            }

            // Recursion example
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(@"
                @prefix : <http://www.example.com/logics/example#>.

                :Paul a :Person;
                    :child :Rita;
                    :child :Caroline.

                :Rita a :Person.

                :Caroline a :Person;
                    :child :Dirk.

                :Dirk a :Person.

                :Greta a :Person;
                    :child :Jos.

                :Jos a :Person.

                # First rule: end of recursion
                {
                    ?x a :Person.
                    ?x :child ?y.
                }
                =>
                {
                    ?x :descendants ?y.
                }.

                # Second rule: recursion body
                {
                    ?x a :Person.
                    ?x :child ?z.
                    ?z :descendants ?y.
                }
                =>
                {
                    ?x :descendants ?y.
                }.
                ".ParseString());

                var descendants = model.GetFacts(Names.Paul, Names.Example.CreateName("descendants")).ToArray();
                Console.WriteLine("Paul's descendants: {0}", string.Join(", ", descendants.Select(Helpers.Beautify)));
            }
        }
    }
}
