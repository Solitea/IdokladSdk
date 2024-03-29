﻿using IdokladSdk.Requests.Core.Modifiers.Page;
using NUnit.Framework;

namespace IdokladSdk.UnitTests.Tests.Modifiers.Page
{
    [TestFixture]
    public class PageModifierTests
    {
        [Test]
        public void PageModifier_Page_DefaultValue_ReturnsDefaultQueryParam()
        {
            // Arrange
            var modifier = new PageModifier();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.TryGetValue("page", out var page), Is.True);
            Assert.That(page, Is.EqualTo($"{Constants.DefaultPage}"));
        }

        [Test]
        public void PageModifier_PageSize_DefaultValue_ReturnsDefaultQueryParam()
        {
            // Arrange
            var modifier = new PageModifier();

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.TryGetValue("pageSize", out var pageSize), Is.True);
            Assert.That(pageSize, Is.EqualTo($"{Constants.DefaultPageSize}"));
        }

        [Test]
        public void PageModifier_PageSize_CustomValue_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new PageModifier();
            var customPageSize = 24;
            modifier.PageSize = customPageSize;

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.TryGetValue("pageSize", out var pageSize), Is.True);
            Assert.That(pageSize, Is.EqualTo($"{customPageSize}"));
        }

        [Test]
        public void PageModifier_Page_CustomValue_ReturnsCorrectQueryParam()
        {
            // Arrange
            var modifier = new PageModifier();
            var customPage = 3;
            modifier.Page = customPage;

            // Act
            var queryParams = modifier.GetQueryParameters();

            // Assert
            Assert.That(queryParams.TryGetValue("page", out var page), Is.True);
            Assert.That(page, Is.EqualTo($"{customPage}"));
        }
    }
}
