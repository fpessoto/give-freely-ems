
using Ardalis.GuardClauses;
using Xunit;

namespace GiveFreely.EMS.UnitTests.Core.Guards;
public class EmailGuardTests
{
  [Theory]
  [InlineData("invalid")]               // Missing @ symbol
  [InlineData("missingdomain@.com")]    // Missing domain
  [InlineData("missingusername@com")]   // Missing username
  [InlineData("incomplete@.")]          // Incomplete domain
  [InlineData("incomplete@domain.")]    // Incomplete domain
  [InlineData("invalid@domain@com")]    // Multiple @ symbols
  [InlineData("invalid..username@com")] // Double dots in username
  [InlineData(".invalid@username@com")] // Dot at the beginning of username
  public void InvalidEmail_ThrowsError(string email)
  {
    // Expecting ArgumentException for invalid email
    Assert.Throws<ArgumentException>(() => Guard.Against.IsValidEmail(email));
  }

  [Theory]
  [InlineData("valid@example.com")]    // Standard valid email
  [InlineData("user.name@example.com")] // Email with dots in username
  [InlineData("user+tag@example.com")]  // Email with + symbol in username
  [InlineData("user_name@example.com")] // Email with underscores in username
  [InlineData("user-name@example.com")] // Email with hyphens in username
  [InlineData("user@sub.domain.com")]    // Email with subdomain
  public void IsValidEmailEmails_ReturnsExpectedResult(string email)
  {
    // Expecting no exception for valid email
    var result = Guard.Against.IsValidEmail(email);
    Assert.Equal(email, result);
  }
}
