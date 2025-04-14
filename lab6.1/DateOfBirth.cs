namespace lab6._1
{
    internal class DateOfBirth
    {
        private int day;
        private int month;
        private int year;

        public DateOfBirth() 
        {
            day = 1;
            month = 1;
            year = 2001;
        }
        public DateOfBirth(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public DateOfBirth(DateOfBirth sofa)
        {
            this.day = sofa.day;
            this.month = sofa.month;
            this.year = sofa.year;
        }
        public int Day 
        { 
            get 
            { 
                return day;
            } 
        }
        public int Month 
        { 
            get 
            { 
                return month; 
            } 
        }
        public int Year 
        { 
            get 
            { 
                return year; 
            } 
        }
        public int MaxDigit()
        {
            int lastdigitofday = Math.Abs(day % 10);
            int lastDigitOfMonth = Math.Abs(month % 10);
            int lastDigitOfYear = Math.Abs(year % 10);

            int maxDigit = Math.Max(lastdigitofday, 
                Math.Max(lastDigitOfMonth, lastDigitOfYear));
            return maxDigit;
        }
        public override string ToString()
        {
            return $"День рождения: day: {day}, month:" +
                $" {month}, year: {year}";
        }
    }
}
