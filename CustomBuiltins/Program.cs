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
using Comindware.Common;
using Comindware.Logics;
using Comindware.Logics.Think;
using Comindware.Logics.NTriples;

namespace Comindware.Database.Examples.CustomBuiltins
{
    internal class Program
    {
        private static void Main()
        {
            // Initializing required database engine modules:
            // - Basic operations
            // - N3-Interpreter
            // - Brain
            Logics.Initializer.Initialize();
            Logics.N3.Initializer.Initialize();
            Logics.Think.Initializer.Initialize();

            //Registering Local Builtins via function call
            RegisterBuiltinInCode();
            AverageBuiltin();
            IsGreaterThanBuiltin();

            //Register Builtin from loaded assembly,
            RegisterBuiltinViaAssemblySheme();
            
            //Register Builtin From File
            RegisterBuiltinViaFileSheme();
        }

        private static void RegisterBuiltinInCode()
        {
            Comindware.Logics.Formulae.Globals.RegisterBuiltins(typeof(LocalCodeBuiltins));
        }

        private static void RegisterBuiltinViaFileSheme()
        {
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                string filepath = System.IO.Directory.GetCurrentDirectory() + "\\CustomBuiltinsAssembly.dll";
                model.AddStatements(@"
                    @prefix : <http://www.example.com/logics/example#>.
                    @prefix custom: <http://comindware.com/examples/customBuiltins#>.

                    @extension custom:fileBuiltin <{{{filepath}}}#Comindware.Database.Examples.BuiltinsAssembly.NestedNamespace.RootClass+NestedClass.fileBuiltin>.

                    {
                        ""example"" custom:fileBuiltin ?fileBuiltinResult.
                    }
                    =>
                    {
                        :fileBuiltinResult :is ?fileBuiltinResult.
                    }.
                ".Replace("{{{filepath}}}", filepath).ParseString());

                var result = model.GetFact<string>(Names.Example.CreateName("fileBuiltinResult"), Names.Example.CreateName("is"));
                Console.WriteLine("Registered via File Builtin Result: {0}", result);
            }
        }

        private static void RegisterBuiltinViaAssemblySheme()
        {
            // load assembly before use it by assembly:// scheme
            string file = System.IO.Directory.GetCurrentDirectory() + "\\CustomBuiltinsAssembly.dll";
            System.Reflection.Assembly.LoadFrom(file);

            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(@"
                    @prefix : <http://www.example.com/logics/example#>.
                    @prefix custom: <http://comindware.com/examples/customBuiltins#>.

                    @extension custom:assemblyBuiltin <assembly://CustomBuiltinsAssembly#Comindware.Database.Examples.BuiltinsAssembly.ExampleClass.assemblyBuiltin>.

                    {
                        ""what is the answer to life the universe and everything"" custom:assemblyBuiltin ?assemblyBuiltinResult.
                    }
                    =>
                    {
                        :assemblyBuiltinResult :is ?assemblyBuiltinResult.
                    }.
                ".ParseString());

                var result = model.GetFact<string>(Names.Example.CreateName("assemblyBuiltinResult"), Names.Example.CreateName("is"));
                Console.WriteLine("Registered via Assembly Builtin Result: {0}", result);
            }
        }

        private static void AverageBuiltin()
        {
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(@"
                    @prefix : <http://www.example.com/logics/example#>.
                    @prefix custom: <http://comindware.com/examples/customBuiltins#>.

                    (1 3 2 4 0) :is :testset.
                    {
                        ?x :is :testset.
                        ?x custom:Average ?y
                    }
                    =>
                    {
                        :averageBuiltinResult :is ?y.
                    }.
                ".ParseString());
                var average = model.GetFact<decimal>(Names.Example.CreateName("averageBuiltinResult"), Names.Example.CreateName("is"));
                Console.WriteLine("Custom Average: {0}", average);
            }
        }

        private static void IsGreaterThanBuiltin()
        {
            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                model.AddStatements(@"
                    @prefix : <http://www.example.com/logics/example#>.
                    @prefix custom: <http://comindware.com/examples/customBuiltins#>.

                    :set1 :member 1.
                    :set1 :member 10.

                    :set2 :member 3.
                    :set2 :member 5.
                    :set2 :member 15.

                    {
                        :set1 :member ?x.
                        :set2 :member ?y.
                        ?x custom:isGreaterThan ?y
                    }
                    =>
                    {
                        ?x :customIsGreaterThanBuiltinResult ?y.
                    }.
                ".ParseString());
                foreach (var stm in model.GetStatementsForPredicate(Names.Example.CreateName("customIsGreaterThanBuiltinResult")))
                    Console.WriteLine("Custom isGreaterThan: {0} greaterThan {1}", stm.Subject.GetValueOrDefault<decimal>(), stm.Object.GetValueOrDefault<decimal>());
            }
        }
    }
}