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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHerronAssignment2
{
    public partial class Form1 : Form
    {
        int turnCount = 0;
        int boxNumber = 0;
        bool winGame = false;
        bool drawGame = false;
        string fillWhich = "";
        string gameWinner = "";



        List<string> boxList = new List<string>();
        string[] boxContain = new string[9];

        public Form1()
        {

            InitializeComponent();
        }


        //checks the turnCount, even for X, odd for O
        public string checkShape(int turnCount)
        {
            string fillShape = "";

            if (turnCount % 2 == 0)
            {


                fillShape = "x";

            }
            else
            {
                fillShape = "o";

            }

            return fillShape;

        }


        public bool checkWin(List<string> boxlist)
        {
            bool winCheck = false;

            //checks the boxList to see if it contains the set of boxes to validate this particular win
            if (boxList.Contains("box11") && boxList.Contains("box12") && boxList.Contains("box13"))
            {

                //rows of three
                //checks that the shapes are all the same
                if (boxContain[0] == boxContain[1] && boxContain[1] == boxContain[2])
                {
                    winCheck = true;
                }

            }


            if (boxList.Contains("box21") && boxList.Contains("box22") && boxList.Contains("box23"))
            {
                if (boxContain[3] == boxContain[4] && boxContain[4] == boxContain[5])
                {
                    winCheck = true;
                }

            }

            if (boxList.Contains("box31") && boxList.Contains("box32") && boxList.Contains("box33"))
            {

                if (boxContain[6] == boxContain[7] && boxContain[7] == boxContain[8])
                {
                    winCheck = true;
                }

            }

            if (boxList.Contains("box11") && boxList.Contains("box21") && boxList.Contains("box31"))
            {

                //column of three
                if (boxContain[0] == boxContain[3] && boxContain[3] == boxContain[6])
                {
                    winCheck = true;
                }

            }


            if (boxList.Contains("box12") && boxList.Contains("box22") && boxList.Contains("box32"))
            {

                if (boxContain[1] == boxContain[4] && boxContain[4] == boxContain[7])
                {
                    winCheck = true;
                }
            }

            if (boxList.Contains("box13") && boxList.Contains("box23") && boxList.Contains("box33"))
            {

                if (boxContain[2] == boxContain[5] && boxContain[5] == boxContain[8])
                {
                    winCheck = true;
                }

            }

            //diagonal

            if (boxList.Contains("box11") && boxList.Contains("box22") && boxList.Contains("box33"))
            {

                if (boxContain[0] == boxContain[4] && boxContain[4] == boxContain[8])
                {
                    winCheck = true;
                }

            }


            if (boxList.Contains("box13") && boxList.Contains("box22") && boxList.Contains("box31"))
            {
                if (boxContain[2] == boxContain[4] && boxContain[4] == boxContain[6])
                {
                    winCheck = true;
                }
            }


            return winCheck;
        }

        //checks turnCount to see if a draw is reached
        public bool checkDraw(int turnCount)
        {
            bool drawResult = false;

            if (turnCount == 9)
            {

                drawResult = true;
            }
            else
            {
                drawResult = false;
            }

            return drawResult;
        }


        //performs actions to reset screen
        public int drawFinal(int turnCount)
        {
            MessageBox.Show("You have reached a draw. Press okay to restart.");
            picBox11.BackgroundImage = null;
            picBox12.BackgroundImage = null;
            pictureBox13.BackgroundImage = null;
            pictureBox21.BackgroundImage = null;
            pictureBox22.BackgroundImage = null;
            pictureBox23.BackgroundImage = null;
            pictureBox31.BackgroundImage = null;
            pictureBox32.BackgroundImage = null;
            pictureBox33.BackgroundImage = null;

            turnCount = 0;

            return turnCount;

        }

        //performs actions to reset screen
        public int winFinal(int turnCount, string gameWinner)
        {

            MessageBox.Show(gameWinner.ToUpper() + " is the winner. Press okay to restart.");
            picBox11.BackgroundImage = null;
            picBox12.BackgroundImage = null;
            pictureBox13.BackgroundImage = null;
            pictureBox21.BackgroundImage = null;
            pictureBox22.BackgroundImage = null;
            pictureBox23.BackgroundImage = null;
            pictureBox31.BackgroundImage = null;
            pictureBox32.BackgroundImage = null;
            pictureBox33.BackgroundImage = null;

            turnCount = 0;
            return turnCount;
        }

        //clears the boxContains array
        public string[] clearBoxContains(string[] boxContains)
        {
            for (int i = 0; i < boxContain.Length; i++)
            {
                boxContain[i] = "";
            }

            return boxContains;
        }


        private void picBox11_Click(object sender, EventArgs e)
        {
            boxNumber = 11;

            //checks which shape to fill box with
            fillWhich = checkShape(turnCount);

            //check if the boxList already contains this certain box to check if filled
            if (!boxList.Contains("box" + boxNumber))
            {

                //sets background image accordingly
                if (fillWhich == "x")
                {
                    picBox11.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    picBox11.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }

                //increments turnCount, adds the box to the list and adds the contents of the box to an array
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[0] = fillWhich;

            }
            else
            {
                MessageBox.Show("That square is already filled.");
            }

            //check for win/draw on box11, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[0];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

        }

        private void picBox12_Click(object sender, EventArgs e)
        {
            boxNumber = 12;


            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {

                    picBox12.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    picBox12.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }

                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[1] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box12, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[1];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

        }


        private void pictureBox13_Click(object sender, EventArgs e)
        {
            boxNumber = 13;

            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox13.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox13.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[2] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box13, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[2];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            boxNumber = 21;


            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox21.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox21.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[3] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box21, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[3];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            boxNumber = 22;



            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox22.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox22.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[4] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box22, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[4];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            boxNumber = 23;


            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox23.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox23.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[5] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box23, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[5];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            boxNumber = 31;



            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox31.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox31.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[6] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box31, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[6];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }

        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            boxNumber = 32;


            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox32.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox32.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[7] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }


            //check for win/draw on box32, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[7];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            boxNumber = 33;


            fillWhich = checkShape(turnCount);

            if (!boxList.Contains("box" + boxNumber))
            {

                if (fillWhich == "x")
                {
                    pictureBox33.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\x.jpg");

                }
                else
                {
                    pictureBox33.BackgroundImage = Image.FromFile(@"G:\2ndYear\PROG2370\SHerronAssignment2\SHerronAssignment2\bin\Debug\o.jpg");
                }
                turnCount++;
                boxList.Add("box" + boxNumber);
                boxContain[8] = fillWhich;
            }
            else
            {

                MessageBox.Show("That square is already filled.");
            }

            //check for win/draw on box33, clear list and array if true
            winGame = checkWin(boxList);
            if (winGame)
            {
                gameWinner = boxContain[8];
                turnCount = winFinal(turnCount, gameWinner);
                boxList.Clear();

                for (int i = 0; i < boxContain.Length; i++)
                {
                    boxContain[i] = "";
                }
            }

            drawGame = checkDraw(turnCount);

            if (drawGame)
            {
                turnCount = drawFinal(turnCount);
                boxList.Clear();
                boxContain = clearBoxContains(boxContain);
            }
        }
    }
}
