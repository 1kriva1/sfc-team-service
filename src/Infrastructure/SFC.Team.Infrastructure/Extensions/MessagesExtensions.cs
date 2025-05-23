using AutoMapper;

using SFC.Team.Application.Interfaces.Team.Data.Models;
using SFC.Team.Messages.Commands.Common;
using SFC.Team.Messages.Events.Team.Data;

using InviteDataValue = SFC.Invite.Messages.Models.Data.DataValue;
using InviteInitializeData = SFC.Invite.Messages.Commands.Team.Data.InitializeData;
using RequestDataValue = SFC.Request.Messages.Models.Data.DataValue;
using RequestInitializeData = SFC.Request.Messages.Commands.Team.Data.InitializeData;
using SchemeDataValue = SFC.Scheme.Messages.Models.Data.DataValue;
using SchemeInitializeData = SFC.Scheme.Messages.Commands.Team.Data.InitializeData;
using TeamDataValue = SFC.Team.Messages.Models.Data.DataValue;

namespace SFC.Team.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static InviteInitializeData BuildInitializeDataCommand(this IMapper mapper, GetInviteDataModel model)
    {
        InviteInitializeData message = new()
        {
            TeamPlayerStatuses = mapper.Map<IEnumerable<InviteDataValue>>(model.TeamPlayerStatuses)
        };

        return message;
    }

    public static RequestInitializeData BuildInitializeDataCommand(this IMapper mapper, GetRequestDataModel model)
    {
        RequestInitializeData message = new()
        {
            TeamPlayerStatuses = mapper.Map<IEnumerable<RequestDataValue>>(model.TeamPlayerStatuses)
        };

        return message;
    }

    public static SchemeInitializeData BuildInitializeDataCommand(this IMapper mapper, GetSchemeDataModel model)
    {
        SchemeInitializeData message = new()
        {
            TeamPlayerStatuses = mapper.Map<IEnumerable<SchemeDataValue>>(model.TeamPlayerStatuses)
        };

        return message;
    }

    public static DataInitialized BuildTeamDataInitializedEvent(this IMapper mapper, GetAllTeamDataModel model)
    {
        DataInitialized message = new()
        {
            TeamPlayerStatuses = mapper.Map<IEnumerable<TeamDataValue>>(model.TeamPlayerStatuses)
        };

        return message;
    }

    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}