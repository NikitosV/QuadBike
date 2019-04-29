using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Common.Filters.BikeFilter
{
    public enum SortState
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,  // по имени по убыванию

        MaxSpeedAsc,
        MaxSpeedDesc,

        TypeEngineAsc,
        TypeEngineDesc,

        PowerAsc,
        PowerDesc,

        FuelAsc,
        FuelDesc,

        PriceAsc,
        PriceDesc
    }

    public class BikeSortViewModel
    {
        public SortState NameSort { get; private set; } // значение для сортировки по имени
        public SortState MaxSpeedSort { get; private set; }
        public SortState TypeEngineSort { get; private set; }
        public SortState PowerSort { get; private set; }
        public SortState FuelSort { get; private set; }
        public SortState PriceSort { get; private set; }
        public SortState Current { get; private set; }     // текущее значение сортировки

        public BikeSortViewModel(SortState sortOrder)
        {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            MaxSpeedSort = sortOrder == SortState.MaxSpeedAsc ? SortState.MaxSpeedDesc : SortState.MaxSpeedAsc;
            TypeEngineSort = sortOrder == SortState.TypeEngineAsc ? SortState.TypeEngineDesc : SortState.TypeEngineAsc;
            PowerSort = sortOrder == SortState.PowerAsc ? SortState.PowerDesc : SortState.PowerAsc;
            FuelSort = sortOrder == SortState.FuelAsc ? SortState.FuelDesc : SortState.FuelAsc;
            PriceSort = sortOrder == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current = sortOrder;
        }
    }
}
