using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Ardalis.GuardClauses;

public static class EmailGuard
{
  public static string IsValidEmail(this IGuardClause guardClause,
      string input,
      [CallerArgumentExpression("input")] string? parameterName = null)
  {
    Guard.Against.NullOrEmpty(input, parameterName);

    string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

    // Match the email address with the pattern
    if (!Regex.IsMatch(input, pattern))
    {
      throw new ArgumentException("Invalid email", parameterName);
    }

    return input;
  }
}
