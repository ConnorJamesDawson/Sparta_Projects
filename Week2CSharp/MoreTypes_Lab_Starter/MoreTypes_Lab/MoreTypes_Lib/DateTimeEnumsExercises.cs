using System;

namespace MoreTypes_Lib
{
    public enum Suit
    {
        HEARTS, CLUBS, DIAMONDS, SPADES
    }
    public class DateTimeEnumsExercises
    {
        // returns a person's age at a given date, given their birth date.
        public static int AgeAt(DateTime birthDate, DateTime date)
        {
            if (birthDate > date) throw new ArgumentException("Error - birthDate is in the future");

            if (birthDate.Month > date.Month) return date.Year - birthDate.Year - 1; //IF birthday month is more into year, take away a year because it hasn't happened yet 

            return date.Year - birthDate.Year;
        }
        // returns a date formatted in the manner specified by the unit test
        public static string FormatDate(DateTime date)
        {
            return String.Format("{0:yy/dd/MMM}", date);
        }

        // returns the name of the month corresponding to a given date
        public static string GetMonthString(DateTime date)
        {
            return String.Format("{0:MMMM}", date);
        }

        // see unit tests for requirements
        public static string Fortune(Suit suit)
        {
            switch(suit)
            {
                case Suit.CLUBS:
                    return "And the seventh rule is if this is your first night at fight club, you have to fight.";
                case Suit.DIAMONDS:
                    return "Diamonds are a girls best friend";
                case Suit.HEARTS:
                    return "You've broken my heart";
                case Suit.SPADES:
                    return "Bucket and spade";
                default:
                    return "Not valid suit";
            }
        }
    }
}
