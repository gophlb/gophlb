using System.Collections.Generic;

namespace OrderListsOfObjects
{
    class PersonComparer : IComparer<Person>
    {
        private int FIRST_LESS_THAN_SECOND = -1;
        private int FIRST_EQUALS_SECOND = 0;
        private int FIRST_GREATER_THAN_SECOND = 1;

        public int Compare(Person first, Person second)
        {
            int comparison = FIRST_EQUALS_SECOND;

            int nameComparison = first.Name.CompareTo(second.Name);
            if (nameComparison == FIRST_LESS_THAN_SECOND)
            {
                comparison = FIRST_LESS_THAN_SECOND;
            }
            else if (nameComparison == FIRST_GREATER_THAN_SECOND)
            {
                comparison = FIRST_GREATER_THAN_SECOND;
            }
            else
            {
                int birthDateComparison = first.BirthDate.CompareTo(second.BirthDate);
                if (birthDateComparison == FIRST_LESS_THAN_SECOND)
                {
                    comparison = FIRST_LESS_THAN_SECOND;
                }
                else if (birthDateComparison == FIRST_GREATER_THAN_SECOND)
                {
                    comparison = FIRST_GREATER_THAN_SECOND;
                }
                else
                {
                    comparison = FIRST_EQUALS_SECOND;
                }
            }
            return comparison;
        }
    }
}
