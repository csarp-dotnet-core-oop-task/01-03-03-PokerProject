﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using PokerProjekt;

namespace PokerProjekt.Tests
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void TestPositionKonstrktor()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Prise prise = new Prise(100, 120);
                expected = "A játékos jelenlegi bevétele: 100 Ft\r\nA játékos célja 120 Ft elérése.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                prise.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Prise->Konstruktor nem tárolja el a paraméterben lévő adatokat vagy a Prise->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestPositionWinning()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
              
                expected = "A játékos jelenlegi bevétele: 105 Ft\r\nA játékos célja 120 Ft elérése.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Prise prise = new Prise(100, 120);
                prise.Winning(5);
                prise.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Prise->Winning nyerés esetén nem jól működik vagy a Prise->ToConsole nem megfelően működik.");
        }


        [TestMethod()]
        public void TestPositionWinningDeMarNyert()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {

                expected = "A játékos jelenlegi bevétele: 100 Ft\r\nA játékos célja 120 Ft elérése.\r\nA játékos elérte a játékban a 120 összeget és kiszált a játékból! Nyereménye 130 Ft.\r\nA játékos elérte a játékban a 120 összeget és kiszált a játékból! Nyereménye 130 Ft.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                Prise prise = new Prise(100, 120);
                prise.ToConsole();
                prise.Winning(30);
                prise.ToConsole();
                prise.Winning(20);
                prise.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Prise->Winning amikor már nyert és megint meghívja a függvényt nem jól működik vagy a Prise->ToConsole nem megfelően működik.");
        }


        [TestMethod()]
        public void TestPositionLosing()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {

                expected = "A játékos jelenlegi bevétele: 100 Ft\r\nA játékos célja 120 Ft elérése.\r\nA játékos jelenlegi bevétele: 95 Ft\r\nA játékos célja 120 Ft elérése.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                Prise prise = new Prise(100, 120);
                prise.ToConsole();
                prise.Losing(5);
                prise.ToConsole();

                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Prise->Lising nem jól működik vagy a Prise->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestPositionLosingDeMarVesztett()
        {
            string expected = "";
            string actual = "somthing";
            try
            {
                expected = "A játékos jelenlegi bevétele: 10 Ft\r\nA játékos célja 120 Ft elérése.\r\nA játékos vesztett! Vesztesége -10 Ft.\r\nA játékos vesztett! Vesztesége -10 Ft.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                Prise prise = new Prise(10, 120);
                prise.ToConsole();
                prise.Losing(20);
                prise.ToConsole();
                prise.Losing(5);
                prise.ToConsole();

                actual = sw.ToString();
                int index = DiffersAtIndex(expected, actual);
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Prise->Losing amikor már vesztet és mégegyszer meghívja nem jól működik vagy a Prise->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestPylayerKonstrktor()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {

                expected = "A Játékos neve: Nyerő Jani.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                Prise priseStart = new Prise(100, 120);
                Player playerWinner = new Player("Nyerő Jani", priseStart);

                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Player->Konstruktor nem tárolja el a paraméterben lévő adatokat vagy a Player->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestPylayerSumUpNextRound_Winning()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {

                expected = "A Játékos neve: Nyerő Jani.\r\nA játékos jelenlegi bevétele: 100 Ft\r\nA játékos célja 120 Ft elérése.\r\nA forduló eredménye:\r\nA játékos jelenlegi bevétele: 110 Ft\r\nA játékos célja 120 Ft elérése.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                Prise priseStart = new Prise(100, 120);
                Player playerWinner = new Player("Nyerő Jani", priseStart);
                priseStart.ToConsole();
                playerWinner.SumUpNextRound(10);

                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Player->SumUpNextRound amikor a versenyző nyer nem jól működik vagy a Player->ToConsole nem megfelően működik.");
        }

        public void TestPylayerSumUpNextRound_Losing()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {

                expected = "A Játékos neve: Nyerő Jani.\r\nA játékos jelenlegi bevétele: 100 Ft\r\nA játékos célja 120 Ft elérése.\r\nA forduló eredménye:\r\nA játékos jelenlegi bevétele: 90 Ft\r\nA játékos célja 120 Ft elérése.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);

                Prise priseStart = new Prise(100, 120);
                Player playerWinner = new Player("Nyerő Jani", priseStart);
                priseStart.ToConsole();
                playerWinner.SumUpNextRound(-10);

                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Prise osztály kivételt dob!\n" + e.Message);
            }

            Assert.AreEqual(expected, actual, "A Player->SumUpNextRound amikor a versenyző nyer nem jól működik vagy a Player->ToConsole nem megfelően működik.");
        }



        private int DiffersAtIndex(string s1, string s2)
        {
            int index = 0;
            int min = Math.Min(s1.Length, s2.Length);
            while (index < min && s1[index] == s2[index])
                index++;

            return (index == min && s1.Length == s2.Length) ? -1 : index;
        }
    }


}