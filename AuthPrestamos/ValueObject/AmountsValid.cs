using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthPrestamos.ValueObject
{
    public class AmountsValid
    {
        public static  List<int> Amounts; 
        public static  List<int> GetAmountsValid() {
            Amounts = new List<int>() { 1000, 2000, 3000 };
            return Amounts;
        }
    }
    public enum Amounts
    {
        amount1=1000,
        amount2=2000,
        amount3=3000,
        amount4=6000
    }
}
