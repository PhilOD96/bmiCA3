using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMICalculator;
using System;

namespace BMICalculator.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class BMITest
        {
            [TestMethod]
            public void TestBMIDefaultConstructor_Works()
            {

                //Arrange
                BMI constructor = new BMI();

                int weightSt = constructor.WeightStones;
                int weightP = constructor.WeightPounds;
                int heightF = constructor.HeightFeet;
                int heightIn = constructor.HeightInches;

                //Assert
                Assert.AreEqual(weightSt, 0);
                Assert.AreEqual(weightP, 0);
                Assert.AreEqual(heightF, 0);
                Assert.AreEqual(heightIn, 0);


            }

            [TestMethod]
            public void TestBMIOverloadedConstructor_Works()
            {

                //Arrange
                BMI constructor = new BMI()
                {
                    WeightStones = 10,
                    WeightPounds = 5,
                    HeightFeet = 5,
                    HeightInches = 10
                };

                int weightSt = constructor.WeightStones;
                int weightP = constructor.WeightPounds;
                int heightF = constructor.HeightFeet;
                int heightIn = constructor.HeightInches;

                //Assert
                Assert.AreEqual(weightSt, 10);
                Assert.AreEqual(weightP, 5);
                Assert.AreEqual(heightF, 5);
                Assert.AreEqual(heightIn, 10);


            }

            [TestMethod]
            public void TestBMIValue_MethodWorks()
            {

                //Arrange
                BMI bmiTest = new BMI
                {

                    WeightStones = 10,
                    WeightPounds = 5,
                    HeightFeet = 5,
                    HeightInches = 10
                };

                double result = bmiTest.BMIValue;

                //Act
                double totWeightPounds = ((10 * 14) + 5);
                double totHeightInches = ((5 * 12) + 10);

                double totWeightKG = totWeightPounds * 0.453592;
                double totHeightMetres = totHeightInches * 0.0254;

                double bmi = totWeightKG / (Math.Pow(totHeightMetres, 2));


                //Assert
                Assert.AreEqual(result, bmi);


            }

            [TestMethod]
            public void TestBMICategory_Underweight()
            {
                //Arrange
                BMI bmiTest = new BMI
                {

                    WeightStones = 5,
                    WeightPounds = 0,
                    HeightFeet = 6,
                    HeightInches = 10
                };

                //Act
                var result = bmiTest.BMICategory;

                //Assert
                Assert.AreEqual(result, BMICategory.Underweight);
            }

            [TestMethod]
            public void TestBMICategory_Normal()
            {
                //Arrange
                BMI bmiTest = new BMI
                {

                    WeightStones = 10,
                    WeightPounds = 5,
                    HeightFeet = 5,
                    HeightInches = 10
                };

                //Act
                var result = bmiTest.BMICategory;

                //Assert
                Assert.AreEqual(result, BMICategory.Normal);
            }

            [TestMethod]
            public void TestBMICategory_Overweight()
            {
                //Arrange
                BMI bmiTest = new BMI
                {

                    WeightStones = 13,
                    WeightPounds = 5,
                    HeightFeet = 5,
                    HeightInches = 10
                };

                //Act
                var result = bmiTest.BMICategory;

                //Assert
                Assert.AreEqual(result, BMICategory.Overweight);
            }

            [TestMethod]
            public void TestBMICategory_Obese()
            {
                //Arrange
                BMI bmiTest = new BMI
                {

                    WeightStones = 19,
                    WeightPounds = 0,
                    HeightFeet = 5,
                    HeightInches = 5
                };

                //Act
                var result = bmiTest.BMICategory;

                //Assert
                Assert.AreEqual(result, BMICategory.Obese);
            }
        }
    }
}
