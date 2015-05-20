using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Comindware.Logics;

namespace Comindware.Database.Examples.CustomBuiltins
{
    public static class LocalCodeBuiltins
    {
        [Logics.Formulae.Builtin("http://comindware.com/examples/customBuiltins#Average")]
        public static bool Average(IEnumerator<QName> left, out QName result)
        {
            decimal sum = 0;
            decimal count = 0;
            if (left.MoveNext())
            {
                count++;
                sum += left.Current.GetValueOrDefault<decimal>();
                while (left.MoveNext())
                {
                    count++;
                    sum += left.Current.GetValueOrDefault<decimal>();
                }
            }
            result = (sum / count).CreateLiteral();
            return true; //always returns true - means that execution avareage will always succeed if arguments will be list.
        }

        [Logics.Formulae.Builtin("http://comindware.com/examples/customBuiltins#isGreaterThan")]
        public static bool isGreaterThan(QName left, QName right)
        {
            return left.GetValueOrDefault<decimal>() > right.GetValueOrDefault<decimal>();
        }
    }
}
