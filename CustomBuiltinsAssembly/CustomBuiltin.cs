using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comindware.Logics;

namespace Comindware.Database.Examples.BuiltinsAssembly
{
    public class ExampleClass
    {
        [Logics.Formulae.Builtin("http://comindware.com/examples/customBuiltins#assemblyBuiltin")]
        public static bool assemblyBuiltin(QName left, out QName right)
        {
            right = (left.GetValueOrDefault<string>() + " = 42").CreateLiteral();
            return true;
        }
    }

    namespace NestedNamespace
    {
        public class RootClass
        {
            public class NestedClass
            {
                [Logics.Formulae.Builtin("http://comindware.com/examples/customBuiltins#fileBuiltin")]
                public static bool fileBuiltin(QName left, out QName right)
                {
                    right = "Registered via file:// scheme builtin state ok.".CreateLiteral();
                    return true;
                }
            }
        }
    }
}
