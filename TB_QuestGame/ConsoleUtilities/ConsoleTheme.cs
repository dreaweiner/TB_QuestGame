﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to manage the console game theme
    /// </summary>
    public static class ConsoleTheme
    {
        //
        // splash screen colors
        //
        public static ConsoleColor SplashScreenBackgroundColor = ConsoleColor.DarkBlue;
        public static ConsoleColor SplashScreenForegroundColor = ConsoleColor.Green;

        //
        // main console window colors
        //
        public static ConsoleColor WindowBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor WindowForegroundColor = ConsoleColor.Blue;

        //
        // console window header colors
        //
        public static ConsoleColor HeaderBackgroundColor = ConsoleColor.DarkGreen;
        public static ConsoleColor HeaderForegroundColor = ConsoleColor.Gray;

        //
        // console window footer colors
        //
        public static ConsoleColor FooterBackgroundColor = ConsoleColor.DarkGreen;
        public static ConsoleColor FooterForegroundColor = ConsoleColor.Gray;

        //
        // menu box colors
        //
        public static ConsoleColor MenuBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MenuForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor MenuBorderColor = ConsoleColor.DarkBlue;

        //
        // message box colors
        //
        public static ConsoleColor MessageBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor MessageBoxBorderColor = ConsoleColor.DarkBlue;
        public static ConsoleColor MessageBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor MessageBoxHeaderForegroundColor = ConsoleColor.Gray;
        
        //
        // input box colors
        //
        public static ConsoleColor InputBoxBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxForegroundColor = ConsoleColor.Gray;
        public static ConsoleColor InputBoxErrorMessageForegroundColor = ConsoleColor.Red;
        public static ConsoleColor InputBoxBorderColor = ConsoleColor.DarkRed;
        public static ConsoleColor InputBoxHeaderBackgroundColor = ConsoleColor.Black;
        public static ConsoleColor InputBoxHeaderForegroundColor = ConsoleColor.Gray;
    }
}
