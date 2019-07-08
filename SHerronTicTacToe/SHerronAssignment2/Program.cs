/*
 Written by: Sam Herron
 Date: September 29th, 2017
 Description: Allows the user to play a game of tic tac toe
 
Log:
Sept 29th: Created program, designed UI and worked on game mechanics
October 2nd: Fine tuned game mechanics and designed the checks for Win and Draw

 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHerronAssignment2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
