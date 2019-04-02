using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuadBike.Logic.Mapping
{
    public class Map<T, N> where T : class where N : class
    {
        private IMapper mapper;

        public Map()
        {
            mapper = new MapperConfiguration(cfg => cfg.CreateMap<T, N>()).CreateMapper();
        }

        public List<N> ListMap(IEnumerable<T> projects)
        {
            return mapper.Map<IEnumerable<T>, List<N>>(projects);
        }

        public N ObjectMap(T project)
        {
            return mapper.Map<T, N>(project);
        }
    }
}
