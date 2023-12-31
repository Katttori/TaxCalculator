﻿using Castle.Core.Logging;
using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TaxCalculator.BusinessLogic.DataTransferObjects;
using TaxCalculator.BusinessLogic.Interfaces;
using TaxCalculator.BusinessLogic.Services;
using TaxCalculator.Tests.BusinessLogic.TestData;
using TaxCalculator.Tests.BusinessLogic.TestHelpers;
using Xunit;

namespace TaxCalculator.Tests.BusinessLogic
{
    public class CalculationServiceTests
    {
        private readonly ITaxBandService _taxBandServiceMock;

        private readonly ICalculationService _sut;

        public CalculationServiceTests()
        {
            _taxBandServiceMock = A.Fake<ITaxBandService>();

            _sut = new CalculationService(_taxBandServiceMock);
        }

        [Theory]
        [ClassData(typeof(CalculationTestData))]
        public async Task CalculateTaxesAsync_WithValidData_ReturnsCalculationResult(int income, CalculationResultDto expectedResult)
        {
            //Arrange
            A.CallTo(() => _taxBandServiceMock.GetTaxBandsAsync()).Returns(TaxBandHelper.GetTaxBands());

            //Act
            var actualResult = await _sut.CalculateTaxesAsync(income);

            //Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }
    }
}
