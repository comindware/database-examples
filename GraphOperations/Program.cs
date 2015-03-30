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

namespace Comindware.Database.Examples.GraphOperations
{
    internal class Program
    {
        private static void Main()
        {
            // Database engine initializing: basic operations, N3-interpretator, inference-engine
            Logics.Initializer.Initialize();
            Logics.N3.Initializer.Initialize();
            Logics.Think.Initializer.Initialize();

            using (var model = Logics.ModelManager.CreateInMemoryModel(Logics.Names.CreateName("Example")))
            {
                var vasily = Logics.Names.CreateName("Vasily");
                var agePredicate = Logics.Names.CreateName("Age");
                var fatherPredicate = Logics.Names.CreateName("Father");
                model.AddFact(vasily, agePredicate, 20);
                using (var transaction = model.CreateModifyContext())
                {
                    model.AddFact(vasily, fatherPredicate, Logics.Names.CreateName("Ivan"));
                }

                var age = model.GetFact<int>(vasily, agePredicate);
                var father = model.GetFact(vasily, fatherPredicate);
                Console.WriteLine("Vasily age: {0}", age);
                Console.WriteLine("Vasily father: {0}", father);
            }
        }
    }
}
