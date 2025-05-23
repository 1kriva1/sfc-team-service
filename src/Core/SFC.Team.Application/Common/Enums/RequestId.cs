namespace SFC.Team.Application.Common.Enums;
public enum RequestId
{
    // main
    DatabaseReset,
    // data
    InitData,
    ResetData,
    // identity
    CreateUser,
    CreateUsers,
    // player
    CreatePlayer,
    UpdatePlayer,
    CreatePlayers,
    // invite
    ResetInviteData,
    // request
    ResetRequestData,
    // team player
    CreateTeamPlayer,
    UpdateTeamPlayer,
    GetTeamPlayer,
    GetTeamPlayers,
    // team player invite
    CreateTeamPlayerInvite,
    UpdateTeamPlayerInvite,
    GetTeamPlayerInvite,
    GetTeamPlayerInvites,
    // team player request
    CreateTeamPlayerRequest,
    UpdateTeamPlayerRequest,
    GetTeamPlayerRequest,
    GetTeamPlayerRequests,
    // team
    GetAllTeamData,
    CreateTeam,
    UpdateTeam,
    GetTeam,
    GetTeams
}