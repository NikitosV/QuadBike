using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.TripFilter
{
    public enum SortState
    {
        TripNameAsc,    // по имени по возрастанию
        TripNameDesc,  // по имени по убыванию

        TypeAsc,
        TypeDesc,

        DistanceAsc,
        DistanceDesc,

        AmountOfPeopleAsc,
        AmountOfPeopleDesc,

        StartDateAsc,
        StartDateDesc,

        PriceAsc,
        PriceDesc
    }

    public class TripSortViewModel
    {
        public SortState TripNameSort { get; private set; } // значение для сортировки по имени
        public SortState TypeSort { get; private set; }
        public SortState DistanceSort { get; private set; }
        public SortState AmountOfPeopleSort { get; private set; }
        public SortState StartDateSort { get; private set; }
        public SortState PriceSort { get; private set; }
        public SortState Current { get; private set; }     // текущее значение сортировки

        public TripSortViewModel(SortState sortOrder)
        {
            TripNameSort = sortOrder == SortState.TripNameAsc ? SortState.TripNameDesc : SortState.TripNameAsc;
            TypeSort = sortOrder == SortState.TypeAsc ? SortState.TypeDesc : SortState.TypeAsc;
            DistanceSort = sortOrder == SortState.DistanceAsc ? SortState.DistanceDesc : SortState.DistanceAsc;
            AmountOfPeopleSort = sortOrder == SortState.AmountOfPeopleAsc ? SortState.AmountOfPeopleDesc : SortState.AmountOfPeopleAsc;
            StartDateSort = sortOrder == SortState.StartDateAsc ? SortState.StartDateDesc : SortState.StartDateAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
