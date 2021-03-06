using System;
using System.ComponentModel;
using ExamTwoCodeQuestions.Data;
using Xunit;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        [Fact]
        public void CobblerShouldImplementINotifyPropertyChanged()
        {
            var tea = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tea);
        }

        [Fact]
        public void ChangingFruitShouldInvokePropertyChangedOnFruit()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "Fruit", () =>
            {
                cob.Fruit = FruitFilling.Blueberry;
            });
            Assert.PropertyChanged(cob, "Fruit", () =>
            {
                cob.Fruit = FruitFilling.Cherry;
            });
            Assert.PropertyChanged(cob, "Fruit", () =>
            {
                cob.Fruit = FruitFilling.Peach;
            });
        }

        [Fact]
        public void ChangingFruitShouldInvokePropertyChangedOnSpecialInstructions()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "SpecialInstructions", () =>
            {
                cob.Fruit = FruitFilling.Blueberry;
            });
            Assert.PropertyChanged(cob, "SpecialInstructions", () =>
            {
                cob.Fruit = FruitFilling.Cherry;
            });
            Assert.PropertyChanged(cob, "SpecialInstructions", () =>
            {
                cob.Fruit = FruitFilling.Peach;
            });
        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedOnWithIceCream()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "WithIceCream", () =>
            {
                cob.WithIceCream = false;
            });
        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedOnSpecialInstructions()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "SpecialInstructions", () =>
            {
                cob.WithIceCream = false;
            });
        }
    }
}
