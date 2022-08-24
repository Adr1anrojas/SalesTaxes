using NUnit.Framework;
using SalesTaxes.Application.Sales.Commands;
using SalesTaxes.Domain.Enums;

namespace SalesTaxes.Application.Tests.UnitTests
{
    [TestFixture]
    internal class ItemInfoTests
    {
        #region ValidateTotal
        [Test]
        public void ShouldReturnTheCorrectTotal_ItemExemptFromGeneralAndImportTaxes()
        {
            // arrange
            decimal expectedTotal = 24.98m;

            var item = new ItemInfo()
            {
                Id = 1,
                Name = "Book",
                Price = 12.49m,
                IdCategory = (int)CategoryEnum.Book,
                Quantity = 2,
                IsImported = false
            };

            // act
            decimal actualTotal = item.GetTotal();

            // assert
            Assert.IsTrue(expectedTotal == actualTotal);
        }

        [Test]
        public void ShouldReturnTheCorrectTotal_ItemWithGeneralTaxes()
        {
            // arrange
            decimal expectedTotal = 16.49m;
            var item = new ItemInfo()
            {
                Id = 2,
                Name = "Music CD",
                Price = 14.99m,
                IdCategory = (int)CategoryEnum.General,
                Quantity = 1,
                IsImported = false
            };

            // act
            decimal actualTotal = item.GetTotal();

            // assert
            Assert.IsTrue(expectedTotal == actualTotal);
        }

        [Test]
        public void ShouldReturnTheCorrectTotal_ItemWithGeneralAndImportTaxes()
        {
            // arrange
            decimal expectedTotal = 54.65m;
            var item = new ItemInfo()
            {
                Id = 5,
                Name = "Bottle of perfume",
                Price = 47.50m,
                IdCategory = (int)CategoryEnum.General,
                Quantity = 1,
                IsImported = true
            };

            // act
            decimal actualTotal = item.GetTotal();

            // assert
            Assert.IsTrue(expectedTotal == actualTotal);
        }
        #endregion

        #region ValidateTaxes
        [Test]
        public void ShouldReturnTheCorrectSalesTaxes_ItemExemptFromGeneralAndImportTaxes()
        {
            // arrange
            decimal expectedTaxes = 0m;

            var item = new ItemInfo()
            {
                Id = 1,
                Name = "Book",
                Price = 12.49m,
                IdCategory = (int)CategoryEnum.Book,
                Quantity = 2,
                IsImported = false
            };

            // act
            decimal actualTaxes = item.GetSalesTaxes();

            // assert
            Assert.IsTrue(expectedTaxes == actualTaxes);
        }

        [Test]
        public void ShouldReturnTheCorrectSalesTaxes_ItemWithGeneralTaxes()
        {
            // arrange
            decimal expectedTaxes = 1.5m;
            var item = new ItemInfo()
            {
                Id = 2,
                Name = "Music CD",
                Price = 14.99m,
                IdCategory = (int)CategoryEnum.General,
                Quantity = 1,
                IsImported = false
            };

            // act
            decimal actualTaxes = item.GetSalesTaxes();

            // assert
            Assert.IsTrue(expectedTaxes == actualTaxes);
        }

        [Test]
        public void ShouldReturnTheCorrectSalesTaxes_ItemWithGeneralAndImportTaxes()
        {
            // arrange
            decimal expectedTaxes = 7.15m;
            var item = new ItemInfo()
            {
                Id = 5,
                Name = "Bottle of perfume",
                Price = 47.50m,
                IdCategory = (int)CategoryEnum.General,
                Quantity = 1,
                IsImported = true
            };

            // act
            decimal actualTaxes = item.GetSalesTaxes();

            // assert
            Assert.IsTrue(expectedTaxes == actualTaxes);
        }
        #endregion
    }
}
