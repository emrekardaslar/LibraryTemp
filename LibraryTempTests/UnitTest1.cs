using NUnit.Framework;
using System.Collections.Generic;
using LibraryTemp;

namespace LibraryTempTests
{
    [TestFixture]
    public class TemplateUtilityTests
    {
        [SetUp]
        public void Setup()
        {
            // Any initialization code if needed.
        }

        [Test]
        public void ReplacePlaceholders_ShouldReplaceSinglePlaceholder()
        {
            // Arrange
            var template = "Hello, {{{name}}}!";
            var placeholders = new Dictionary<string, string> { { "name", "Alice" } };

            // Act
            var result = TemplateUtility.ReplacePlaceholders(template, placeholders);

            // Assert
            Assert.AreEqual("Hello, Alice!", result);
        }

        [Test]
        public void ReplacePlaceholders_ShouldHandleMultiplePlaceholders()
        {
            // Arrange
            var template = "Welcome, {{{name}}} to {{{location}}}!";
            var placeholders = new Dictionary<string, string>
            {
                { "name", "Bob" },
                { "location", "Wonderland" }
            };

            // Act
            var result = TemplateUtility.ReplacePlaceholders(template, placeholders);

            // Assert
            Assert.AreEqual("Welcome, Bob to Wonderland!", result);
        }

        [Test]
        public void ReplacePlaceholders_ShouldReturnOriginalString_IfNoPlaceholders()
        {
            // Arrange
            var template = "Hello, World!";
            var placeholders = new Dictionary<string, string>();

            // Act
            var result = TemplateUtility.ReplacePlaceholders(template, placeholders);

            // Assert
            Assert.AreEqual("Hello, World!", result);
        }

        [Test]
        public void ValidatePlaceholders_ShouldReturnTrue_ForMatchingPlaceholders()
        {
            // Arrange
            var template = "Hello, {{{name}}}! Welcome to {{{place}}}.";
            var placeholders = new Dictionary<string, string>
            {
                { "name", "John" },
                { "place", "Earth" }
            };

            // Act
            var isValid = TemplateUtility.ValidatePlaceholders(template, placeholders);

            // Assert
            Assert.IsTrue(isValid);
        }

        [Test]
        public void ValidatePlaceholders_ShouldReturnFalse_IfPlaceholdersAreMissing()
        {
            // Arrange
            var template = "Hello, {{{name}}}! Welcome to {{{place}}}.";
            var placeholders = new Dictionary<string, string>
            {
                { "name", "John" }
            };

            // Act
            var isValid = TemplateUtility.ValidatePlaceholders(template, placeholders);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
