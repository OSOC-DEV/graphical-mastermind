using System;

namespace mastermind_gui
{
    public class Randnum
    {
        public int Randint(int low, int high)
        {
            Random random = new Random();
            int randnum = random.Next(low, high);
            return randnum;
        }
    }
}
