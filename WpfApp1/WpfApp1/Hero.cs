using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_3
{
    public class Hero 
    {
        public string nickname { get; set; }
        public string avatar { get; set; }
        public int hp { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public bool riches { get; set; }

        public int getX()
        {
            return x;
        }

        public string getName()
        {
            return nickname;
        }

        public int getY()
        {
            return y;
        }

        public string getAvatar()
        {
            return avatar;
        }
        public bool getRiches()
        {
            return riches;
        }


        public Hero(string nick,string av,int _x = 0,int _y = 0, int _hp = 100)
        {
            x = _x;
            y = _y;
            hp = _hp;
            riches= false;
            nickname = nick;
            avatar = av;
        }
        
        public void Moving(int _x,int _y)
        {
            x=_x; y= _y;
        }

        public void Hit(int dam)
        {
            hp -= dam;
        }

        public void setRiches(bool info)
        {
            riches = info;
        }

        public string GetInfo() {
            return nickname + " hp:"+hp;
        }

    }
}
