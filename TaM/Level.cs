using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TaM
{
    class Level
    {
        public string name;
        public int width;
        public int height;
        private string data;
        public Square[,] allMySquares;
        public int[] theseus;
        public int[] minotaur;
        public int[] exit;

        public Level(string name, int width, int height, string data)
        {
            this.name = name;
            this.width = width;
            this.height = height;
            this.data = data;
            this.allMySquares = new Square[height, width];
            DataReader(data);
            
        }

        public void DataReader(string data)
        {
            string[] dataArray = data.Split(' ');
            string Minotaur = dataArray[0];
            string Theseus = dataArray[1];
            string Exit = dataArray[2];

            for(int i = 3, y = 0; i < dataArray.Length & y < this.height;)
            { 
                for (int x = 0; x < this.width; x++, i++)
                {
                    Square sqaure = new Square(dataArray[i]);
                    allMySquares[y, x] = sqaure;
                }
                
                y++;
            }
            SetMinotaur(Minotaur);
            SetTheseus(Theseus);
            SetExit(Exit);
        }

        public void SetMinotaur(string data)
        {
            char[] minotaur = data.ToCharArray();

            int y = int.Parse(minotaur[0].ToString() + minotaur[1].ToString());
            int x = int.Parse(minotaur[2].ToString() + minotaur[3].ToString());

            allMySquares[y, x].Minotaur = true;
            this.minotaur = new int[] { y, x };

        }

        public void SetTheseus(string data)
        {  
            char[] theseus = data.ToCharArray(); 
            int y = int.Parse(theseus[0].ToString() + theseus[1].ToString());
            int x = int.Parse(theseus[2].ToString() + theseus[3].ToString());
            allMySquares[y, x].Theseus = true;
            this.theseus = new int[] { y, x };


        }
        public void SetExit(string data)
        { 
            char[] exit = data.ToCharArray();
            int y = int.Parse(exit[0].ToString() + exit[1].ToString());
            int x = int.Parse(exit[2].ToString() + exit[3].ToString());
            allMySquares[y, x].Exit = true;
            this.exit = new int[] { y, x };

        }
        public int[] GetTheseus()
        {
            return this.theseus;
        }
        public int[] GetMinotaur()
        {
            return this.minotaur;
        }
        public int[] GetExit()
        {
            return this.exit;
        }


    }
}
