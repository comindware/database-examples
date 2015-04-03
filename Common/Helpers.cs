// ***********************************************************************
// <author>Stepan Burguchev</author>
// <copyright company="Comindware">
//   Copyright (c) Comindware 2010-2015. All rights reserved.
// </copyright>
// <summary>
//   Names.cs
// </summary>
// ***********************************************************************

using Comindware.Logics;

namespace Comindware.Database.Examples
{
    internal static class Helpers
    {
        public static string Beautify(QName name)
        {
            return name == null
                ? "null"
                : name.LocalName;
        }
    }
}
