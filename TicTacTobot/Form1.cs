using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Microsoft.VisualBasic.PowerPacks;
using System.Windows.Media;


namespace TicTacTobot
{
    public partial class DefaultForm : Form
    {

        //Global Variables
        bool turn = true;
        bool ticTacToe = false;
        bool playerVictory = true;
        bool drawTurnSwap = true;
        int turnCount = 0;
        int winCount = 0;
        int lossCount = 0;
        int drawCount = 0;

        //Initilizing the Application
        public DefaultForm()
        {
            InitializeComponent();
        }

        //Runs once the Application has Loaded
        private void DefaultForm_Load(object sender, EventArgs e)
        {
            
        }

        //Create a New Game
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        //Exit the Application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Show the About Dialog Box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 box = new AboutBox1();
            box.ShowDialog();
        }

        //Set AI Difficulty to Recruit
        private void cluelessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cluelessToolStripMenuItem.Checked == false)
            {
                cluelessToolStripMenuItem.CheckState = CheckState.Checked;
                defenderToolStripMenuItem.CheckState = CheckState.Unchecked;
                aggressiveToolStripMenuItem.CheckState = CheckState.Unchecked;
                ticTacTobotToolStripMenuItem.CheckState = CheckState.Unchecked;
                stopSecretSoundtrack();
            }
        }

        //Set AI Difficulty to Veteran
        private void defenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (defenderToolStripMenuItem.Checked == false)
            {
                cluelessToolStripMenuItem.CheckState = CheckState.Unchecked;
                defenderToolStripMenuItem.CheckState = CheckState.Checked;
                aggressiveToolStripMenuItem.CheckState = CheckState.Unchecked;
                ticTacTobotToolStripMenuItem.CheckState = CheckState.Unchecked;
                stopSecretSoundtrack();

            }
        }

        //Set AI Difficulty to Nightmare
        private void aggressiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aggressiveToolStripMenuItem.Checked == false)
            {
                cluelessToolStripMenuItem.CheckState = CheckState.Unchecked;
                defenderToolStripMenuItem.CheckState = CheckState.Unchecked;
                aggressiveToolStripMenuItem.CheckState = CheckState.Checked;
                ticTacTobotToolStripMenuItem.CheckState = CheckState.Unchecked;
                stopSecretSoundtrack();

            }
        }

        //Player/AI Move
        private void button_Click(object sender, MouseEventArgs e)
        {
            //Creating a local variable for every Button in the application
            Button pressedButton = (Button)sender;

            //Player Move
            if (turn == true)
            {
                pressedButton.Text = "X";
                pressedButton.Enabled = false;
                turnCount++;
                gameOver();
                turn = false;

                /*
                // This is the start of the AI Turn. 
                // This code should only execute if gameOver() has returned false
                */

                System.Threading.Thread.Sleep(1500);
                Random randomMoveCalculation = new Random();
                int randomNumber = randomMoveCalculation.Next(1, 100);

                if (cluelessToolStripMenuItem.Checked == true)
                {
                    if (randomNumber < 25)
                    {
                        cpuAttackAndDefend();
                        cpuRandomMove();
                    }
                    else
                    {
                        cpuRandomMove();
                    }
                    gameOver();

                } else if (defenderToolStripMenuItem.Checked == true)
                {
                    if (randomNumber < 50)
                    {
                        cpuAttackAndDefend();
                        cpuRandomMove();
                    }
                    else
                    {
                        cpuRandomMove();
                    }
                    gameOver();
                } else if (aggressiveToolStripMenuItem.Checked == true)
                {
                    if (randomNumber < 75)
                    {
                        cpuAttackAndDefend();
                        cpuRandomMove();
                    }
                    else
                    {
                        cpuRandomMove();
                    }
                    gameOver();
                } else if (ticTacTobotToolStripMenuItem.Checked == true)
                {
                    cpuAttackAndDefend();
                    cpuStrategyMove();
                    cpuRandomMove();
                    gameOver();
                }
            }
        }

        //Classic Color Theme
        private void classicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check Box Code
            if (classicToolStripMenuItem.Checked == false)
            {
                classicToolStripMenuItem.CheckState = CheckState.Checked;
                darkToolStripMenuItem.CheckState = CheckState.Unchecked;
                digitalToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            //Form Color
            this.BackColor = SystemColors.GradientActiveCaption;

            //MenuStrip Color
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ForeColor = SystemColors.ControlText;
            fileToolStripMenuItem.BackColor = SystemColors.Control;
            fileToolStripMenuItem.ForeColor = SystemColors.ControlText;
            newToolStripMenuItem.BackColor = SystemColors.Control;
            newToolStripMenuItem.ForeColor = SystemColors.ControlText;
            exitToolStripMenuItem.BackColor = SystemColors.Control;
            exitToolStripMenuItem.ForeColor = SystemColors.ControlText;
            optionsToolStripMenuItem.BackColor = SystemColors.Control;
            optionsToolStripMenuItem.ForeColor = SystemColors.ControlText;
            colorThemeToolStripMenuItem.BackColor = SystemColors.Control;
            colorThemeToolStripMenuItem.ForeColor = SystemColors.ControlText;
            classicToolStripMenuItem.BackColor = SystemColors.Control;
            classicToolStripMenuItem.ForeColor = SystemColors.ControlText;
            darkToolStripMenuItem.BackColor = SystemColors.Control;
            darkToolStripMenuItem.ForeColor = SystemColors.ControlText;
            digitalToolStripMenuItem.BackColor = SystemColors.Control;
            digitalToolStripMenuItem.ForeColor = SystemColors.ControlText;
            difficultyToolStripMenuItem.BackColor = SystemColors.Control;
            difficultyToolStripMenuItem.ForeColor = SystemColors.ControlText;
            cluelessToolStripMenuItem.BackColor = SystemColors.Control;
            cluelessToolStripMenuItem.ForeColor = SystemColors.ControlText;
            defenderToolStripMenuItem.BackColor = SystemColors.Control;
            defenderToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aggressiveToolStripMenuItem.BackColor = SystemColors.Control;
            aggressiveToolStripMenuItem.ForeColor = SystemColors.ControlText;
            helpToolStripMenuItem.BackColor = SystemColors.Control;
            helpToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = SystemColors.ControlText;

            //Set Button Background Color
            button1.BackColor = SystemColors.Highlight;
            button2.BackColor = SystemColors.Highlight;
            button3.BackColor = SystemColors.Highlight;
            button4.BackColor = SystemColors.Highlight;
            button5.BackColor = SystemColors.Highlight;
            button6.BackColor = SystemColors.Highlight;
            button7.BackColor = SystemColors.Highlight;
            button8.BackColor = SystemColors.Highlight;
            button9.BackColor = SystemColors.Highlight;

            //Set Button Text Color
            button1.ForeColor = SystemColors.ControlText;
            button2.ForeColor = SystemColors.ControlText;
            button3.ForeColor = SystemColors.ControlText;
            button4.ForeColor = SystemColors.ControlText;
            button5.ForeColor = SystemColors.ControlText;
            button6.ForeColor = SystemColors.ControlText;
            button7.ForeColor = SystemColors.ControlText;
            button8.ForeColor = SystemColors.ControlText;
            button9.ForeColor = SystemColors.ControlText;
 
            //Set Button Properties back to default
            button1.UseVisualStyleBackColor = false;
            button2.UseVisualStyleBackColor = false;
            button3.UseVisualStyleBackColor = false;
            button4.UseVisualStyleBackColor = false;
            button5.UseVisualStyleBackColor = false;
            button6.UseVisualStyleBackColor = false;
            button7.UseVisualStyleBackColor = false;
            button8.UseVisualStyleBackColor = false;
            button9.UseVisualStyleBackColor = false;

            //Set Label Color
            label1.ForeColor = SystemColors.ControlText;
            label2.ForeColor = SystemColors.ControlText;
            label3.ForeColor = SystemColors.ControlText;
            winCountLabel.ForeColor = SystemColors.ControlText;
            lossCountLabel.ForeColor = SystemColors.ControlText;
            drawCountLabel.ForeColor = SystemColors.ControlText;
        }

        //Dark Color Theme
        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check Box Code
            if (darkToolStripMenuItem.Checked == false)
            {
                classicToolStripMenuItem.CheckState = CheckState.Unchecked;
                darkToolStripMenuItem.CheckState = CheckState.Checked;
                digitalToolStripMenuItem.CheckState = CheckState.Unchecked;
            }

            //Form Color
            this.BackColor = System.Drawing.Color.Black;

            //MenuStrip Color
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ForeColor = SystemColors.ControlText;
            fileToolStripMenuItem.BackColor = SystemColors.Control;
            fileToolStripMenuItem.ForeColor = SystemColors.ControlText;
            newToolStripMenuItem.BackColor = SystemColors.Control;
            newToolStripMenuItem.ForeColor = SystemColors.ControlText;
            exitToolStripMenuItem.BackColor = SystemColors.Control;
            exitToolStripMenuItem.ForeColor = SystemColors.ControlText;
            optionsToolStripMenuItem.BackColor = SystemColors.Control;
            optionsToolStripMenuItem.ForeColor = SystemColors.ControlText;
            colorThemeToolStripMenuItem.BackColor = SystemColors.Control;
            colorThemeToolStripMenuItem.ForeColor = SystemColors.ControlText;
            classicToolStripMenuItem.BackColor = SystemColors.Control;
            classicToolStripMenuItem.ForeColor = SystemColors.ControlText;
            darkToolStripMenuItem.BackColor = SystemColors.Control;
            darkToolStripMenuItem.ForeColor = SystemColors.ControlText;
            digitalToolStripMenuItem.BackColor = SystemColors.Control;
            digitalToolStripMenuItem.ForeColor = SystemColors.ControlText;
            difficultyToolStripMenuItem.BackColor = SystemColors.Control;
            difficultyToolStripMenuItem.ForeColor = SystemColors.ControlText;
            cluelessToolStripMenuItem.BackColor = SystemColors.Control;
            cluelessToolStripMenuItem.ForeColor = SystemColors.ControlText;
            defenderToolStripMenuItem.BackColor = SystemColors.Control;
            defenderToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aggressiveToolStripMenuItem.BackColor = SystemColors.Control;
            aggressiveToolStripMenuItem.ForeColor = SystemColors.ControlText;
            helpToolStripMenuItem.BackColor = SystemColors.Control;
            helpToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = SystemColors.ControlText;

            //Set Button Background Color
            button1.BackColor = SystemColors.ControlDarkDark;
            button2.BackColor = SystemColors.ControlDarkDark;
            button3.BackColor = SystemColors.ControlDarkDark;
            button4.BackColor = SystemColors.ControlDarkDark;
            button5.BackColor = SystemColors.ControlDarkDark;
            button6.BackColor = SystemColors.ControlDarkDark;
            button7.BackColor = SystemColors.ControlDarkDark;
            button8.BackColor = SystemColors.ControlDarkDark;
            button9.BackColor = SystemColors.ControlDarkDark;

            //Set Button Text Color
            button1.ForeColor = System.Drawing.Color.Orange;
            button2.ForeColor = System.Drawing.Color.Orange;
            button3.ForeColor = System.Drawing.Color.Orange;
            button4.ForeColor = System.Drawing.Color.Orange;
            button5.ForeColor = System.Drawing.Color.Orange;
            button6.ForeColor = System.Drawing.Color.Orange;
            button7.ForeColor = System.Drawing.Color.Orange;
            button8.ForeColor = System.Drawing.Color.Orange;
            button9.ForeColor = System.Drawing.Color.Orange;

            //Set Label Color
            label1.ForeColor = SystemColors.HighlightText;
            label2.ForeColor = SystemColors.HighlightText;
            label3.ForeColor = SystemColors.HighlightText;
            winCountLabel.ForeColor = SystemColors.HighlightText;
            lossCountLabel.ForeColor = SystemColors.HighlightText;
            drawCountLabel.ForeColor = SystemColors.HighlightText;
        }

        //Digital Color Theme
        private void digitalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check Box Code
            if (digitalToolStripMenuItem.Checked == false)
            {
                classicToolStripMenuItem.CheckState = CheckState.Unchecked;
                darkToolStripMenuItem.CheckState = CheckState.Unchecked;
                digitalToolStripMenuItem.CheckState = CheckState.Checked;
            }

            //Form Color
            this.BackColor = System.Drawing.Color.Black;

            //MenuStrip Color
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ForeColor = SystemColors.ControlText;
            fileToolStripMenuItem.BackColor = SystemColors.Control;
            fileToolStripMenuItem.ForeColor = SystemColors.ControlText;
            newToolStripMenuItem.BackColor = SystemColors.Control;
            newToolStripMenuItem.ForeColor = SystemColors.ControlText;
            exitToolStripMenuItem.BackColor = SystemColors.Control;
            exitToolStripMenuItem.ForeColor = SystemColors.ControlText;
            optionsToolStripMenuItem.BackColor = SystemColors.Control;
            optionsToolStripMenuItem.ForeColor = SystemColors.ControlText;
            colorThemeToolStripMenuItem.BackColor = SystemColors.Control;
            colorThemeToolStripMenuItem.ForeColor = SystemColors.ControlText;
            classicToolStripMenuItem.BackColor = SystemColors.Control;
            classicToolStripMenuItem.ForeColor = SystemColors.ControlText;
            darkToolStripMenuItem.BackColor = SystemColors.Control;
            darkToolStripMenuItem.ForeColor = SystemColors.ControlText;
            digitalToolStripMenuItem.BackColor = SystemColors.Control;
            digitalToolStripMenuItem.ForeColor = SystemColors.ControlText;
            difficultyToolStripMenuItem.BackColor = SystemColors.Control;
            difficultyToolStripMenuItem.ForeColor = SystemColors.ControlText;
            cluelessToolStripMenuItem.BackColor = SystemColors.Control;
            cluelessToolStripMenuItem.ForeColor = SystemColors.ControlText;
            defenderToolStripMenuItem.BackColor = SystemColors.Control;
            defenderToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aggressiveToolStripMenuItem.BackColor = SystemColors.Control;
            aggressiveToolStripMenuItem.ForeColor = SystemColors.ControlText;
            helpToolStripMenuItem.BackColor = SystemColors.Control;
            helpToolStripMenuItem.ForeColor = SystemColors.ControlText;
            aboutToolStripMenuItem.BackColor = SystemColors.Control;
            aboutToolStripMenuItem.ForeColor = SystemColors.ControlText;

            //Set Button Background Color
            button1.BackColor = System.Drawing.Color.SlateGray;
            button2.BackColor = System.Drawing.Color.SlateGray;
            button3.BackColor = System.Drawing.Color.SlateGray;
            button4.BackColor = System.Drawing.Color.SlateGray;
            button5.BackColor = System.Drawing.Color.SlateGray;
            button6.BackColor = System.Drawing.Color.SlateGray;
            button7.BackColor = System.Drawing.Color.SlateGray;
            button8.BackColor = System.Drawing.Color.SlateGray;
            button9.BackColor = System.Drawing.Color.SlateGray;

            //Set Button Text Color
            button1.ForeColor = System.Drawing.Color.LimeGreen;
            button2.ForeColor = System.Drawing.Color.LimeGreen;
            button3.ForeColor = System.Drawing.Color.LimeGreen;
            button4.ForeColor = System.Drawing.Color.LimeGreen;
            button5.ForeColor = System.Drawing.Color.LimeGreen;
            button6.ForeColor = System.Drawing.Color.LimeGreen;
            button7.ForeColor = System.Drawing.Color.LimeGreen;
            button8.ForeColor = System.Drawing.Color.LimeGreen;
            button9.ForeColor = System.Drawing.Color.LimeGreen;
           
            //Set Label Color
            label1.ForeColor = System.Drawing.Color.LimeGreen;
            label2.ForeColor = System.Drawing.Color.LimeGreen;
            label3.ForeColor = System.Drawing.Color.LimeGreen;
            winCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
            lossCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
            drawCountLabel.ForeColor = System.Drawing.Color.LimeGreen;
        }

        //Show X when Button is Entered
        private void button_Enter(object sender, EventArgs e)
        {
            Button buttonEnter = (Button)sender;
            if ((turn == true) && (buttonEnter.Enabled == true))
            {
                buttonEnter.Text = "X";
            }
        }

        //Hide X when Button is Left
        private void button_Leave(object sender, EventArgs e)
        {
            Button buttonLeave = (Button)sender;
            if ((turn == true) && (buttonLeave.Enabled == true))
            {              
                buttonLeave.Text = null;              
            }
        }

        //My Functions

        //New Game | Reset the Board
        private void newGame()
        {
            turnCount = 0;
            ticTacToe = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

            button1.Text = null;
            button2.Text = null;
            button3.Text = null;
            button4.Text = null;
            button5.Text = null;
            button6.Text = null;
            button7.Text = null;
            button8.Text = null;
            button9.Text = null;
        }

        //Disable Buttons
        private void disableButtons()
        {
            if (button1.Enabled == true)
            {
                button1.Enabled = false;
            }

            if (button2.Enabled == true)
            {
                button2.Enabled = false;
            }

            if (button3.Enabled == true)
            {
                button3.Enabled = false;
            }

            if (button4.Enabled == true)
            {
                button4.Enabled = false;
            }

            if (button5.Enabled == true)
            {
                button5.Enabled = false;
            }

            if (button6.Enabled == true)
            {
                button6.Enabled = false;
            }

            if (button7.Enabled == true)
            {
                button7.Enabled = false;
            }

            if (button8.Enabled == true)
            {
                button8.Enabled = false;
            }

            if (button9.Enabled == true)
            {
                button9.Enabled = false;
            }
        }

        //Game Over | Function to Determine if the Game has ended in a Player Win/CPU Win/Draw.
        private void gameOver()
        {
            //Checking Row 1 | Horizontal
            if ((button1.Text == button2.Text) && (button2.Text == button3.Text) && (button1.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;

                ticTacToe = true;
                if (button1.Text == "X")
                {
                    //Highlight Winning Move for X
                    button1.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button2.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button3.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button1.ForeColor = System.Drawing.Color.Tomato;
                    button2.ForeColor = System.Drawing.Color.Tomato;
                    button3.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
                
            }

            //Checking Row 2 | Horizontal
            else if ((button4.Text == button5.Text) && (button5.Text == button6.Text) && (button4.Enabled == false))
            {

                // Enable Buttons to Highlight the Winning Move
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;

                ticTacToe = true;
                if (button4.Text == "X")
                {
                    //Highlight Winning Move for X
                    button4.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button5.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button6.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button4.ForeColor = System.Drawing.Color.Tomato;
                    button5.ForeColor = System.Drawing.Color.Tomato;
                    button6.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Row 3 | Horizontal
            else if ((button7.Text == button8.Text) && (button8.Text == button9.Text) && (button7.Enabled == false))
            {

                // Enable Buttons to Highlight the Winning Move
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;

                ticTacToe = true;
                if (button7.Text == "X")
                {
                    //Highlight Winning Move for X
                    button7.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button8.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button9.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button7.ForeColor = System.Drawing.Color.Tomato;
                    button8.ForeColor = System.Drawing.Color.Tomato;
                    button9.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Column 1 | Vertical
            else if ((button1.Text == button4.Text) && (button4.Text == button7.Text) && (button1.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button1.Enabled = true;
                button4.Enabled = true;
                button7.Enabled = true;

                ticTacToe = true;
                if (button1.Text == "X")
                {
                    //Highlight Winning Move for X
                    button1.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button4.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button7.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button1.ForeColor = System.Drawing.Color.Tomato;
                    button4.ForeColor = System.Drawing.Color.Tomato;
                    button7.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Column 2 | Vertical
            else if ((button2.Text == button5.Text) && (button5.Text == button8.Text) && (button2.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button2.Enabled = true;
                button5.Enabled = true;
                button8.Enabled = true;

                ticTacToe = true;
                if (button2.Text == "X")
                {
                    //Highlight Winning Move for X
                    button2.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button5.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button8.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button2.ForeColor = System.Drawing.Color.Tomato;
                    button5.ForeColor = System.Drawing.Color.Tomato;
                    button8.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Column 3 | Vertical
            else if ((button3.Text == button6.Text) && (button6.Text == button9.Text) && (button3.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button3.Enabled = true;
                button6.Enabled = true;
                button9.Enabled = true;

                ticTacToe = true;
                if (button3.Text == "X")
                {
                    //Highlight Winning Move for X
                    button3.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button6.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button9.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button3.ForeColor = System.Drawing.Color.Tomato;
                    button6.ForeColor = System.Drawing.Color.Tomato;
                    button9.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Diagonal | Top Left to Bottom Right
            else if ((button1.Text == button5.Text) && (button5.Text == button9.Text) && (button1.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button1.Enabled = true;
                button5.Enabled = true;
                button9.Enabled = true;

                ticTacToe = true;
                if (button1.Text == "X")
                {
                    //Highlight Winning Move for X
                    button1.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button5.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button9.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button1.ForeColor = System.Drawing.Color.Tomato;
                    button5.ForeColor = System.Drawing.Color.Tomato;
                    button9.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //Checking Diagonal | Top Right to Bottom Left
            else if ((button3.Text == button5.Text) && (button5.Text == button7.Text) && (button3.Enabled == false))
            {
                // Enable Buttons to Highlight the Winning Move
                button3.Enabled = true;
                button5.Enabled = true;
                button7.Enabled = true;

                ticTacToe = true;
                if (button3.Text == "X")
                {
                    //Highlight Winning Move for X
                    button3.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button5.ForeColor = System.Drawing.Color.WhiteSmoke;
                    button7.ForeColor = System.Drawing.Color.WhiteSmoke;
                    playerVictory = true;
                }
                else
                {
                    //Highlight Winning Move for O
                    button3.ForeColor = System.Drawing.Color.Tomato;
                    button5.ForeColor = System.Drawing.Color.Tomato;
                    button7.ForeColor = System.Drawing.Color.Tomato;
                    playerVictory = false;
                }
            }

            //This will run once the Game has ended
            if (ticTacToe == true)
            {

                //Calling the "disableButtons()" Function
                disableButtons();

                //Executed when the Player wins
                if ((playerVictory == true) && (ticTacToe == true))
                {                   
                    winCount = winCount + 1;
                    if (winCount == 10)
                    {
                        string getWinCount = winCount.ToString();
                        winCountLabel.Text = getWinCount;
                        unlockSecretDifficulty();                        
                        turn = false;
                        ticTacToe = false;
                        playerVictory = false;
                        newGame();
                    } else if (winCount != 10)
                    {
                        SoundPlayer winSound = new SoundPlayer("electric.wav");
                        winSound.Play();
                        string getWinCount = winCount.ToString();
                        winCountLabel.Text = getWinCount;
                        turn = false;
                        ticTacToe = false;
                        playerVictory = false;
                        System.Threading.Thread.Sleep(3000);
                        newGame();
                    }                
                    
                }

                //Executed when the CPU wins
                else if ((playerVictory == false) && (ticTacToe == true))
                {
                    SoundPlayer loseSound = new SoundPlayer("evilLaugh.wav");
                    loseSound.Play();
                    lossCount = lossCount + 1;
                    string getLossCount = lossCount.ToString();
                    lossCountLabel.Text = getLossCount;
                    turn = true;
                    playerVictory = true;
                    System.Threading.Thread.Sleep(5000);
                    newGame();
                }
            }

            //Executed when the Game ends in a Draw
            if ((turnCount == 9) && (ticTacToe == false))
            {
                SoundPlayer drawSound = new SoundPlayer("metalGong.wav");
                drawSound.Play();
                drawCount = drawCount + 1;
                string getDrawCount = drawCount.ToString();
                drawCountLabel.Text = getDrawCount;
                ticTacToe = false;

                if (drawTurnSwap == true)
                {
                    drawTurnSwap = false;
                }
                else
                {
                    drawTurnSwap = true;
                }
                System.Threading.Thread.Sleep(2000);
                newGame();
            }
        }

        //The CPU will Move in a Random Location
        private void cpuRandomMove()
        {
            while ((turn == false) && (ticTacToe == false))
            {
                Random randomNumberGenerator = new Random();
                string x = randomNumberGenerator.Next(1, 10).ToString();
                string cpuMove = ("button" + x);

                if ((cpuMove == "button1") && button1.Enabled == true)
                {
                    button1.Text = "O";
                    button1.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button2") && button2.Enabled == true)
                {
                    button2.Text = "O";
                    button2.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button3") && button3.Enabled == true)
                {
                    button3.Text = "O";
                    button3.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button4") && button4.Enabled == true)
                {
                    button4.Text = "O";
                    button4.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button5") && button5.Enabled == true)
                {
                    button5.Text = "O";
                    button5.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button6") && button6.Enabled == true)
                {
                    button6.Text = "O";
                    button6.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button7") && button7.Enabled == true)
                {
                    button7.Text = "O";
                    button7.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button8") && button8.Enabled == true)
                {
                    button8.Text = "O";
                    button8.Enabled = false;
                    turnCount++;
                    turn = true;
                }
                else if ((cpuMove == "button9") && button9.Enabled == true)
                {
                    button9.Text = "O";
                    button9.Enabled = false;
                    turnCount++;
                    turn = true;
                }
            }
        }

        //The CPU will search for a Winning Move, Than a Block
        private void cpuAttackAndDefend()
        {
            //R1 | Horizontal | Left to Right
            if ((button1.Text == "O") && (button2.Text == "O") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R1 | Horizontal | Check Middle
            else if ((button1.Text == "O") && (button3.Text == "O") && (button2.Enabled == true) && (ticTacToe == false))
            {
                button2.Text = "O";
                button2.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R1 | Horizontal | Right to Left
            else if ((button3.Text == "O") && (button2.Text == "O") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R2 | Horizontal | Left to Right
            else if ((button4.Text == "O") && (button5.Text == "O") && (button6.Enabled == true) && (ticTacToe == false))
            {
                button6.Text = "O";
                button6.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R2 | Horizontal | Check Middle
            else if ((button4.Text == "O") && (button6.Text == "O") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R2 | Horizontal | Right to Left
            else if ((button6.Text == "O") && (button5.Text == "O") && (button4.Enabled == true) && (ticTacToe == false))
            {
                button4.Text = "O";
                button4.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Left to Right
            else if ((button7.Text == "O") && (button8.Text == "O") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Check Middle
            else if ((button7.Text == "O") && (button9.Text == "O") && (button8.Enabled == true) && (ticTacToe == false))
            {
                button8.Text = "O";
                button8.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Left to Right
            else if ((button9.Text == "O") && (button8.Text == "O") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Top to Bottom
            else if ((button1.Text == "O") && (button4.Text == "O") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Check Middle
            else if ((button1.Text == "O") && (button7.Text == "O") && (button4.Enabled == true) && (ticTacToe == false))
            {
                button4.Text = "O";
                button4.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Bottom to Top
            else if ((button7.Text == "O") && (button4.Text == "O") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Top to Bottom
            else if ((button2.Text == "O") && (button5.Text == "O") && (button8.Enabled == true) && (ticTacToe == false))
            {
                button8.Text = "O";
                button8.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Check Middle
            else if ((button2.Text == "O") && (button8.Text == "O") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Bottom to Top
            else if ((button8.Text == "O") && (button5.Text == "O") && (button2.Enabled == true) && (ticTacToe == false))
            {
                button2.Text = "O";
                button2.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Top to Bottom
            else if ((button3.Text == "O") && (button6.Text == "O") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Check Middle
            else if ((button3.Text == "O") && (button9.Text == "O") && (button6.Enabled == true) && (ticTacToe == false))
            {
                button6.Text = "O";
                button6.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Bottom to Top
            else if ((button9.Text == "O") && (button6.Text == "O") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Top Left to Bottom Right
            else if ((button1.Text == "O") && (button5.Text == "O") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Check Middle
            else if ((button1.Text == "O") && (button9.Text == "O") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Bottom Right to Top Left
            else if ((button9.Text == "O") && (button5.Text == "O") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Top Right to Bottom Left
            else if ((button3.Text == "O") && (button5.Text == "O") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Check Middle
            else if ((button3.Text == "O") && (button7.Text == "O") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Bottom Left to Top Right
            else if ((button7.Text == "O") && (button5.Text == "O") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }

            //Start Block Code Check

            else if ((button1.Text == "X") && (button2.Text == "X") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R1 | Horizontal | Check Middle
            else if ((button1.Text == "X") && (button3.Text == "X") && (button2.Enabled == true) && (ticTacToe == false))
            {
                button2.Text = "O";
                button2.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R1 | Horizontal | Right to Left
            else if ((button3.Text == "X") && (button2.Text == "X") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R2 | Horizontal | Left to Right
            else if ((button4.Text == "X") && (button5.Text == "X") && (button6.Enabled == true) && (ticTacToe == false))
            {
                button6.Text = "O";
                button6.Enabled = false;
                turnCount++;
                turn = true;
            }
            //R2 | Horizontal | Check Middle
            else if ((button4.Text == "X") && (button6.Text == "X") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R2 | Horizontal | Right to Left
            else if ((button6.Text == "X") && (button5.Text == "X") && (button4.Enabled == true) && (ticTacToe == false))
            {
                button4.Text = "O";
                button4.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Left to Right
            else if ((button7.Text == "X") && (button8.Text == "X") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Check Middle
            else if ((button7.Text == "X") && (button9.Text == "X") && (button8.Enabled == true) && (ticTacToe == false))
            {
                button8.Text = "O";
                button8.Enabled = false;
                turnCount++;
                turn = true;
            }

            //R3 | Horizontal | Left to Right
            else if ((button9.Text == "X") && (button8.Text == "X") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Top to Bottom
            else if ((button1.Text == "X") && (button4.Text == "X") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Check Middle
            else if ((button1.Text == "X") && (button7.Text == "X") && (button4.Enabled == true) && (ticTacToe == false))
            {
                button4.Text = "O";
                button4.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C1 | Vertical | Bottom to Top
            else if ((button7.Text == "X") && (button4.Text == "X") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Top to Bottom
            else if ((button2.Text == "X") && (button5.Text == "X") && (button8.Enabled == true) && (ticTacToe == false))
            {
                button8.Text = "O";
                button8.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Check Middle
            else if ((button2.Text == "X") && (button8.Text == "X") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C2 | Vertical | Bottom to Top
            else if ((button8.Text == "X") && (button5.Text == "X") && (button2.Enabled == true) && (ticTacToe == false))
            {
                button2.Text = "O";
                button2.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Top to Bottom
            else if ((button3.Text == "X") && (button6.Text == "X") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Check Middle
            else if ((button3.Text == "X") && (button9.Text == "X") && (button6.Enabled == true) && (ticTacToe == false))
            {
                button6.Text = "O";
                button6.Enabled = false;
                turnCount++;
                turn = true;
            }

            //C3 | Vertical | Bottom to Top
            else if ((button9.Text == "X") && (button6.Text == "X") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Top Left to Bottom Right
            else if ((button1.Text == "X") && (button5.Text == "X") && (button9.Enabled == true) && (ticTacToe == false))
            {
                button9.Text = "O";
                button9.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Check Middle
            else if ((button1.Text == "X") && (button9.Text == "X") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D1 | Diagonal | Bottom Right to Top Left
            else if ((button9.Text == "X") && (button5.Text == "X") && (button1.Enabled == true) && (ticTacToe == false))
            {
                button1.Text = "O";
                button1.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Top Right to Bottom Left
            else if ((button3.Text == "X") && (button5.Text == "X") && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Check Middle
            else if ((button3.Text == "X") && (button7.Text == "X") && (button5.Enabled == true) && (ticTacToe == false))
            {
                button5.Text = "O";
                button5.Enabled = false;
                turnCount++;
                turn = true;
            }

            //D2 | Diagonal | Bottom Left to Top Right
            else if ((button7.Text == "X") && (button5.Text == "X") && (button3.Enabled == true) && (ticTacToe == false))
            {
                button3.Text = "O";
                button3.Enabled = false;
                turnCount++;
                turn = true;
            }
        }

        //The CPU will look for a strategic move
        private void cpuStrategyMove()
        {
            if ((button1.Text == "O") && (button5.Text == "O") && (button3 == null) && (button4 == null) && (button7.Enabled == true) && (ticTacToe == false))
            {
                button7.Text = "O";
                button7.Enabled = false;
                turnCount++;
                turn = true;
            } 
        }

        //Overides Diabled Button Color Change
        private void button_EnabledChange(object sender, EventArgs e)
        {
            Button disabledButton = (Button)sender;
            if (classicToolStripMenuItem.Checked == true)
            {
                disabledButton.ForeColor = disabledButton.Enabled ? System.Drawing.Color.Black : System.Drawing.Color.Black;
            } else if (darkToolStripMenuItem.Checked == true)
            {
                disabledButton.ForeColor = disabledButton.Enabled ? System.Drawing.Color.Orange : System.Drawing.Color.Orange;
            } else if (digitalToolStripMenuItem.Checked == true)
            {
                disabledButton.ForeColor = disabledButton.Enabled ? System.Drawing.Color.LimeGreen : System.Drawing.Color.LimeGreen;
            }
        }

        //Repaints Text Over a Disabled Button      
        private void button_Paint(object sender, PaintEventArgs e)
        {
            dynamic btn = (Button)sender;
            dynamic drawBrush = new SolidBrush(btn.ForeColor);
            dynamic sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            if ((btn.Text == "X") && (btn.Enabled == false))
            {
                e.Graphics.DrawString("X", btn.Font, drawBrush, e.ClipRectangle, sf);
            } 
            else if ((btn.Text == "O") && (btn.Enabled == false))
            {
                e.Graphics.DrawString("O", btn.Font, drawBrush, e.ClipRectangle, sf);
            }
            drawBrush.Dispose();
            sf.Dispose();
        }

        //Secret Difficulty TicTacTobot
        private void ticTacTobotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ticTacTobotToolStripMenuItem.Checked == false)
            {
                cluelessToolStripMenuItem.CheckState = CheckState.Unchecked;
                defenderToolStripMenuItem.CheckState = CheckState.Unchecked;
                aggressiveToolStripMenuItem.CheckState = CheckState.Unchecked;
                ticTacTobotToolStripMenuItem.CheckState = CheckState.Checked;
                SoundPlayer whoDareChallenge = new SoundPlayer("whoDareChallenge.wav");
                whoDareChallenge.Play();
                System.Threading.Thread.Sleep(5000);
                startSecretSoundtrack();
            }
        }

        //Unlocks a Secret Difficulty Level
        private void unlockSecretDifficulty()
        {
            if (winCount == 10)
            {
                ticTacTobotToolStripMenuItem.Visible = true;
                SoundPlayer secretSound = new SoundPlayer("secret.wav");
                secretSound.Play();
                var question = MessageBox.Show("You've unlocked a Secret Difficulty Level! Do you have what it takes to take on TicTacTobot?", "Secret Difficulty Unlocked!", MessageBoxButtons.YesNo);
                System.Threading.Thread.Sleep(1500);
                if (question == DialogResult.Yes)
                {
                    SoundPlayer whoDareChallenge = new SoundPlayer("whoDareChallenge.wav");
                    whoDareChallenge.Play();
                    System.Threading.Thread.Sleep(5000);
                    cluelessToolStripMenuItem.CheckState = CheckState.Unchecked;
                    defenderToolStripMenuItem.CheckState = CheckState.Unchecked;
                    aggressiveToolStripMenuItem.CheckState = CheckState.Unchecked;
                    ticTacTobotToolStripMenuItem.CheckState = CheckState.Checked;
                    startSecretSoundtrack();

                } else
                {
                    SoundPlayer comeback = new SoundPlayer("comeback.wav");
                    comeback.Play();
                    System.Threading.Thread.Sleep(2000);
                }

            }
        }

        //Plays Secret Soundtrack
        private void startSecretSoundtrack()
        {
            axWindowsMediaPlayer1.URL = "impossibleGameSoundtrack.mp3";
        }

        //Stops Playing Secret Soundtrack
        private void stopSecretSoundtrack()
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.stop();
            }
        }
    }

}
