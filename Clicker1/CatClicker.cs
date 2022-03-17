using System;
using System.Media;
using System.Windows.Forms;

namespace Clicker1
{
    public partial class CatClicker : Form
    {
        public long money { get; set; } = 0;
        public long gems { get; set; } = 0;
        public int chance { get; set; } = 0;
        public bool check { get; set; } = false;
        public bool check2 { get; set; } = false;
        public bool check3 { get; set; } = false;
        public int booster { get; set; } = 1;


        public int mCLevel { get; set; } = 1;
        public int moneyClick { get; set; } = 1;
        public long moneyClickCost { get; set; } = 1;
        public int costVal1 { get; set; } = 1;
        public int costVal2 { get; set; } = 2;
        public int costVal3 { get; set; } = 3;
        public int nextClickCost { get; set; } = 1;
        public int boosterLevelCost { get; set; } = 100;
        public int boosterLevel { get; set; } = 1;


        public int sumoCatCount { get; set; } = 0;
        public long sumoCatCost { get; set; } = 1000; // 10

        public int winterCatCount { get; set; } = 0;
        public long winterCatCost { get; set; } = 25000; // 200

        public int chineseCatCount { get; set; } = 0;
        public long chineseCatCost { get; set; } = 150000; // 1000

        public int kitlerCatCount { get; set; } = 0;
        public long kitlerCatCost { get; set; } = 500000; // 2500



        Random rd = new Random();

        SoundPlayer meowSong = new SoundPlayer(Properties.Resources.meowSong);
        SoundPlayer alarmTheme = new SoundPlayer(Properties.Resources.alarm);
        SoundPlayer chineseTheme = new SoundPlayer(Properties.Resources.chineseSong);

        public CatClicker()
        {
            InitializeComponent();
            this.button1.Image = Clicker1.Properties.Resources.politeCat;
            this.cat1.Image = Clicker1.Properties.Resources.bigCatto;
            this.cat2.Image = Clicker1.Properties.Resources.winterCat;
            this.cat3.Image = Clicker1.Properties.Resources.chineseCat;
            this.cat4.Image = Clicker1.Properties.Resources.kitlerCat;
            MCCost.Text = Convert.ToString(moneyClickCost);
            MBCost.Text = Convert.ToString(boosterLevelCost);
            sumoCost.Text = Convert.ToString(sumoCatCost);
            winterCost.Text = Convert.ToString(winterCatCost);
            chineseCost.Text = Convert.ToString(chineseCatCost);
            kitlerCost.Text = Convert.ToString(kitlerCatCost);
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            secondTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chance = rd.Next(1, 100);

            money += moneyClick*booster;
            if(chance == 1)
            {
                gems += 1;
            }
            else
            {

            }
            
            moneyTxt.Text = Convert.ToString(money);
            gemsTxt.Text = Convert.ToString(gems);
            errorBoard.Text = "";
        }

        private void MCButt_Click(object sender, EventArgs e)
        {
            if(money >= moneyClickCost)
            {
                money -= moneyClickCost;

                costVal1 += 1;
                costVal2 += 1;
                costVal3 += 1;

                moneyClickCost = ((costVal1 * costVal2 * costVal3) / 20);

                moneyClick += 1;

                mCLevel += 1;
                MCLevel_label.Text = Convert.ToString(mCLevel);
                moneyTxt.Text = Convert.ToString(money);
                MCCost.Text = Convert.ToString(moneyClickCost);
            }
            else
            {
                errorBoard.Text = "Not enough money for the money/click upgrade.";
            }
        }

        private void BoosterButt_Click(object sender, EventArgs e)
        {
            if (gems >= boosterLevelCost)
            {
                gems -= boosterLevelCost;

                boosterLevelCost = 100 + (boosterLevel * 100);

                booster += 1;

                boosterLevel += 1;
                BoosterLevel_label.Text = Convert.ToString(boosterLevel);
                gemsTxt.Text = Convert.ToString(gems);
                MBCost.Text = Convert.ToString(boosterLevelCost);
            }
            else
            {
                errorBoard.Text = "Not enough gems for the money booster upgrade.";
            }
        }

        private void secondTimer_Tick(object sender, EventArgs e)
        {
            money += sumoCatCount * 10 * booster;
            money += winterCatCount * 200 * booster;
            money += chineseCatCount * 1000 * booster ;
            money += kitlerCatCount * 2500 * booster ;


            moneyTxt.Text = Convert.ToString(money);
            gemsTxt.Text = Convert.ToString(gems);

        }

        private void sumoCatButt_Click(object sender, EventArgs e)
        {
            if (money >= sumoCatCost)
            {
                money -= sumoCatCost;
                sumoCatCount += 1;

                sumoCatCost = 1000 + (sumoCatCount * 1000);

                moneyTxt.Text = Convert.ToString(money);
                sumoCatCount_label.Text = Convert.ToString(sumoCatCount);
                sumoCost.Text = Convert.ToString(sumoCatCost);
            }
            else
            {
                errorBoard.Text = "Not enough money for the sumo cat.";
            }
        }

        private void winterCatButt_Click(object sender, EventArgs e)
        {
            if (money >= winterCatCost)
            {
                money -= winterCatCost;
                winterCatCount += 1;

                winterCatCost = 25000 + (winterCatCount * 25000);

                moneyTxt.Text = Convert.ToString(money);
                winterCatCount_label.Text = Convert.ToString(winterCatCount);
                winterCost.Text = Convert.ToString(winterCatCost);
            }
            else
            {
                errorBoard.Text = "Not enough money for the winter cat.";
            }
        }

        private void chineseCatButt_Click(object sender, EventArgs e)
        {
            if (money >= chineseCatCost)
            {
                radioButton2.Visible = true;

                money -= chineseCatCost;
                chineseCatCount += 1;

                chineseCatCost = 150000 + (chineseCatCount * 150000);

                moneyTxt.Text = Convert.ToString(money);
                chineseCatCount_label.Text = Convert.ToString(chineseCatCount);
                chineseCost.Text = Convert.ToString(chineseCatCost);
            }
            else
            {
                errorBoard.Text = "Not enough money for the chinese cat.";
            }
        }

        private void kitlerCatButt_Click(object sender, EventArgs e)
        {
            if (money >= kitlerCatCost)
            {
                radioButton3.Visible = true;

                money -= kitlerCatCost;
                kitlerCatCount += 1;

                kitlerCatCost = 500000 + (kitlerCatCount * 500000);

                moneyTxt.Text = Convert.ToString(money);
                kitlerCatCount_label.Text = Convert.ToString(kitlerCatCount);
                kitlerCost.Text = Convert.ToString(kitlerCatCost);
            }
            else
            {
                errorBoard.Text = "Not enough money for the kitler cat.";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            meowSong.PlayLooping();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            chineseTheme.PlayLooping();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            alarmTheme.PlayLooping();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
                meowSong.Stop();
                alarmTheme.Stop();
                chineseTheme.Stop();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            money += 1000000;
        }
    }
    
}
