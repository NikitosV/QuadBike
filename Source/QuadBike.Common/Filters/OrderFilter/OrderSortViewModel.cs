using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.OrderFilter
{
    public enum SortStateTwo
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,  // по имени по убыванию

        DateAsc,
        DateDesc,
    }

    public class OrderSortViewModel
    {
        public SortStateTwo NameSort { get; private set; } // значение для сортировки по имени
        public SortStateTwo DateSort { get; private set; }
        public SortStateTwo Current { get; private set; }

        public OrderSortViewModel(SortStateTwo sortOrderTwo)
        {
            NameSort = sortOrderTwo == SortStateTwo.NameAsc ? SortStateTwo.NameDesc : SortStateTwo.NameAsc;
            DateSort = sortOrderTwo == SortStateTwo.DateAsc ? SortStateTwo.DateDesc : SortStateTwo.DateAsc;
            Current = sortOrderTwo;
        }
    }
}
