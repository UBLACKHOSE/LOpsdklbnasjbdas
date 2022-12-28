using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LR3_3;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int width = 10;
        int height = 10;
        Hero hero;
        List<Enemy> enemies { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            hero = new Hero("lol", "H");
            enemies = new List<Enemy>();
            Moving_Enemy m_e = new Moving_Enemy(6,6,10);
            Moving_Enemy m_e2 = new Moving_Enemy(5, 5, 10);
            Enemy e = new Enemy(4, 4, 10);
            enemies.Add(m_e);
            enemies.Add(m_e2);
            enemies.Add(e);
            Nickname.Content = "NickName:" + hero.getName();
            HP.Content = "HP:" + hero.hp;
            Print();
        }


        public Enemy proverka(int x, int y)
        {
            foreach (var enem in enemies)
            {
                if (enem.getX() == x && enem.getY() == y)
                {
                    return enem;
                }
            }
            return null;
        }
        public void Print()
        {
            grid1.Children.Clear();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == hero.getX() && j == hero.getY())
                    {
                        Button button_hero = new Button();
                        button_hero.Content = hero.getName();
                        button_hero.Background = new SolidColorBrush(Colors.GreenYellow);
                        grid1.Children.Add(button_hero);
                    }
                    else if ((i == width - 1 && j == height - 1) && (hero.getRiches() == false))
                    {
                        Button button = new Button();
                        button.Content ="$$$";
                        button.Background = new SolidColorBrush(Colors.Gold);
                        grid1.Children.Add(button);
                    }
                    else if (proverka(i, j) != null)
                    {
                        Button button_enemy = new Button();
                        button_enemy.Content = proverka(i, j).GetAvatar();
                        button_enemy.Background = new SolidColorBrush(Colors.Red);
                        grid1.Children.Add(button_enemy);
                    }
                    else
                    {
                        grid1.Children.Add(new Button());
                    }
                }
            }
            HP.Content = "HP:"+hero.hp;
            Nickname.Content = "Name:" + hero.nickname;
        }

        public void grid_KeyDown(object sender, KeyEventArgs e)
        {




            switch (e.Key.ToString())
            {
                case "W":
                    if (0 < hero.getX())
                    {
                        if (proverka(hero.getX() - 1, hero.getY()) != null)
                        {
                            hero.Hit(proverka(hero.getX() - 1, hero.getY()).getDamage());
                        }
                        else if (hero.getX() - 1 == width-1 && hero.getY() == height - 1)
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX() - 1, hero.getY());
                        }
                        else
                        {
                            hero.Moving(hero.getX() - 1, hero.getY());
                        }
                    }
                    break;
                case "D":
                    if (width - 1 > hero.getY())
                    {
                        if (proverka(hero.getX(), hero.getY() + 1) != null)
                        {
                            hero.Hit(proverka(hero.getX(), hero.getY() + 1).getDamage());
                        }
                        else if (hero.getX() == width - 1 && hero.getY() + 1 == height - 1)
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX(), hero.getY() + 1);
                        }
                        else
                        {
                            hero.Moving(hero.getX(), hero.getY() + 1);
                        }
                    }
                    break;
                case "S":
                    if (height-1 > hero.getX())
                    {

                        if (proverka(hero.getX() + 1, hero.getY()) != null)
                        {
                            hero.Hit(proverka(hero.getX() + 1, hero.getY()).getDamage());
                        }
                        else if (hero.getX() + 1 == width - 1 && hero.getY() == height - 1)
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX() + 1, hero.getY());
                        }
                        else
                        {
                            hero.Moving(hero.getX() + 1, hero.getY());
                        }
                    }
                    break;
                case "A":
                    if (0 < hero.getY())
                    {
                        if (proverka(hero.getX(), hero.getY() - 1) != null)
                        {
                            hero.Hit(proverka(hero.getX(), hero.getY() - 1).getDamage());
                        }
                        else if (hero.getX() == width - 1 && hero.getY() - 1 == height - 1)
                        {
                            hero.setRiches(true);
                            hero.Moving(hero.getX(), hero.getY() - 1);
                        }
                        else
                        {
                            hero.Moving(hero.getX(), hero.getY() - 1);
                        }


                    }
                    break;
            }

            MovingEnemy();
            Print();


            if (hero.hp <= 0)
            {
                MessageBox.Show("Ты проиграл");


                this.Close();
            }

            if (hero.getX() == 0 && hero.getY() == 0 && hero.getRiches())
            {
                MessageBox.Show("Ты победил");


                this.Close();
            }
        }


        public void MovingEnemy()
        {

            foreach (var en in enemies)
            {
                if (en.avatar == "M")
                {
                    var rand = new Random();
                    int directions = rand.Next(0,4);
                    switch (directions)
                    {
                        case 0:
                            if (0 < en.getX())
                            {
                                if (hero.getX() == en.getX() - 1 && hero.getY() == en.getY())
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX() - 1, en.getY()) == null)
                                {
                                    en.Moving(en.getX() - 1, en.getY());
                                }
                            }
                            break;
                        case 1:
                            if (width - 1 > en.getY())
                            {

                                if (hero.getX() == en.getX() && hero.getY() == en.getY() + 1)
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX(), en.getY() + 1) == null)
                                {
                                    en.Moving(en.getX(), en.getY() + 1);
                                }
                            }
                            break;
                        case 2:
                            if (height - 1 > en.getX())
                            {

                                if (hero.getX() == en.getX() + 1 && hero.getY() == en.getY())
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX() + 1, en.getY()) == null)
                                {
                                    en.Moving(en.getX() + 1, en.getY());
                                }
                            }
                            break;
                        case 3:
                            if (0 < en.getY())
                            {

                                if (hero.getX() == en.getX() && hero.getY() == en.getY() - 1)
                                {
                                    hero.Hit(en.getDamage());
                                }
                                else if (proverka(en.getX(), en.getY() - 1) == null)
                                {
                                    en.Moving(en.getX(), en.getY() - 1);
                                }
                            }
                            break;
                    }
                }
            }




        }

    }
}
