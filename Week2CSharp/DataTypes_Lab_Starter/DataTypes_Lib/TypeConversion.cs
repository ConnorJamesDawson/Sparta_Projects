using System;

namespace DataTypes_Lib
{
    public class TypeConversion
    {
        public static short UIntToShort(uint num)
        {
            uint check = num;
            checked
            {
                check++;
                check--;
            }
            if (num > short.MaxValue) throw new OverflowException();

            return (short)check;
        }

        public static long FloatToLong(float num)
        {
            float check = num;
            checked
            {
                check++;
                check--;
            }

            check = (float)Math.Round(check, 0);

            return (long)check;
        }
    }
}
