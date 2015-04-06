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

namespace Comindware.Database.Examples.Unions
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

            // Unions
            using (var model1 = ModelManager.CreateInMemoryModel(Names.Example).AutoDispose())
            {
                model1.Target.AddFact(Names.Maria, Names.Parent, Names.Dirk);
                using (var model2 = ModelManager.CreateInMemoryModel(Names.SecondDatabase).AutoDispose())
                {
                    model2.Target.AddFact(Names.Maria, Names.Parent, Names.Greta);
                    using (var union = model1.Union(model2))
                    {
                        var parents = union.GetFacts(Names.Maria, Names.Parent);

                        Console.WriteLine("Maria's parents are: {0}", string.Join(", ", parents.Select(Helpers.Beautify)));
                    }
                }
            }
        }
    }
}
