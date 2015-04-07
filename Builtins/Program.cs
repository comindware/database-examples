// ***********************************************************************
// <author>Stepan Burguchev</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2015. All rights reserved.
// </copyright>
// <summary>
//   Program.cs
// </summary>
// ***********************************************************************


/* 
 * Full list of predefined builtins:
 * 
    <Logics.Brain>
    http://www.w3.org/2000/10/swap/log#conclusion
    http://comindware.com/logics/axis#select
    <Logics.Console>
    http://comindware.com/logics/console#camelCase
    http://comindware.com/logics/console#compareNames
    http://comindware.com/logics/console#formulaToLists
    http://comindware.com/logics/console#isInDomain
    http://comindware.com/logics/console#isVar
    http://comindware.com/logics/console#localName
    http://comindware.com/logics/console#nameType
    http://comindware.com/logics/console#parentName
    http://comindware.com/logics/console#print
    http://comindware.com/logics/console#printfile
    http://comindware.com/logics/environment#currentDir
    http://comindware.com/logics/environment#listVariables
    http://comindware.com/logics/environment#Variable
    <Logics.Formulae>
    http://comindware.com/logics#isBlank
    http://comindware.com/logics#isBooleanLiteral
    http://comindware.com/logics#isDateLiteral
    http://comindware.com/logics#isDateTimeLiteral
    http://comindware.com/logics#isDurationLiteral
    http://comindware.com/logics#isList
    http://comindware.com/logics#isLiteral
    http://comindware.com/logics#isNotBlank
    http://comindware.com/logics#isNotLiteral
    http://comindware.com/logics#isNotVariable
    http://comindware.com/logics#isNumericLiteral
    http://comindware.com/logics#isStringLiteral
    http://comindware.com/logics#isVariable
    http://comindware.com/logics/string#fromBase64
    http://comindware.com/logics/string#fromUri
    http://comindware.com/logics/string#split
    http://comindware.com/logics/string#textformat
    http://comindware.com/logics/string#toBase64
    http://comindware.com/logics/string#toUri
    <Logics.N3>
    http://comindware.com/logics#isInDomain
    http://comindware.com/logics#isOfType
    http://comindware.com/logics#isOfType
    http://comindware.com/logics#value
    http://comindware.com/logics/list#at
    http://comindware.com/logics/list#length
    http://comindware.com/logics/math#average
    http://comindware.com/logics/math#difference
    http://comindware.com/logics/math#max
    http://comindware.com/logics/math#min
    http://comindware.com/logics/math#sum
    http://comindware.com/logics/time#addDuration
    http://comindware.com/logics/time#endOfDay
    http://comindware.com/logics/time#getSpan
    http://comindware.com/logics/time#startOfDay
    http://comindware.com/logics/time#startOfMonth
    http://comindware.com/logics/time#startOfWeek
    http://comindware.com/logics/time#subDuration
    http://comindware.com/logics/time#timeZoneHours
    http://comindware.com/logics/time#toDuration
    http://www.w3.org/1999/02/22-rdf-syntax-ns#first
    http://www.w3.org/1999/02/22-rdf-syntax-ns#last
    http://www.w3.org/1999/02/22-rdf-syntax-ns#rest
    http://www.w3.org/2000/10/swap/list#append
    http://www.w3.org/2000/10/swap/list#last
    http://www.w3.org/2000/10/swap/list#member
    http://www.w3.org/2000/10/swap/log#conjunction
    http://www.w3.org/2000/10/swap/log#content
    http://www.w3.org/2000/10/swap/log#semantics
    http://www.w3.org/2000/10/swap/log#uri
    http://www.w3.org/2000/10/swap/math#difference
    http://www.w3.org/2000/10/swap/math#equalTo
    http://www.w3.org/2000/10/swap/math#greaterThan
    http://www.w3.org/2000/10/swap/math#integerQuotient
    http://www.w3.org/2000/10/swap/math#lessThan
    http://www.w3.org/2000/10/swap/math#negation
    http://www.w3.org/2000/10/swap/math#notEqualTo
    http://www.w3.org/2000/10/swap/math#notGreaterThan
    http://www.w3.org/2000/10/swap/math#notLessThan
    http://www.w3.org/2000/10/swap/math#product
    http://www.w3.org/2000/10/swap/math#quotient
    http://www.w3.org/2000/10/swap/math#remainder
    http://www.w3.org/2000/10/swap/math#sum
    http://www.w3.org/2000/10/swap/string#concatenation
    http://www.w3.org/2000/10/swap/string#format
    http://www.w3.org/2000/10/swap/string#greaterThan
    http://www.w3.org/2000/10/swap/string#lessThan
    http://www.w3.org/2000/10/swap/string#matches
    http://www.w3.org/2000/10/swap/string#notGreaterThan
    http://www.w3.org/2000/10/swap/string#notLessThan
    http://www.w3.org/2000/10/swap/string#notMatches
    http://www.w3.org/2000/10/swap/time#inSeconds
 * 
 * The description of SWAP builtins is located here: http://www.w3.org/2000/10/swap/doc/CwmBuiltins
 * 
 */

using System;
using System.IO;
using System.Linq;
using Comindware.Common;
using Comindware.Logics;
using Comindware.Logics.NTriples;
using Comindware.Logics.Think;
using Initializer = Comindware.Logics.Initializer;
using Model = Comindware.Logics.Think.Model;

namespace Comindware.Database.Examples.Builtins
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
                using (var reader = new StreamReader("Ontology/testData.n3"))
                {
                    model.AddStatements(reader.Parse());
                }

                SwapListAppend(model);
                SwapListLast(model);
                SwapListMember(model);
                SwapLogConjunction(model);
                SwapLogContent(model);
                SwapLogSemantics(model);
                SwapLogUri(model);
                SwapMathDifference(model);
                SwapMathEqualTo(model);
                SwapMathGreaterThan(model);
                SwapMathIntegerQuotient(model);
                SwapMathLessThan(model);
                SwapMathNegation(model);
                SwapMathNotEqualTo(model);
                SwapMathNotGreaterThan(model);
                SwapMathNotLessThan(model);
                SwapMathProduct(model);
                SwapMathQuotient(model);
                SwapMathRemainder(model);
                SwapMathSum(model);
                SwapStringConcatenation(model);
                SwapStringFormat(model);
                SwapStringGreaterThan(model);
                SwapStringLessThan(model);
                SwapStringMatches(model);
                SwapStringNotGreater(model);
                SwapStringNotLessThan(model);
                SwapStringNotMatches(model);
                SwapTimeInSeconds(model);
            }
        }

        private static void SwapListAppend(Model model)
        {
            // Append as result
            model.AddStatements(@"
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x :mother :Rita.
                ( (:Frans :Caroline) (?x :Rita) ) list:append ?family.
            }
            =>
            {
                ?x :myFamily ?family
            }
            ".ParseString());

            var family = model.GetFact(Names.Paul, Names.Example.CreateName("myFamily")).AsList();
            Console.WriteLine("Found family: {0}", string.Join(", ", family.Select(Helpers.Beautify).ToArray()));

            // Append as condition
            model.AddStatements(@"
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x :mother :Rita.
                :Rita :mother ?z.
                ( (?x :Rita) (:Frans ?z) ) list:append (?x :Rita :Frans ?z).
            }
            =>
            {
                ?x :inRelationWith ?z
            }
            ".ParseString());

            var caroline = model.GetFact(Names.Paul, Names.Example.CreateName("inRelationWith"));
            Console.WriteLine("Found person: {0}", Helpers.Beautify(caroline));
        }

        private static void SwapListLast(Model model)
        {
            model.AddStatements(@"
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ( :Frans :Caroline :Rita ) list:last ?z.
            }
            =>
            {
                :Frans :lastMember ?z.
            }
            ".ParseString());

            var rita = model.GetFact(Names.Frans, Names.Example.CreateName("lastMember"));
            Console.WriteLine("Found person: {0}", Helpers.Beautify(rita));
        }

        private static void SwapListMember(Model model)
        {
            model.AddStatements(@"
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ( :Frans :Caroline :Rita ) list:member ?z.
            }
            =>
            {
                ?z :isMemberOf true.
            }
            ".ParseString());

            var isMember = model.GetFact<bool>(Names.Frans, Names.Example.CreateName("isMemberOf"));
            Console.WriteLine("Is member: {0}", isMember);
        }

        private static void SwapLogConjunction(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapLogContent(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapLogSemantics(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapLogUri(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathDifference(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathGreaterThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathIntegerQuotient(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathNegation(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathNotEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathNotGreaterThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathNotLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathProduct(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathQuotient(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathRemainder(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapMathSum(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapStringConcatenation(Model model)
        {
            model.AddStatements(@"
                    @prefix string: <http://www.w3.org/2000/10/swap/string#>.
                    @prefix : <http://www.example.com/logics/example#>.

                    {
                        ?x a :Person.
                        ?x :firstName ?z.
                        (?a ?b) string:concatenation ?z
                    }
                    =>
                    {
                        (?a ?b) :concatFind ?x
                    }.

                ".ParseString());

            var paul = model.GetFact(
                new QName[] { "Pa".CreateLiteral(), "ul".CreateLiteral() }.CreateLiteral(),
                Names.Example.CreateName("concatFind"));
            Console.WriteLine("Found person: {0}", Helpers.Beautify(paul));
        }

        private static void SwapStringFormat(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?x :firstName ?fn.
                ?x :lastName ?ln.
                (""{0} {1}"" ?fn ?ln) string:format ?z
            }
            =>
            {
                ?x :fullName ?z.
            }
            ".ParseString());

            var fullName = model.GetFact<string>(Names.Paul, Names.Example.CreateName("fullName"));
            Console.WriteLine("Full name: {0}", fullName);
        }

        private static void SwapStringGreaterThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?y a :Person.
                ?x :firstName ?xfn.
                ?y :firstName ?yfn.
                ?xfn string:greaterThan ?yfn.
            }
            =>
            {
                (?x ?y) :sorted true.
            }
            ".ParseString());

            var sorted = model.GetFact<bool>(new[]
                {
                    Names.Rita,
                    Names.Paul
                }.CreateLiteral(), Names.Example.CreateName("sorted"));
            Console.WriteLine("Sorted: {0}", sorted);
        }

        private static void SwapStringLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?y a :Person.
                ?x :firstName ?xfn.
                ?y :firstName ?yfn.
                ?xfn string:lessThan ?yfn.
            }
            =>
            {
                (?x ?y) :sortedDescending true.
            }
            ".ParseString());

            var sortedDescending = model.GetFact<bool>(new[]
                {
                    Names.Paul,
                    Names.Rita
                }.CreateLiteral(), Names.Example.CreateName("sortedDescending"));
            Console.WriteLine("Sorted Descending: {0}", sortedDescending);
       }

        private static void SwapStringMatches(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapStringNotGreater(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapStringNotLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapStringNotMatches(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }

        private static void SwapTimeInSeconds(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {

            }
            =>
            {

            }
            ".ParseString());

            //var paul = model.GetFact(/*TODO*/);
            //Console.WriteLine("Found person: {0}", Helpers.Beautify(paul))
        }
    }
}
