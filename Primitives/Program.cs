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

namespace Comindware.Database.Examples.Primitives
{
    class Program
    {
        static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            Initializer.Initialize();

            // Working with Database primitives
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName))
            {
                var subject = Names.Maria;
                var stringPredicate = model.CreateName("string");
                var booleanPredicate = model.CreateName("boolean");
                var integerPredicate = model.CreateName("integer");
                var doublePredicate = model.CreateName("double");
                var durationPredicate = model.CreateName("duration");
                var dateTimePredicate = model.CreateName("date");
                var namePredicate = model.CreateName("name");
                var listPredicate = model.CreateName("list");

                // XSD data types
                // http://www.w3.org/TR/2014/REC-rdf11-concepts-20140225/#section-Datatypes

                // Writing...

                // xsd:string
                model.AddFact(subject, stringPredicate, "My string");
                // xsd:boolean
                model.AddFact(subject, booleanPredicate, true);
                // xsd:integer
                model.AddFact(subject, integerPredicate, 123);
                // xsd:decimal
                model.AddFact(subject, doublePredicate, 123.456);
                // xsd:duration
                model.AddFact(subject, durationPredicate, TimeSpan.FromDays(365));
                // xsd:dateTime
                model.AddFact(subject, dateTimePredicate, new DateTime(2010, 4, 11, 20, 20, 20, DateTimeKind.Utc));
                // xsd:QName
                model.AddFact(subject, namePredicate, model.CreateName("Test"));

                // The same could be done with direct literal creation
                model.AddFact(subject, stringPredicate, "My string".CreateLiteral());

                // Using blank nodes
                var blank = Logics.Names.Internal.BlankNode.CreateBlank();
                model.AddFact(blank, Names.Father, Names.Dirk);
                model.AddFact(blank, Names.Mother, Names.Caroline);

                // RDF Lists
                model.AddFact(subject, listPredicate, new QName[]
                    {
                        1.CreateLiteral(),
                        2.CreateLiteral()
                    }.CreateLiteral());

                // Reading...
                var stringValue = model.GetFact<string>(subject, stringPredicate);
                var booleanValue = model.GetFact<bool>(subject, booleanPredicate);
                var integerValue = model.GetFact<int>(subject, integerPredicate);
                var doubleValue = model.GetFact<double>(subject, doublePredicate);
                var durationValue = model.GetFact<TimeSpan>(subject, durationPredicate);
                var dateTimeValue = model.GetFact<DateTime>(subject, dateTimePredicate);
                var nameValue = model.GetFact(subject, namePredicate);
                var listValue = model.GetFact(subject, listPredicate).AsList();
                var blankValue1 = model.GetSubjects(Names.Father, Names.Dirk).FirstOrDefault();
                var blankValue2 = model.GetSubjects(Names.Mother, Names.Caroline).FirstOrDefault();
                Console.WriteLine("{0}'s facts:", Helpers.Beautify(subject));
                Console.WriteLine("{0}: \"{1}\"", stringPredicate, stringValue);
                Console.WriteLine("{0}: {1}", booleanPredicate, booleanValue);
                Console.WriteLine("{0}: {1}", integerPredicate, integerValue);
                Console.WriteLine("{0}: {1}", doublePredicate, doubleValue);
                Console.WriteLine("{0}: {1}", durationPredicate, durationValue);
                Console.WriteLine("{0}: {1}", dateTimePredicate, dateTimeValue);
                Console.WriteLine("{0}: {1}", namePredicate, nameValue);
                Console.WriteLine("{0}: ({1})", listPredicate, string.Join(" ", listValue.Select(x => x.GetValue<int>()).ToArray()));
                Console.WriteLine("Is blank: {0}", blankValue1.IsBlank());
                Console.WriteLine("Is blank: {0}", blankValue2.IsBlank());
                Console.WriteLine();
            }
        }
    }
}
