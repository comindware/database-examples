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
using Comindware.Logics;

namespace Comindware.Database.Examples.Transactions
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            Initializer.Initialize();

            // Transactions example
            using (var model = ModelManager.CreateInMemoryModel(Names.Example))
            {
                // Adding a fact directly, without any transaction
                model.AddFact(Names.Maria, Names.Sex, Names.Female);

                // Reliable read/write using transaction that supports all the ACID properties

                // Here we commit the result
                using (var transaction = model.BeginTransaction(null, null))
                {
                    transaction.AddFact(Names.Maria, Names.Father, Names.Frans);
                    transaction.Commit();
                }

                // And here we revert it
                using (var transaction = model.BeginTransaction(null, null))
                {
                    transaction.AddFact(Names.Maria, Names.Mother, Names.Caroline);
                }

                // So we don't know who is Maria's mother...
                var mariaSex = model.GetFact(Names.Maria, Names.Sex);
                var mariaFather = model.GetFact(Names.Maria, Names.Father);
                var mariaMother = model.GetFact(Names.Maria, Names.Mother);
                Console.WriteLine("Maria's sex is: {0}", Helpers.Beautify(mariaSex));
                Console.WriteLine("Her father is: {0}", Helpers.Beautify(mariaFather));
                Console.WriteLine("Her mother is: {0}", Helpers.Beautify(mariaMother));
                Console.WriteLine();
            }
        }
    }
}
