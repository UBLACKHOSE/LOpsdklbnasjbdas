using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_3
{
    public class Enemy
    {
        public int x { get; set; }
        public int y {get; set; }
        public string avatar {get; set; }
        private int damage { get; set; }

        public Enemy(int _x = 0, int _y = 0, int _damage = 10)
        {
            x = _x;
            y = _y;
            damage = _damage;
            avatar = "E";
        }

        public string GetAvatar() 
        {
            return avatar;
        }


        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getDamage()
        {
            return damage;
        }


        public void Moving(int _x, int _y)
        {
            x = _x; y = _y;
        }

    }


    class Moving_Enemy : Enemy
    {
        public Moving_Enemy(int _x = 0, int _y = 0, int _damage = 10) : base(_x,_y,_damage) { 
            avatar= "M";
        }     


        public void Moving(int _x,int _y)
        {
            x = _x; y = _y;
        }
    }

}
