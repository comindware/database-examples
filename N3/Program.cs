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
using System.Linq;
using Comindware.Logics;
using Comindware.Logics.Raw;

namespace Comindware.Database.Examples.N3
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            // - N3-Interpreter
            Initializer.Initialize();
            Logics.N3.Initializer.Initialize();

            // N-Triples example
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName))
            {
                var statusPredicate = Names.Example.CreateName("status");
                var taskSubject = Names.Example.CreateName("task");
                var taskStatusClass = Names.Example.CreateName("taskStatus");

                // Reading...
                using (var reader = new StreamReader("Ontology/testData.n3"))
                {
                    var statements = Logics.NTriples.N3.Parse(reader);
                    model.AddStatements(statements);
                }
                var taskStatus = model.GetFact(taskSubject, statusPredicate);
                Console.WriteLine("task status is: {0}", Helpers.Beautify(taskStatus));

                // Writing...
                var statusMeta = model.EnumerableMatch(null, (Determinant<object, QName>)null, Logics.Names.Common.A, taskStatusClass).ToArray();
                using (var writer = new StreamWriter("Ontology/taskStatusClasses.n3"))
                {
                    Logics.NTriples.N3.WriteN3(statusMeta, writer);
                }
            }
        }
    }
}
