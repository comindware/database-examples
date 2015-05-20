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
        //Builtin below process subject arguments and write output value to object.
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
            // always returns true - means that execution avareage will always succeed if arguments match list criteria.
            return true; 
        }

        //Builtin below doesn`t provide any output except for testing for truth if left input is greater then right input.
        [Logics.Formulae.Builtin("http://comindware.com/examples/customBuiltins#isGreaterThan")]
        public static bool isGreaterThan(QName left, QName right)
        {
            //test that left is greater then right and stop execution [return false;] if it is not thruth. 
            return left.GetValueOrDefault<decimal>() > right.GetValueOrDefault<decimal>();
        }
    }
}
