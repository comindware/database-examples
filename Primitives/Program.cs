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
            using (var model = ModelManager.CreateInMemoryModel(Names.Example))
            {
                var subject = Names.Maria;
                var stringProperty = Names.Example.CreateName("string");
                var booleanProperty = Names.Example.CreateName("boolean");
                var integerProperty = Names.Example.CreateName("integer");
                var doubleProperty = Names.Example.CreateName("double");
                var durationProperty = Names.Example.CreateName("duration");
                var dateTimeProperty = Names.Example.CreateName("date");
                var nameProperty = Names.Example.CreateName("name");
                var listProperty = Names.Example.CreateName("list");

                // XSD data types
                // http://www.w3.org/TR/2014/REC-rdf11-concepts-20140225/#section-Datatypes

                // Writing...

                // xsd:string
                model.AddFact(subject, stringProperty, "My string");
                // xsd:boolean
                model.AddFact(subject, booleanProperty, true);
                // xsd:integer
                model.AddFact(subject, integerProperty, 123);
                // xsd:decimal
                model.AddFact(subject, doubleProperty, 123.456);
                // xsd:duration
                model.AddFact(subject, durationProperty, TimeSpan.FromDays(365));
                // xsd:dateTime
                model.AddFact(subject, dateTimeProperty, new DateTime(2010, 4, 11, 20, 20, 20, DateTimeKind.Utc));
                // xsd:QName
                model.AddFact(subject, nameProperty, Names.Example.CreateName("Test"));

                // The same could be done with direct literal creation
                model.AddFact(subject, stringProperty, "My string".CreateLiteral());

                // Using blank nodes
                var blank = Logics.Names.Internal.BlankNode.CreateBlank();
                model.AddFact(blank, Names.Father, Names.Dirk);
                model.AddFact(blank, Names.Mother, Names.Caroline);

                // RDF Lists
                model.AddFact(subject, listProperty, new QName[]
                    {
                        1.CreateLiteral(),
                        2.CreateLiteral()
                    }.CreateLiteral());

                // Reading...
                var stringValue = model.GetFact<string>(subject, stringProperty);
                var booleanValue = model.GetFact<bool>(subject, booleanProperty);
                var integerValue = model.GetFact<int>(subject, integerProperty);
                var doubleValue = model.GetFact<double>(subject, doubleProperty);
                var durationValue = model.GetFact<TimeSpan>(subject, durationProperty);
                var dateTimeValue = model.GetFact<DateTime>(subject, dateTimeProperty);
                var nameValue = model.GetFact(subject, nameProperty);
                var listValue = model.GetFact(subject, listProperty).AsList();
                var blankValue1 = model.GetSubjects(Names.Father, Names.Dirk).FirstOrDefault();
                var blankValue2 = model.GetSubjects(Names.Mother, Names.Caroline).FirstOrDefault();
                Console.WriteLine("{0}'s facts:", Helpers.Beautify(subject));
                Console.WriteLine("{0}: \"{1}\"", stringProperty, stringValue);
                Console.WriteLine("{0}: {1}", booleanProperty, booleanValue);
                Console.WriteLine("{0}: {1}", integerProperty, integerValue);
                Console.WriteLine("{0}: {1}", doubleProperty, doubleValue);
                Console.WriteLine("{0}: {1}", durationProperty, durationValue);
                Console.WriteLine("{0}: {1}", dateTimeProperty, dateTimeValue);
                Console.WriteLine("{0}: {1}", nameProperty, nameValue);
                Console.WriteLine("{0}: ({1})", listProperty, string.Join(" ", listValue.Select(x => x.GetValue<int>()).ToArray()));
                Console.WriteLine("Is blank: {0}", blankValue1.IsBlank());
                Console.WriteLine("Is blank: {0}", blankValue2.IsBlank());
                Console.WriteLine();
            }
        }
    }
}
