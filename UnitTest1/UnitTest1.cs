using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TaM;

namespace TaMTests
{
    [TestClass]
    public class GameTests
    {
        Game game;
        public void MakeEmptyGame()
        {
            game = new Game();
        }
        
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasLevelCountOf0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelCount);
        }
        
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasHeight0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelHeight);
        }
        
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasWidth0()
        {
            MakeEmptyGame();
            Assert.AreEqual(0, game.LevelWidth);
        }
        
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasLevelNameOf_no_levels_loaded()
        {
            MakeEmptyGame();
            string expectedLevelName = "No levels loaded";
            string actualLevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actualLevelName);
        }
        
        [TestMethod, TestCategory("0Levels")]
        public void EmptyGameHasEmptyNamesList()
        {
            MakeEmptyGame();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(0, actualNumberOfNames);
        }
        
        void MakeGameWithOneLevel()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
        }

        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasLevelCountOf1()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(1, game.LevelCount);
        }
        
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasHeightOfLevel()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(1, game.LevelHeight);
        }
        
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasWidthOfLevel()
        {
            MakeGameWithOneLevel();
            Assert.AreEqual(3, game.LevelWidth);
        }

        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasLevelName()
        {
            MakeGameWithOneLevel();
            string expectedLevelName = "level 1";
            string actuallevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actuallevelName);
        }
        
        [TestMethod, TestCategory("1level")]
        public void GameWithOneLevelHasSingleEntryNamesList()
        {
            MakeGameWithOneLevel();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(1, actualNumberOfNames);
        }
        
        void MakeGameWithThreeLevels()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 2", 3, 1, "0000 0001 0002 1011 1010 1110");
            game.AddLevel("level 3", 3, 1, "0000 0001 0002 1011 1010 1110");
        }

        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasLevelCountOf3()
        {
            MakeGameWithThreeLevels();
            int expectedLevelCount = 3;
            int actualLevelCount = game.LevelCount;
            Assert.AreEqual(expectedLevelCount, actualLevelCount);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasHeightOfLastLevel()
        {
            MakeGameWithThreeLevels();
            Assert.AreEqual(1, game.LevelHeight);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasWidthOflastLevel()
        {
            MakeGameWithThreeLevels();
            Assert.AreEqual(3, game.LevelWidth);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasLastLevelName()
        {
            MakeGameWithThreeLevels();
            string expectedLevelName = "level 3";
            string actuallevelName = game.CurrentLevelName;
            Assert.AreSame(expectedLevelName, actuallevelName);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasThreeEntryNamesList()
        {
            MakeGameWithThreeLevels();
            int actualNumberOfNames = game.LevelNames().Count;
            Assert.AreEqual(3, actualNumberOfNames);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsHasCorrectNamesList()
        {
            MakeGameWithThreeLevels();
            List<string> actualNames = game.LevelNames();
            List<string> expectedNames = new List<string>();
            expectedNames.Add("level 1");
            expectedNames.Add("level 2");
            expectedNames.Add("level 3");
            CollectionAssert.AreEqual(expectedNames, actualNames);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsCanChangeCurrentLevel()
        {
            MakeGameWithThreeLevels();
            string expectedName = "level 2";
            game.SetLevel("level 2");
            string actualName = game.CurrentLevelName;
            Assert.AreEqual(expectedName, actualName);
        }
        
        [TestMethod, TestCategory("3levels")]
        public void GameWithThreeLevelsDoesNotChangeCurrentLevelIfNameInvalid
        ()
        {
            MakeGameWithThreeLevels();
            string expectedName = "level 3";
            game.SetLevel("level 666");
            string actualName = game.CurrentLevelName;
            Assert.AreSame(expectedName, actualName);
        }
        
        void MakeGameWithEmptySquare()
        {
            game = new Game();
            game.AddLevel("level 1", 1, 1, "0000 0000 0000 0000");
        }

        [TestMethod, TestCategory("empty_square")]
        public void EmptySquareHasNoTop()
        {
            MakeGameWithEmptySquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = false;
            bool actuallyHas = targetSquare.Top;
            Assert.AreEqual(expected, actuallyHas);
        }
        
        [TestMethod, TestCategory("empty_square")]
        public void EmptySquareHasNoRight()
        {
            MakeGameWithEmptySquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = false;
            bool actuallyHas = targetSquare.Right;
            Assert.AreEqual(expected, actuallyHas);
        }
        
        [TestMethod, TestCategory("empty_square")]
        public void EmptySquareHasNoBottom()
        {
            MakeGameWithEmptySquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = false;
            bool actuallyHas = targetSquare.Bottom;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("empty_square")]
        public void EmptySquareHasNoLeft()
        {
            MakeGameWithEmptySquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = false;
            bool actuallyHas = targetSquare.Left;
            Assert.AreEqual(expected, actuallyHas);
        }

        void MakeGameWithFullSquare()
        {
            game = new Game();
            game.AddLevel("level 1", 1, 1, "0000 0000 0000 1111");
        }

        [TestMethod, TestCategory("Full_square")]
        public void FullSquareHasTop()
        {
            MakeGameWithFullSquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Top;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("full_square")]
        public void FullSquareHasRight()
        {
            MakeGameWithFullSquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Right;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("full_square")]
        public void FullSquareHasBottom()
        {
            MakeGameWithFullSquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Bottom;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("full_square")]
        public void FullSquareHasLeft()
        {
            MakeGameWithFullSquare();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Left;
            Assert.AreEqual(expected, actuallyHas);
        }
        
        void MakeSimpleGame()
        {
            game = new Game();
            game.AddLevel("Simple", 3, 1, "0000 0001 0002 1011 1010 1110");
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasMinotaurInRightPlace()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Minotaur;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasTheseusInRightPlace()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 1);
            bool expected = true;
            bool actuallyHas = targetSquare.Theseus;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasExitInRightPlace()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 2);
            bool expected = true;
            bool actuallyHas = targetSquare.Exit;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasTopWallInSquare0000()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Top;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasLeftWallInSquare0000()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Left;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasNoRightWallInSquare0000()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = false;
            bool actuallyHas = targetSquare.Right;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasBottomWallInSquare0000()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 0);
            bool expected = true;
            bool actuallyHas = targetSquare.Bottom;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasTopWallInSquare0001()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 1);
            bool expected = true;
            bool actuallyHas = targetSquare.Top;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasNoLeftWallInSquare0001()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 1);
            bool expected = false;
            bool actuallyHas = targetSquare.Left;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasNoRightWallInSquare0001()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 1);
            bool expected = false;
            bool actuallyHas = targetSquare.Right;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasBottomWallInSquare0001()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 1);
            bool expected = true;
            bool actuallyHas = targetSquare.Bottom;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasTopWallInSquare0002()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 2);
            bool expected = true;
            bool actuallyHas = targetSquare.Top;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasNoLeftWallInSquare0002()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 2);
            bool expected = false;
            bool actuallyHas = targetSquare.Left;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasRightWallInSquare0002()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 2);
            bool expected = true;
            bool actuallyHas = targetSquare.Right;
            Assert.AreEqual(expected, actuallyHas);
        }

        [TestMethod, TestCategory("simple_game")]
        public void SimpleGameHasBottomWallInSquare0002()
        {
            MakeSimpleGame();
            Square targetSquare = game.WhatIsAt(0, 2);
            bool expected = true;
            bool actuallyHas = targetSquare.Bottom;
            Assert.AreEqual(expected, actuallyHas);
        }
        
        void MakeTheseus3By3Game()
        {
            game = new Game();
            game.AddLevel("ThesesusIn3by3", 3, 3,
            "0000 0101 0202"
            + " 1111 1001 1100"
            + " 1001 0000 0100"
            + " 0011 0010 0110");
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusExits0101To0001WhenMovingUP()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.UP);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(0, 1);
            bool[] expectedPresence = { false, true };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusExits0101To0201WhenMovingDOWN()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.DOWN);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(2, 1);
            bool[] expectedPresence = { false, true };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusExits0101To0102WhenMovingRIGHT()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.RIGHT);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(1, 2);
            bool[] expectedPresence = { false, true };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusExits0101To0102WhenMovingLEFT()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.LEFT);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(1, 0);
            bool[] expectedPresence = { false, true };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusIn0101StaysIn0101WhenPausing()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.PAUSE);
            Square destination = game.WhatIsAt(1, 1);
            bool expectedPresence = true;
            bool actualPresence = destination.Theseus;
            Assert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusMovingSuccessfullyIncrementsMoveCount()
        {
            MakeTheseus3By3Game();
            game.MoveTheseus(Moves.LEFT);
            game.MoveTheseus(Moves.DOWN);
            game.MoveTheseus(Moves.RIGHT);
            game.MoveTheseus(Moves.UP);
            game.MoveTheseus(Moves.PAUSE);
            int expectedMoveCount = 5;
            int actualMoveCount = game.MoveCount;
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }
        void MakeBlockedTheseusIn3By3()
        {
            game = new Game();
            game.AddLevel("JailedThesesusIn3by3", 3, 3,
            "0000 0101 0202"
            + " 1111 1001 1100"
            + " 1101 1111 0101"
            + " 0011 1010 0110");
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void BlockedTheseusStaysAt0101WhenMovingUP()
        {
            MakeBlockedTheseusIn3By3();
            game.MoveTheseus(Moves.UP);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(0, 1);
            bool[] expectedPresence = { true, false };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void BlockedTheseusStaysAt0101WhenMovingDOWN()
        {
            MakeBlockedTheseusIn3By3();
            game.MoveTheseus(Moves.DOWN);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(2, 1);
            bool[] expectedPresence = { true, false };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void BlockedTheseusStaysAt0101MovingRIGHT()
        {
            MakeBlockedTheseusIn3By3();
            game.MoveTheseus(Moves.RIGHT);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(1, 2);
            bool[] expectedPresence = { true, false };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void BlockedTheseusStaysAt0101MovingLEFT()
        {
            MakeBlockedTheseusIn3By3();
            game.MoveTheseus(Moves.LEFT);
            Square origin = game.WhatIsAt(1, 1);
            Square destination = game.WhatIsAt(1, 0);
            bool[] expectedPresence = { true, false };
            bool[] actualPresence = { origin.Theseus, destination.Theseus };
            CollectionAssert.AreEqual(expectedPresence, actualPresence);
        }
        [TestMethod, TestCategory("TheseusMoving")]
        public void TheseusMovingUnuccessfullyLeavesMovesCountUnaltered()
        {
            MakeBlockedTheseusIn3By3();
            game.MoveTheseus(Moves.LEFT);
            game.MoveTheseus(Moves.DOWN);
            game.MoveTheseus(Moves.RIGHT);
            game.MoveTheseus(Moves.UP);
            int expectedMoveCount = 0;
            int actualMoveCount = game.MoveCount;
            Assert.AreEqual(expectedMoveCount, actualMoveCount);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesUPWhenTheseusIsDirectlyAbove()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTwoAboveIn7by7", 7, 7,
                "0303 0003 0001"
                + " 1001 1000 1000 1000 1000 1000 1100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,
            expectedMinotaurAtDestination };
            bool actualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(1, 3).Minotaur;
            bool[] actual = { actualMinotaurAtOrigin,
            actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesDOWNWhenTheseusIsDirectlyBelow()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTwoBelowIn7by7", 7, 7,
            "0303 0603 0001"
                + " 1001 1000 1000 1000 1000 1000 1100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0001 0000 0000 0000 0000 0000 0100"
                + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool acutualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(5, 3).Minotaur;
            bool[] actual = { acutualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesRIGHTWhenTheseusIsDirectlyRIGHT()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTwoRightIn7by7", 7, 7,
            "0303 0306 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool actualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 5).Minotaur;
            bool[] actual = { actualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesLEFTWhenTheseusIsDirectlyLEFT()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTwoLEFTIn7by7", 7, 7,
            "0303 0300 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,
expectedMinotaurAtDestination };
            bool actualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 1).Minotaur;
            bool[] actual = { actualMinotaurAtOrigin,
actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesRIGHTWhenTheseusIsRIGHTAndUP()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTopRightIn7by7", 7, 7,
            "0303 0006 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool actualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 5).Minotaur;
            bool[] actual = { actualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesLEFTWhenTheseusIsLEFTAndUP()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusTopLeftIn7by7", 7, 7,
            "0303 0000 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool acutualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 1).Minotaur;
            bool[] actual = { acutualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesLEFTWhenTheseusIsLEFTAndDOWN()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusBottomLeftIn7by7", 7, 7,
            "0303 0600 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool acutualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 1).Minotaur;
            bool[] actual = { acutualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("MinotaurMoving")]
        public void MinotaurMovesRIGHTWhenTheseusIsRIGHTAndDOWN()
        {
            game = new Game();
            game.AddLevel("CentredMinotaurWithThesesusBottomLeftIn7by7", 7, 7,
            "0303 0606 0001"
            + " 1001 1000 1000 1000 1000 1000 1100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0001 0000 0000 0000 0000 0000 0100"
            + " 0011 0010 0010 0010 0010 0010 0110");
            game.MoveMinotaur();
            game.MoveMinotaur();
            bool expectedMinotaurAtOrigin = false;
            bool expectedMinotaurAtDestination = true;
            bool[] expected = { expectedMinotaurAtOrigin,expectedMinotaurAtDestination };
            bool acutualMinotaurAtOrigin = game.WhatIsAt(3, 3).Minotaur;
            bool actualMinotaurAtDestination = game.WhatIsAt(3, 5).Minotaur;
            bool[] actual = { acutualMinotaurAtOrigin,actualMinotaurAtDestination };
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod, TestCategory("Winning")]
        public void MinotaurWinsIfOnTheseus()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0000 0002 1011 1010 1110");
            bool expectedWin = true;
            bool actualWin = game.HasMinotaurWon;
            Assert.AreEqual(expectedWin, actualWin);
        }
        [TestMethod, TestCategory("Winning")]
        public void MinotaurNotWonIfNotOnTheseus()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
            bool expectedWin = false;
            bool actualWin = game.HasMinotaurWon;
            Assert.AreEqual(expectedWin, actualWin);
        }
        [TestMethod, TestCategory("Winning")]
        public void TheseusWinsIfOnExit()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0002 0002 1011 1010 1110");
            bool expectedWin = true;
            bool actualWin = game.HasTheseusWon;
            Assert.AreEqual(expectedWin, actualWin);
        }
        [TestMethod, TestCategory("Winning")]
        public void TheseusNotWonIfNotOnExit()
        {
            game = new Game();
            game.AddLevel("level 1", 3, 1, "0000 0001 0002 1011 1010 1110");
            bool expectedWin = false;
            bool actualWin = game.HasTheseusWon;
            Assert.AreEqual(expectedWin, actualWin);
        } 
    }
}
