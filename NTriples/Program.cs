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
using System.IO;
using Comindware.Logics;
using Comindware.Logics.NTriples;

namespace Comindware.Database.Examples.NTriples
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

            // N-Triples example
            using (var model = ModelManager.CreateInMemoryModel(Names.Frans))
            {
                // Reading...
                using (var reader = new StreamReader("Ontology/testData.n3"))
                {
                    var statements = N3.Parse(reader);
                    model.AddStatements(statements);
                }

                var taskStatus = model.GetFact(Logics.Names.CreateName("task"), Logics.Names.CreateName("status"));
                Console.WriteLine("task status is: {0}", Helpers.Beautify(taskStatus));

                // Writing...

                // TODO
            }
        }
    }
}
