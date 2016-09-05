using AutoMapper;

namespace VeiculoProtegido.Application.AutoMapper
{
	public class AutoMapperConfig
	{
		public static void RegisterMappins()
		{
			Mapper.Initialize(x =>
			{
				x.AddProfile<DomainToViewModelMappingProfile>();
				x.AddProfile<ViewModelToDomainMappingProfile>();
			});
		}
	}
}
