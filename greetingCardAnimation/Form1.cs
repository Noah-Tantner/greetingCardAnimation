//Noah Tantner
//23rd of October, 2023
//It is a greeting card, which uses some funky little animation to wish somebody merry christmas!.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace greetingCardAnimation
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int colorNumber;


        //All pen and Brush declarations
        Pen whitePen = new Pen(Color.DeepSkyBlue, 10);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush darkGoldenrodBrush = new SolidBrush(Color.DarkGoldenrod);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);


        //fonts
        Font cardFont = new Font("Arial", 12, FontStyle.Bold);
        Font christmansFont = new Font("Arial", 16, FontStyle.Bold);
        Font frontPageFont = new Font("Equinox", 20, FontStyle.Bold);
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            //different delays for the moving black box
            int avgDelay = 700;
            int fastDelay = 400;
            int realFastDelay = 200;
            int longDelay = 1000;
            Graphics g = this.CreateGraphics();


            //the following is all the code that makes the black box move and do its thing

            //this moves it right
            for (int i = 10; i < 400; i++)
            {
                MoveTextRectangle(i, 60, "Hey");
            }
            Thread.Sleep(realFastDelay);

            //this moves left again
            for (int i = 400; i > 10; i--)
            {
                MoveTextRectangle(i, 60, "Hi");
            }
            Thread.Sleep(fastDelay);
            //this moves down
            for (int i = 60; i < 200; i++)
            {
                MoveTextRectangle(20, i, "Hello, ");
            }
            Thread.Sleep(fastDelay);

            //this moves right
            for (int i = 10; i < 400; i++)
            {
                MoveTextRectangle(i, 200, "I");
            }
            Thread.Sleep(fastDelay);

            //this moves back up
            for (int i = 200; i > 60; i--)
            {
                MoveTextRectangle(400, i, "greet");
            }
            Thread.Sleep(fastDelay);

            //moves left
            for (int i = 400; i > 10; i--)
            {
                MoveTextRectangle(i, 60, "you,");
            }
            Thread.Sleep(fastDelay);

            //moves down
            for (int i = 60; i < 200; i++)
            {
                MoveTextRectangle(20, i, "human.");
            }
            Thread.Sleep(longDelay);

            //this moves right
            for (int i = 10; i < 400; i++)
            {
                MoveTextRectangle(i, 200, "Do");
            }
            Thread.Sleep(fastDelay);

            //moves left
            for (int i = 400; i > 10; i--)
            {
                MoveTextRectangle(i, 60, "you,");
            }
            Thread.Sleep(fastDelay);

            //this moves up
            for (int i = 200; i > 60; i--)
            {
                MoveTextRectangle(400, i, "like");
            }
            Thread.Sleep(avgDelay);

            //this moves right
            for (int i = 10; i < 400; i++)
            {
                MoveTextRectangle(i, 200, "Magic");
            }
            Thread.Sleep(avgDelay);

            //moves down
            for (int i = 60; i < 200; i++)
            {
                MoveTextRectangle(20, i, "???");
            }
            Thread.Sleep(longDelay);

            //move from left to right
            for (int i = 10; i < 400; i++)
            {
                MoveTextRectangle(i, 200, "???");
            }

            //moves right to left
            for (int i = 400; i > 10; i--)
            {
                MoveTextRectangle(i, 60, "you,");
            }

            //move from left to middle
            for (int i = 10; i < 200; i++)
            {
                MoveTextRectangle(i, 200, "Then you'll love");
            }
            Thread.Sleep(avgDelay);

            //this moves up
            for (int i = 200; i > 60; i--)
            {
                MoveTextRectangle(200, i, "The magic of");
            }
            Thread.Sleep(avgDelay);

            //moves down
            for (int i = 60; i < 130; i++)
            {
                MoveTextRectangle(200, i, "CHRISTMAS!!!");
            }





            //sound Declaration
            SoundPlayer MerryChristmas = new SoundPlayer(Properties.Resources.Merry_Christmas_Sound);
        


            //some variables for the christmas animation
            float exponential;
            int xStart = 275;
            int normalXSpeed = 22;

            int flakeHeight = 10;
            int fasterFlakeHeight = 10;
            int xVariable;
            int xSpeed = normalXSpeed;
            int xSpeedChanger;
            bool fallLeft = true;
            SolidBrush brushVar = darkGoldenrodBrush;

            MerryChristmas.Play();
            //the following loop creates a message saying "Merry Christmas" that changes color,
            //along, with a ball above it the falls left or right 20 times. It also creates some 
            //snowflakes that move down the screen
            for (int i = 0; i <= 20; i++)
            {

                xVariable = xStart;
                exponential = 15;
                colorNumber = random.Next(0, 3);
                if (fallLeft)
                {
                    xSpeed = normalXSpeed;
                    xSpeedChanger = normalXSpeed;
                    fallLeft = false;
                }
                else
                {
                    xSpeed = normalXSpeed;
                    xSpeedChanger = -normalXSpeed;
                    fallLeft = true;
                }

                for (int y = 5; y <= 16; y +=1)
                {

                    if (colorNumber == 0)
                    {
                        brushVar = darkGoldenrodBrush;
                    }
                    else if (colorNumber == 1)
                    {
                        brushVar = greenBrush;
                    }
                    else if (colorNumber == 2)
                    {
                        brushVar = blueBrush;
                    }

                    g.Clear(Color.White);
                    DrawSnowflake(fasterFlakeHeight -10, 10);
                    DrawSnowflake(flakeHeight-50, 100);
                    DrawSnowflake(flakeHeight-20, 200);
                    DrawSnowflake(flakeHeight-18, 300);
                    DrawSnowflake(fasterFlakeHeight-35, 400);
                    DrawSnowflake(flakeHeight-70, 500);

                    g.FillEllipse(redBrush, 200, 130, 200, 100);
                    g.DrawString("CHRISTMAS!!!", christmansFont, brushVar, 200 + 20, 165);
                    g.FillEllipse(brushVar, xVariable + xSpeed, y + exponential, 40, 40);

                    flakeHeight += 4;
                    fasterFlakeHeight += 6;
                    exponential *= 1.35f;
                    xSpeed += xSpeedChanger;
                    Thread.Sleep(20);
                    
                }
            }
            this.Close();

        }
        //the following function moves a Text Rectangle. Who would've thunk.
        public void MoveTextRectangle(int xNumber, int yNumber, string Text)
        {
            g.Clear(Color.White);
            g.FillRectangle(blackBrush, xNumber, yNumber, 200, 100);
            g.DrawString(Text, cardFont, whiteBrush, xNumber + 20, yNumber + 20);
        }

        //this makes the first screen which you have to click on to trigger the animation
        private void Form1_Shown(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.FillEllipse(darkGoldenrodBrush, 60, 20, 500, 200);
            g.DrawString("The funky greeting Card.", frontPageFont, blackBrush, 160, 100);
        }

        //the following function draws a Snowflake using the provided height and xLocation
        public void DrawSnowflake(int height, int xLocation)
        {
            g.DrawLine(whitePen, 40+xLocation, 40+height, 100+xLocation, 100+height);
            g.DrawLine(whitePen, 40+xLocation, 100+height, 100+xLocation, 40+height);
            g.DrawLine(whitePen, 70+xLocation, 30+height, 70+xLocation, 110+height);
            g.DrawLine(whitePen, 30+xLocation, 70+height, 110+xLocation, 70+height);
        }

    }
}
