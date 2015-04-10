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
    http://www.w3.org/2000/10/swap/log#includes
    http://www.w3.org/2000/10/swap/log#notIncludes
    http://www.w3.org/2000/10/swap/log#implies
    http://www.w3.org/2000/10/swap/log#supports
    http://www.w3.org/2000/10/swap/log#equals
    http://www.w3.org/2000/10/swap/log#notEquals
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
                SwapLogIncludes(model);
                SwapLogNotIncludes(model);
                SwapLogEqualTo(model);
                SwapLogNotEqualTo(model);
                SwapLogSupports(model);
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
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                <Ontology/testData.n3> log:semantics ?testData.
                <Ontology/meta.n3> log:semantics ?meta.
                (?testData ?meta) log:conjunction ?formulae.
                ?formulae log:includes { ?x a :Person. }.
            }
            =>
            {
                ?x :conjunction true.
            }
            ".ParseString());

            var result = model.GetFact<bool>(Names.Paul, Names.Example.CreateName("conjunction"));
            Console.WriteLine("Conjunction result contains the statement: {0}", result);
        }

        private static void SwapLogContent(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                <Ontology/testData.n3> log:content ?content.
            }
            =>
            {
                :content :is ?content.
            }
            ".ParseString());

            var stream = (Stream)model.GetFact<object>(Names.Example.CreateName("content"), Names.Example.CreateName("is"));
            string content;
            using (var reader = new StreamReader(stream))
            {
                content = reader.ReadToEnd();
            }

            Console.WriteLine("Loaded content: {0} symbols", content.Length);
        }

        private static void SwapLogIncludes(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                { :Paul :mother :Caroline. :Paul :father :Frans. } log:includes { :Paul :mother :Caroline. }.
            }
            =>
            {
                :result :includes true.
            }.
            ".ParseString());

            var result = model.GetFact<bool>(Names.Example.CreateName("result"), Names.Example.CreateName("includes"));
            Console.WriteLine("Document semantics includes the rule: {0}", result);
        }

        private static void SwapLogNotIncludes(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                { :Paul :mother :Rita. :Paul :father :Frans. } -> ?family.
                ?family log:notIncludes { :Boston :weather :sunny }.
            } => {:result :notIncludes true}.
            ".ParseString());

            var result = model.GetFact<bool>(Names.Example.CreateName("result"), Names.Example.CreateName("notIncludes"));
            Console.WriteLine("Document semantics does not include the rule: {0}", result);
        }

        private static void SwapLogSupports(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                {
                  :Paul :mother :Caroline.
                  :Paul :father :Frans.
                  { :Paul :mother :Caroline } => { :Paul :parent :Caroline }
                } log:supports { :Paul :mother :Caroline. }.
            }
            =>
            {
                :result :supports true.
            }.
            ".ParseString());

            // TODO: Fix the log:supports implementation
            var result = model.GetFact<bool>(Names.Example.CreateName("result"), Names.Example.CreateName("supports"));
            Console.WriteLine("Document semantics supports the rule: {0}", result);
        }

        private static void SwapLogEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            :Paul :mother :Rita.
            :Paul :father :Frans.

            {
                ?x :mother ?y.
                ?x :father ?z.
                ?y log:equalTo :Rita.
                ?z == :Frans.
            } => { ?x :equalTo true }.
            ".ParseString());

            var result = model.GetFact<bool>(Names.Paul, Names.Example.CreateName("equalTo"));
            Console.WriteLine("The subject's parents are Rita and Frans: {0}", result);
        }

        private static void SwapLogNotEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            :Paul :mother :Rita.
            :Paul :father :Frans.
            :Caroline :mother :Greta.
            :Caroline :father :Dirk.

            {
                ?x :mother ?y.
                ?x :father ?z.
                ?y log:notEqualTo :Rita.
                ?z != :Frans.
            } => { ?x :notEqualTo true }.
            ".ParseString());

            var result = model.GetFact<bool>(Names.Caroline, Names.Example.CreateName("notEqualTo"));
            Console.WriteLine("The subject's parents are not Rita and Frans: {0}", result);
        }

        private static void SwapLogSemantics(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix : <http://www.example.com/logics/example#>.

            :Paul :mother :Caroline.

            {
                <> log:semantics ?M.
                ?M log:includes { :Paul :mother :Caroline. }.
            }
            =>
            {
                :result :semantics true.
            }.
            ".ParseString());

            var result = model.GetFact<bool>(Names.Example.CreateName("result"), Names.Example.CreateName("semantics"));
            Console.WriteLine("Document semantics includes the rule: {0}", result);
        }

        private static void SwapLogUri(Model model)
        {
            model.AddStatements(@"
            @prefix log: <http://www.w3.org/2000/10/swap/log#>.
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?x log:uri ?y.
                ?y string:matches ""example""
            }
            =>
            {
                ?x :uriMatchesExample ?y.
            }.
            ".ParseString());

            // TODO: fix the log:uri implementation
            var result = model.GetFact<bool>(Names.Paul, Names.Example.CreateName("uriMatchesExample"));
            Console.WriteLine("Paul is in examples namespace: {0}", result);
        }

        private static void SwapMathDifference(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?x ?y) math:difference ?z.
            }
            =>
            {
                (?x ?y) :difference ?z.
            }
            ".ParseString());

            var difference = model.GetFact<int>(new QName[]
                {
                    11.CreateLiteral(),
                    1.CreateLiteral()
                }.CreateLiteral(), Names.Example.CreateName("difference"));
            Console.WriteLine("Difference is: {0}", difference);
        }

        private static void SwapMathEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:equalTo 2.
            }
            =>
            {
                ?x :equalTo true.
            }
            ".ParseString());

            var equalTo = model.GetFact<bool>(2.CreateLiteral(), Names.Example.CreateName("equalTo"));
            Console.WriteLine("1 equal to 2: {0}", equalTo);
        }

        private static void SwapMathGreaterThan(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:greaterThan 6.
            }
            =>
            {
                ?x :greaterThan true.
            }
            ".ParseString());

            var greaterThan = model.GetFact<bool>(7.CreateLiteral(), Names.Example.CreateName("greaterThan"));
            Console.WriteLine("7 greater than 6: {0}", greaterThan);
        }

        private static void SwapMathIntegerQuotient(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?x 2) math:integerQuotient ?z.
            }
            =>
            {
                ?x :integerQuotient ?z.
            }
            ".ParseString());

            var integerQuotient = model.GetFact<double>(5.CreateLiteral(), Names.Example.CreateName("integerQuotient"));
            Console.WriteLine("Quotient is: {0}", integerQuotient);
        }

        private static void SwapMathLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:lessThan 6.
            }
            =>
            {
                ?x :lessThan true.
            }
            ".ParseString());

            var lessThan = model.GetFact<bool>(5.CreateLiteral(), Names.Example.CreateName("lessThan"));
            Console.WriteLine("5 less than 6: {0}", lessThan);
        }

        private static void SwapMathNegation(Model model)
        {
            // We must use @in to indicate input variables for the correct rule compilation.
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix : <http://www.example.com/logics/example#>.

            @in ?x.
            {
                ?x math:negation ?y.
            }
            =>
            {
                ?x :negated ?y.
            }.
            ".ParseString());

            var negatedValue = model.GetFact<int>(1.CreateLiteral(), Names.Example.CreateName("negated"));
            Console.WriteLine("negation of 1 is: {0}", negatedValue);
        }

        private static void SwapMathNotEqualTo(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:notEqualTo 2.
            }
            =>
            {
                ?x :notEqualTo true.
            }
            ".ParseString());

            var notEqualTo = model.GetFact<bool>(1.CreateLiteral(), Names.Example.CreateName("notEqualTo"));
            Console.WriteLine("1 not equal to 2: {0}", notEqualTo);
        }

        private static void SwapMathNotGreaterThan(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:notGreaterThan 2.
            }
            =>
            {
                ?x :notGreaterThan true.
            }
            ".ParseString());

            var notGreaterThan = model.GetFact<bool>(1.CreateLiteral(), Names.Example.CreateName("notGreaterThan"));
            Console.WriteLine("1 not greater than 2: {0}", notGreaterThan);
        }

        private static void SwapMathNotLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x math:notLessThan 2.
            }
            =>
            {
                ?x :notLessThan true.
            }
            ".ParseString());

            var notLessThan = model.GetFact<bool>(5.CreateLiteral(), Names.Example.CreateName("notLessThan"));
            Console.WriteLine("5 not less than 2: {0}", notLessThan);
        }

        private static void SwapMathProduct(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?x 2) math:product ?z.
            }
            =>
            {
                ?x :product ?z.
            }
            ".ParseString());

            var product = model.GetFact<double>(5.CreateLiteral(), Names.Example.CreateName("product"));
            Console.WriteLine("Product is: {0}", product);
        }

        private static void SwapMathQuotient(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?x 2) math:quotient ?z.
            }
            =>
            {
                ?x :quotient ?z.
            }
            ".ParseString());

            var quotient = model.GetFact<double>(5.CreateLiteral(), Names.Example.CreateName("quotient"));
            Console.WriteLine("Quotient is: {0}", quotient);
        }

        private static void SwapMathRemainder(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?x 2) math:remainder ?z.
            }
            =>
            {
                ?x :remainder ?z.
            }
            ".ParseString());

            var remainder = model.GetFact<int>(5.CreateLiteral(), Names.Example.CreateName("remainder"));
            Console.WriteLine("Remainder is: {0}", remainder);
        }

        private static void SwapMathSum(Model model)
        {
            model.AddStatements(@"
            @prefix math: <http://www.w3.org/2000/10/swap/math#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                (?list (10 20)) list:append ?flatList.
                ?flatList math:sum ?y.
            }
            =>
            {
                ?list :sum ?y.
            }
            ".ParseString());

            var sum = model.GetFact<int>(new QName[]
                {
                    1.CreateLiteral(),
                    2.CreateLiteral()
                }.CreateLiteral(), Names.Example.CreateName("sum"));
            Console.WriteLine("Sum is: {0}", sum);
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
            // Use .NET regex syntax for patterns.

            // Simple example: true if Person's first name matches the pattern
            // We use @in statements to indicate that ?x and ?pattern variables are always presented while querying the fact.
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            @in ?x, ?pattern.
            {
                ?x a :Person.
                ?x :firstName ?fn.
                ?fn string:matches ?pattern.
            }
            =>
            {
                (?x ?pattern) :matchesPattern true.
            }
            ".ParseString());
            var paulMatchesPattern = model.GetFact<bool>(new[]
                {
                    Names.Paul,
                    @".aul".CreateLiteral()
                }.CreateLiteral(), Names.Example.CreateName("matchesPattern"));
            Console.WriteLine("Paul's first name matches '.aul' pattern: {0}", paulMatchesPattern);

            // Complex example: return the persons whose first name matches the pattern.
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix list: <http://www.w3.org/2000/10/swap/list#>.
            @prefix : <http://www.example.com/logics/example#>.

            @in ?list, ?pattern.
            {
                ?list list:member ?x.
                ?x a :Person.
                ?x :firstName ?fn.
                ?fn string:matches ?pattern.
            }
            =>
            {
                (?list ?pattern) :matchedPersons ?x.
            }
            ".ParseString());

            var matchedPersons = model.GetFacts(
                new QName[]
                    {
                        new[]
                            {
                                Names.Paul,
                                Names.Rita,
                                Names.Frans,
                                Names.Caroline
                            }.CreateLiteral(),
                        @"[iu]+".CreateLiteral()
                    }.CreateLiteral(),
                Names.Example.CreateName("matchedPersons"));
            Console.WriteLine("Matched persons: {0}", string.Join(", ", matchedPersons.Select(Helpers.Beautify)));
        }

        private static void SwapStringNotGreater(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?y a :Person.
                ?x :firstName ?xfn.
                ?y :firstName ?yfn.
                ?xfn string:notGreaterThan ?yfn.
            }
            =>
            {
                (?x ?y) :notGreaterThan true.
            }
            ".ParseString());

            var sorted = model.GetFact<bool>(new[]
                {
                    Names.Paul,
                    Names.Rita
                }.CreateLiteral(), Names.Example.CreateName("notGreaterThan"));
            Console.WriteLine("notGreaterThan: {0}", sorted);
        }

        private static void SwapStringNotLessThan(Model model)
        {
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x a :Person.
                ?y a :Person.
                ?x :firstName ?xfn.
                ?y :firstName ?yfn.
                ?xfn string:notLessThan ?yfn.
            }
            =>
            {
                (?x ?y) :notLessThan true.
            }
            ".ParseString());

            var notLessThan = model.GetFact<bool>(new[]
                {
                    Names.Rita,
                    Names.Paul
                }.CreateLiteral(), Names.Example.CreateName("notLessThan"));
            Console.WriteLine("notLessThan: {0}", notLessThan);
        }

        private static void SwapStringNotMatches(Model model)
        {
            // Use .NET regex syntax for patterns.

            // Simple example: true if Person's first name matches the pattern
            // We use @in statements to indicate that ?x and ?pattern variables are always presented while querying the fact.
            model.AddStatements(@"
            @prefix string: <http://www.w3.org/2000/10/swap/string#>.
            @prefix : <http://www.example.com/logics/example#>.

            @in ?x, ?pattern.
            {
                ?x a :Person.
                ?x :firstName ?fn.
                ?fn string:notMatches ?pattern.
            }
            =>
            {
                (?x ?pattern) :notMatchesPattern true.
            }
            ".ParseString());
            var paulDoesntMatchPattern = model.GetFact<bool>(new[]
                {
                    Names.Paul,
                    @"Jack".CreateLiteral()
                }.CreateLiteral(), Names.Example.CreateName("notMatchesPattern"));
            Console.WriteLine("Paul's first name doesn't match 'Jack' pattern: {0}", paulDoesntMatchPattern);
        }

        private static void SwapTimeInSeconds(Model model)
        {
            model.AddStatements(@"
            @prefix time: <http://www.w3.org/2000/10/swap/time#>.
            @prefix : <http://www.example.com/logics/example#>.

            {
                ?x time:inSeconds ?y.
            }
            =>
            {
                ?x :asSeconds ?y.
            }
            ".ParseString());

            var unixTime = model.GetFact(DateTime.SpecifyKind(new DateTime(2010, 1, 1), DateTimeKind.Utc).CreateLiteral(), Names.Example.CreateName("asSeconds"));
            var seconds = model.GetFact(TimeSpan.FromSeconds(123456).CreateLiteral(), Names.Example.CreateName("asSeconds"));

            Console.WriteLine("Unix time: {0}", unixTime);
            Console.WriteLine("Seconds: {0}", seconds);
        }
    }
}
