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
using Comindware.Common;
using Comindware.Logics;
using Comindware.Logics.NTriples;
using Comindware.Logics.Raw;

namespace Comindware.Database.Examples.NTriples
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            Initializer.Initialize();

            // N-Triples example
            using (var model = ModelManager.CreateInMemoryModel(Names.Example))
            {
                var statusPredicate = Logics.Names.CreateName("status");
                var taskSubject = Logics.Names.CreateName("task");
                var taskStatusClass = Logics.Names.CreateName("taskStatus");

                // Reading...
                using (var reader = new StreamReader("Ontology/testData.n3"))
                {
                    var statements = N3.Parse(reader);
                    model.AddStatements(statements);
                }

                var taskStatus = model.GetFact(taskSubject, statusPredicate);
                Console.WriteLine("task status is: {0}", Helpers.Beautify(taskStatus));

                // Writing...
                var statusMeta = model.EnumerableMatch(null, (Determinant<object, QName>)null, Logics.Names.Common.A, taskStatusClass).ToArray();
                using (var writer = new StreamWriter("Ontology/taskStatusClasses.n3"))
                {
                    N3.WriteN3(statusMeta, writer);
                }
            }
        }
    }
}
