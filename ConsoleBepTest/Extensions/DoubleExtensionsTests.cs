using NUnit.Framework;
using ConsoleBsp.Extensions;

namespace ConsoleBspTest.Extensions
{
  [TestFixture]
  public class DoubleExtensionsTests
  {
    [Test]
    public void IsZero_GivenZeroValue_ShouldReturnTrue()
    {
      // Arrange, Act & Assert.
      Assert.True((0.0).IsZero());
    }

    [Test]
    public void IsZero_GivenNegativeEpsilon_ShouldReturnFalse()
    {
      // Arrange, Act & Assert.
      Assert.False((-double.Epsilon).IsZero());
    }
    
    [Test]
    public void IsZero_GivenPositiveEpsilon_ShouldReturnFalse()
    {
      // Arrange, Act & Assert.
      Assert.False((double.Epsilon).IsZero());
    }
  }
}
