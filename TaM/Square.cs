using System;
using System.Collections.Generic;
using System.Text;

namespace TaM
{
    public class Square
    {
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;
        public bool Theseus;
        public bool Exit;
        public bool Minotaur;



        public Square(string data)
        {
            this.Top = false;
            this.Bottom = false;
            this.Left = false;
            this.Right = false;
            this.Theseus = false;
            this.Exit = false;
            this.Minotaur = false;
            SetWalls(data);
        }

        //reading the string to set the walls
        void SetWalls(string data)
        {
            char[] walls = data.ToCharArray();
            
            if (walls[0] == '1')
            {
                this.Top = true;
            }

            if (walls[1] == '1')
            {
                this.Right = true;
            }

            if (walls[2] == '1')
            {
                this.Bottom = true;
            }

            if (walls[3] == '1')
            {
                this.Left = true;
            }

        }
    }
}
