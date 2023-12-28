using AutoMapper;
using Bz.F8t.Administration.Application.Competitions.Commands;
using Bz.F8t.Administration.Domain.ManagingCompetition;

namespace Bz.F8t.Administration.Application.Competitions;

internal class CompetitionMappings : Profile
{
    public CompetitionMappings()
    {
        CreateMap<Competition, CompetitionDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        CreateMap<Distance, DistanceDto>()
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit.ToString()));

        CreateMap<CompetitionPlace, CompetitionPlaceDto>()
            .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Localization.Latitude))
            .ForMember(dest => dest.Longitute, opt => opt.MapFrom(src => src.Localization.Longitude));

        CreateMap<Checkpoint, CheckpointDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.Value))
            .ForMember(dest => dest.TrackPointAmount, opt => opt.MapFrom(src => src.TrackPoint.Amount))
            .ForMember(dest => dest.TrackPointUnit, opt => opt.MapFrom(src => src.TrackPoint.Unit.ToString()));

        CreateMap<CreateCompetitionDto, CreateCompetitionCommand>()
            .ForCtorParam(nameof(CreateCompetitionCommand.StartAt), opt => opt.MapFrom(src => src.StartAt))
            .ForCtorParam(nameof(CreateCompetitionCommand.Distance), opt => opt.MapFrom(src => src.Distance))
            .ForCtorParam(nameof(CreateCompetitionCommand.Place), opt => opt.MapFrom(src => src.Place))
            .ForCtorParam(nameof(CreateCompetitionCommand.MaxCompetitors), opt => opt.MapFrom(src => src.MaxCompetitors));
    }
}
