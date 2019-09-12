using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Navigation
{
    class UnitTests
    {
        //Requires : NUnit 3 package installed
        //         : Nunit 3 Test Adaptor enabled
        [TestFixture]
        class ValidationTestCase
        {
            //Number of parameters count test cases
            [TestCase]
            public void testInputCount1()
            {
                Assert.AreSame("pass", Validator.InputParameterCount("zX(1) zY(2) rX(3) rY(4) rD(5) MOVEMENTS(6)"));
            }
            [TestCase]
            public void testInputCount2()
            {
                Assert.AreSame("number of parameters must be 6, eg: zX(1) zY(2) rX(3) rY(4) rD(5) MOVEMENTS(6)", Validator.InputParameterCount("zX(1) zY(2) rX(3) rY(4) rD(5) exrta MOVEMENTS(6)"));
            }
            [TestCase]
            public void testInputCount3()
            {
                Assert.AreNotSame("pass", Validator.InputParameterCount("first second third fourth 5 6 last"));
            }

            //positive number validation test cases
            [TestCase]
            public void testNumberCheck1()
            {
                Assert.AreNotSame("pass", Validator.NumberCheck("a"));
            }
            [TestCase]
            public void testNumberCheck2()
            {
                Assert.AreSame("zX,zY,rX,rY and rD must be a positive number", Validator.NumberCheck("letters"));
            }
            [TestCase]
            public void testNumberCheck3()
            {
                //Validator.NumberCheck("rY","-1")
                Assert.AreSame("zX,zY,rX,rY and rD must be a positive number", Validator.NumberCheck("-1"));
            }
            [TestCase]
            public void testNumberCheck4()
            {
                Assert.AreSame("pass", Validator.NumberCheck("80"));
            }

            //Rover direction input test cases
            [TestCase]
            public void testRoverDirection1()
            {
                Assert.AreNotSame("pass", Validator.RoverDirectionCheck("5"));
            }
            [TestCase]
            public void testRoverDirection2()
            {
                Assert.AreSame("RD(Rover Direction) can only be N,E,S or W", Validator.RoverDirectionCheck("Z"));
            }
            [TestCase]
            public void testRoverDirection3()
            {
                Assert.AreSame("RD(Rover Direction) can only be N,E,S or W", Validator.RoverDirectionCheck("ES"));
            }
            [TestCase]
            public void testRoverDirection4()
            {
                Assert.AreSame("pass", Validator.RoverDirectionCheck("E"));
            }

            //Rover Movement Input Test Cases
            [TestCase]
            public void testRoverMovementInput1()
            {
                Assert.AreSame("Movements can only contain M,R or L", Validator.RoverMovementsCheck("5MMMjRLL1"));
            }
            [TestCase]
            public void testRoverMovementInpu2()
            {
                Assert.AreSame("Movements can only contain M,R or L", Validator.RoverMovementsCheck("MMLLRYYZ"));
            }
            [TestCase]
            public void testRoverMovementInput3()
            {
                Assert.AreNotSame("pass", Validator.RoverMovementsCheck("54321M"));
            }
            [TestCase]
            public void testRoverMovementInput4()
            {
                Assert.AreSame("pass", Validator.RoverMovementsCheck("MMMMLMMRMMM"));
            }

            //Rover start Coordinate Test Cases
            [TestCase]
            public void testRoverStartCoordinateCheck1()
            {
                Assert.AreNotSame("pass", Validator.RoverStartCoordinateCheck(2, 2, 3, 3));
            }
            [TestCase]
            public void testRoverStartCoordinateCheck2()
            {
                Assert.AreSame("pass", Validator.RoverStartCoordinateCheck(5, 8, 2, 5));
            }

            //test Overall Navigation input
            [TestCase]
            public void testOverallInput1()
            {
                Assert.AreNotSame("pass", Validator.UserInputComand("2 3 5 3 E MMRL"));
            }
            [TestCase]
            public void testOverallInput2()
            {
                Assert.AreNotSame("pass", Validator.UserInputComand("1 6 5 f 6 MHDS"));
            }
            [TestCase]
            public void testOverallInput3()
            {
                Assert.AreSame("pass", Validator.UserInputComand("8 8 2 2 E MMMMMRMMMLMM"));
            }

        }
        [TestFixture]
        class InputToMainIntergration
        {
        }
    }
}