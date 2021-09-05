using AutoMapper;

namespace Beauty.Shared.Helpers {
    public static class AutoMaperHelper<TSource, TDestination> {
        public static TDestination GetDestination(TSource source) {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TSource, TDestination>()
                );
            var mapper = new Mapper(config);
            return mapper.Map<TDestination>(source);
        }
    }
}