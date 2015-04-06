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

            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(N3.ParseString(@"
                    @prefix : <http://www.example.com/logics/example#>.

                    :Paul :mother :Rita.
                    :Rita :mother :Caroline.

                    {
                        ?x :mother ?y.
                        ?y :mother ?z
                    }
                    =>
                    {
                        ?x :grandmother ?z
                    }.

                "));

                var grandmother = model.GetFact(Names.Paul, Names.Grandmother);
                Console.WriteLine("Paul's grandmother is: {0}", Helpers.Beautify(grandmother));
            }
        }
    }
}
