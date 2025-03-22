using Gint.Core.Changes;

namespace Gint.Core.Facts;

public class ChangeGroupFacts
{
    public class TheHasActionableFilesMethod : ChangeGroupFacts
    {
        [Fact]
        public void ReturnsTrueForAreaWhenFilesHaveActionableChangeIndicator()
        {
            // Arrange
            var sut = new ChangeGroup(
                [
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.Added),
                            new(ChangeArea.Working, ChangeIndicator.Unmodified),
                        ],
                        "foo.txt"),
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.Modified),
                            new(ChangeArea.Working, ChangeIndicator.Unmodified),
                        ],
                        "bar.txt"),
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.TypeChanged),
                            new(ChangeArea.Working, ChangeIndicator.Unmodified),
                        ],
                        "baz.txt"),
                ]);

            // Act
            var hasChanges = sut.HasActionableFiles(ChangeArea.Staging);

            // Assert
            Assert.True(hasChanges);
        }

        [Fact]
        public void ReturnsFalseForAreaWhenFilesDoNotHaveActionableChangeIndicator()
        {
            // Arrange
            var sut = new ChangeGroup(
                [
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.Added),
                            new(ChangeArea.Working, ChangeIndicator.Unmodified),
                        ],
                        "foo.txt"),
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.Unmodified),
                            new(ChangeArea.Working, ChangeIndicator.Unknown),
                        ],
                        "bar.txt"),
                    new(
                        [
                            new(ChangeArea.Staging, ChangeIndicator.Unmodified),
                            new(ChangeArea.Working, ChangeIndicator.Ignored),
                        ],
                        "baz.txt"),
                ]);

            // Act
            var hasChanges = sut.HasActionableFiles(ChangeArea.Working);

            // Assert
            Assert.False(hasChanges);
        }
    }
}
