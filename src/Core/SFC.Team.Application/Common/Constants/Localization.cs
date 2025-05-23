using System.Text;

using Microsoft.Extensions.Localization;

namespace SFC.Team.Application.Common.Constants;
public class Localization
{
    private static IStringLocalizer<Resources> s_localizer = default!;

    public Localization(IStringLocalizer<Resources> localizer)
    {
        s_localizer ??= localizer;
    }

    public static void Configure(IStringLocalizer<Resources> localizer)
    {
        s_localizer = localizer;
    }

    public static string SuccessResult =>
                    GetValue(s_localizer?.GetString("SuccessResult"),
                        "Success result.")!;

    public static string FailedResult =>
                       GetValue(s_localizer?.GetString("FailedResult"),
                           "Failed result.")!;

    public static string ValidationError =>
                    GetValue(s_localizer?.GetString("ValidationError"),
                        "Validation error.")!;

    public static string RequestBodyRequired =>
                        GetValue(s_localizer?.GetString("RequestBodyRequired"),
                            "Request body is required.")!;

    public static string AuthorizationError =>
                    GetValue(s_localizer?.GetString("AuthorizationError"),
                        "Authorization error.")!;

    public static string FileExtensionInvalid =>
                      GetValue(s_localizer?.GetString("FileExtensionInvalid"),
                          "Invalid file extension.")!;

    public static string MustBeUnique =>
                      GetValue(s_localizer?.GetString("MustBeUnique"),
                          "Each value from '{PropertyName}' must be unique.")!;

    public static string TagsSizeInvalid =>
                      GetValue(s_localizer?.GetString("TagsSizeInvalid"),
                          "The length of '{0}' must be less or equal to {1}.")!;

    public static string TagEmpty =>
                      GetValue(s_localizer?.GetString("TagEmpty"),
                          "Each value from '{PropertyName}' must not be empty.")!;

    public static string TagMaxLength =>
                      GetValue(s_localizer?.GetString("TagMaxLength"),
                          "Each value from '{PropertyName}' must be {MaxLength} characters or fewer. You entered {TotalLength} characters.")!;

    public static string AvailabilityUniqueness =>
                      GetValue(s_localizer?.GetString("AvailabilityUniqueness"),
                          "Each value from '{PropertyName}' must be unique.")!;

    public static string MustBeGreaterThan =>
                    GetValue(s_localizer?.GetString("MustBeGreaterThan"),
                        "'{0}' value must be greater than {1} value.")!;

    public static string MustBeLessThan =>
                     GetValue(s_localizer?.GetString("MustBeLessThan"),
                         "'{0}' value must be less than {1} value.")!;

    public static string AvailabilityDayInvalid =>
                      GetValue(s_localizer?.GetString("AvailabilityDayInvalid"),
                          "Each value from '{PropertyName}' must be in Days of Week range.")!;

    public static string DataValidator =>
                     GetValue(s_localizer?.GetString("DataValidator"),
                         "'{PropertyName}' has a range of values which does not include '{PropertyValue}'.")!;

    public static string MustBeInDataRange =>
                     GetValue(s_localizer?.GetString("MustBeInDataRange"),
                         "Each value from '{PropertyName}' must be in available data range.")!;

    public static string TeamNotFound =>
                       GetValue(s_localizer?.GetString("TeamNotFound"),
                           "Team not found.")!;

    public static string MustNotExceedSize =>
                      GetValue(s_localizer?.GetString("MustNotExceedSize"),
                          "The length of '{0}' must be less or equal to {1}.")!;

    public static string TimeOutError =>
                    GetValue(s_localizer?.GetString("TimeOutError"),
                        "The timeout to complete the request has expired.")!;

    public static string PlayerNotFound =>
                       GetValue(s_localizer?.GetString("PlayerNotFound"),
                           "Player not found.")!;

    public static string TeamPlayerInviteNotFound =>
                       GetValue(s_localizer?.GetString("TeamPlayerInviteNotFound"),
                           "Team player invite not found.")!;

    public static string TagsUniqueness =>
                      GetValue(s_localizer?.GetString("TagsUniqueness"),
                          "Each value from '{PropertyName}' must be unique.")!;

    public static string InvalidTagsSize =>
                      GetValue(s_localizer?.GetString("InvalidTagsSize"),
                          "The length of '{0}' must be less or equal to {1}.")!;

    public static string AvailableDaysSize =>
                      GetValue(s_localizer?.GetString("AvailableDaysSize"),
                          "The length of '{0}' must be less or equal to {1}.")!;

    public static string InvalidAvailableDay =>
                      GetValue(s_localizer?.GetString("InvalidAvailableDay"),
                          "Each value from '{PropertyName}' must be in Days of Week range.")!;

    public static string TeamPlayerInviteAlreadyProcessed =>
                       GetValue(s_localizer?.GetString("TeamPlayerInviteAlreadyProcessed"),
                           "Team player invite already finalized.")!;

    public static string TeamPlayerInviteActiveAlreadyExist =>
                       GetValue(s_localizer?.GetString("TeamPlayerInviteActiveAlreadyExist"),
                           "Active team player invite already exist.")!;

    public static string PlayerAlreadyInTeam =>
                       GetValue(s_localizer?.GetString("PlayerAlreadyInTeam"),
                           "Player already in team.")!;

    public static string TeamPlayerRequestActiveAlreadyExist =>
                       GetValue(s_localizer?.GetString("TeamPlayerRequestActiveAlreadyExist"),
                           "Active team player request already exist.")!;

    public static string TeamPlayerRequestNotFound =>
                       GetValue(s_localizer?.GetString("TeamPlayerRequestNotFound"),
                           "Team player request not found.")!;

    public static string TeamPlayerRequestAlreadyProcessed =>
                       GetValue(s_localizer?.GetString("TeamPlayerRequestAlreadyProcessed"),
                           "Team player request already finalized.")!;

    public static string TeamPlayerNotFound =>
                       GetValue(s_localizer?.GetString("TeamPlayerNotFound"),
                           "Team player not found.")!;

    public static string TeamPlayerAlreadyRemoved =>
                       GetValue(s_localizer?.GetString("TeamPlayerAlreadyRemoved"),
                           "Team player already removed.")!;

    public static string GetDataValue(string name)
    {
        return GetValue(s_localizer?.GetString(name), name)!;
    }

    private static string GetValue(LocalizedString? @string, string defaultValue)
    {
        return @string == null
            ? defaultValue
            : @string.ResourceNotFound
            ? defaultValue
            : @string.Value;
    }
}