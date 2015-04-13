// ***********************************************************************
// <author>Stepan Burguchev</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2015. All rights reserved.
// </copyright>
// <summary>
//   Program.cs
// </summary>
// ***********************************************************************

using Comindware.Common;
using Comindware.Logics;
using Comindware.Logics.Think;

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

            using (var model = ModelManager.CreateInMemoryModel(Names.DatabaseName).AutoDispose().Think(Names.Brain))
            {
                // TODO: There are 3 ways to register custom builtin: in .n3 - file: and assembly:, in code: register typeof(T)
                // TODO: There are several ways to specify parameters and the result (as QName or strongly typed literal, with result as the object or the fact itself)
            }
        }
    }
}
