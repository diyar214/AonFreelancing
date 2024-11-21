using System.Security.Claims;

namespace AonFreelancing.Utilities;

public class UtilitesMethods
{
    public static string GetTimeAgo(DateTime createdAt)
    {
        var timeSpan = DateTime.UtcNow - createdAt;
        return timeSpan.TotalMinutes switch
        {
            < 1 => "just now",
            < 60 => $"{timeSpan.Minutes} minute{(timeSpan.Minutes != 1 ? "s" : "")} ago",
            < 1440 => $"{timeSpan.Hours} hour{(timeSpan.Hours != 1 ? "s" : "")} ago",  // 1440 minutes in a day
            < 10080 => $"{timeSpan.Days} day{(timeSpan.Days != 1 ? "s" : "")} ago",    // 10080 minutes in a week
            < 43200 => $"{timeSpan.Days / 7} week{(timeSpan.Days / 7 != 1 ? "s" : "")} ago",   // 43200 minutes in a month (approx. 30 days)
            < 525600 => $"{timeSpan.Days / 30} month{(timeSpan.Days / 30 != 1 ? "s" : "")} ago", // 525600 minutes in a year
            _ => $"{timeSpan.Days / 365} year{(timeSpan.Days / 365 != 1 ? "s" : "")} ago"
        };
    }

    public static long GetUserId(ClaimsIdentity identity)
    {
        var userId = identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Convert.ToInt64(userId);
    }
}