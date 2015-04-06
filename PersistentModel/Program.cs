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
using System.Reflection;
using Comindware.Common;
using Comindware.Logics;

namespace Comindware.Database.Examples.PersistentModel
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing storage module
            AppDomain.CurrentDomain.Load("Comindware.Storage.Core.Net");

            // Initializing required database engine modules:
            // - Basic operations
            // - N3-Interpreter
            // - Brain
            Initializer.Initialize();
            Logics.N3.Initializer.Initialize();
            Logics.Think.Initializer.Initialize();

            // Creating
            using (var model = Logics.Storage.Core.ModelManager.CreatePersistentModel("database.tdb"))
            {
                model.AddFact(Names.Maria, Names.Parent, Names.Caroline);
                model.AddFact(Names.Maria, Names.Parent, Names.Frans);
            }

            // Opening
            using (var model = Logics.Storage.Core.ModelManager.OpenPersistentModel("database.tdb"))
            {
                var parents = model.GetFacts(Names.Maria, Names.Parent);
                Console.WriteLine("Persisted Maria's parents are: {0}", string.Join(", ", parents.Select(Helpers.Beautify)));
            }
        }
    }
}
