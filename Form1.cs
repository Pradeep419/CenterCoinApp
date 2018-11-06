using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CenterCoinApp
{
    public partial class Form1 : Form
    {
        // public int[] cashAmts = new int[4] { 10, 10, 10, 10 };
        public List<int> cashAmts = new List<int> { 10, 10, 10, 10 };
        public String[] players = new String[4] { "A", "B", "C", "D" };
        public int betAmts;
        public string bet;
        public String playerWish = " ";
        public int pooledAmt = 0;
        Random r = new Random();
        public int count = 0;
        public int round = 1;
        public int winnerFlag = 0;
        //Form1 form = new Form1();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            poolingTheMoney();

            for (int i = 0; i < players.Length; i++)
            {
                if (i >= players.Length)
                {
                    break;
                }
                
                textBox5_TextChanged(sender, e);
                Thread.Sleep(1000);
                textBox6_TextChanged(sender, e);

                if (radioButton1.Checked)
                {

                    radioButton1_CheckedChanged(sender, e);


                }
                else if (radioButton2.Checked)
                {

                    radioButton2_CheckedChanged(sender, e);
                }

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int coin1 = r.Next(1, 90);
            String sCoin1 = coin1.ToString();
            textBox5.Text = sCoin1;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int coin2 = r.Next(1, 90);
            String sCoin2 = coin2.ToString();
            textBox6.Text = sCoin2;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                int playernum = count;
                betAmts = 5;
                Thread.Sleep(1000);
                textBox8.Text = betAmts.ToString();
                int tokenCoin = r.Next(1, 90);
                String sToken = tokenCoin.ToString();
                textBox7.Text = sToken;
                comparator(sender, e, tokenCoin, playernum);
                if (winnerFlag == 1)
                {
                    Application.Exit();
                }
                if (count < players.Length - 1)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    textBox5_TextChanged(sender, e);
                    Thread.Sleep(1000);
                    textBox6_TextChanged(sender, e);

                }
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                textBox8.Text = " ";
                textBox7.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                radioButton2.Checked = false;
                if (players[count].Equals("D"))
                {
                    count = 0;
                    MessageBox.Show($"Its {players[count]}'s turn");
                }
                else
                {
                    count = count + 1;
                    MessageBox.Show($"Its {players[count]}'s turn");
                }
            
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        public void comparator(object sender, EventArgs e, int i, int player)
        {
            if (player <= 3)
            {

                if (players.Length == 1)
                {
                    MessageBox.Show($"{players[0]} is the WINNER!!!");
                    winnerFlag = 1;
                }
                int coin1 = int.Parse(textBox5.Text);
                int coin2 = int.Parse(textBox6.Text);
                int token = i;
                int pooledAmt = int.Parse(textBox4.Text);
                int betAmt = int.Parse(textBox8.Text);
                if ((coin1 < token && token < coin2) || (coin2 < token && token < coin1))
                {
                    MessageBox.Show("Great!!! you won the amount");
                    pooledAmt = pooledAmt - betAmt;
                    cashAmts[player] = cashAmts[player] + betAmt;
                    if (players[player].Equals("A"))
                    {
                        InitialAmount1.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else if (players[player].Equals("B"))
                    {
                        textBox1.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else if (players[player].Equals("C"))
                    {
                        textBox2.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else
                    {
                        textBox3.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }

                    MessageBox.Show("Both Player's Amount and Pool Amount Updated");
                    radioButton1.Checked = false;
                    textBox8.Text = " ";
                    textBox7.Text = " ";
                    textBox5.Text = " ";
                    textBox6.Text = " ";
                    if (players.Length == 2 && player == 1)
                    {
                        MessageBox.Show($"Its {players[player - 1]}'s turn");

                    }
                    else if (players[player].Equals("A") || players[player].Equals("B") || players[player].Equals("C"))
                    {
                        MessageBox.Show($"Its {players[player + 1]}'s turn");
                    }
                    else if (players[player].Equals("D"))
                    {
                        MessageBox.Show("Its A's turn");
                    }

                }

                else
                {

                    MessageBox.Show("No, You lost the deal");
                    pooledAmt = pooledAmt + betAmt;
                    cashAmts[player] = cashAmts[player] - betAmt;

                    if (players[player].Equals("A"))
                    {
                        InitialAmount1.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else if (players[player].Equals("B"))
                    {
                        textBox1.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else if (players[player].Equals("C"))
                    {
                        textBox2.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    else
                    {
                        textBox3.Text = cashAmts[player].ToString();
                        textBox4.Text = pooledAmt.ToString();
                    }
                    Thread.Sleep(1000);
                    MessageBox.Show("Both Player's Amount and Pool Amount Updated");

                    if (cashAmts[player] <= 0)
                    {
                        MessageBox.Show($"{players[player]} removed from the match");

                        if (players[player].Equals("D"))
                        {
                            count = -1;
                            var playersList = new List<String>(players);
                            playersList.Remove(players[player]);
                            players = playersList.ToArray();
                            cashAmts.Remove(cashAmts[player]);
                            MessageBox.Show($"Its {players[0]}'s turn");
                        }
                        else
                        {
                            var playersList = new List<String>(players);
                            playersList.Remove(players[player]);
                            players = playersList.ToArray();
                            cashAmts.Remove(cashAmts[player]);
                            if (players.Length == 1)
                            {
                                MessageBox.Show($"{players[0]} is the WINNER!!!");
                                winnerFlag = 1;
                            }
                            MessageBox.Show($"Its {players[player]}'s turn");
                            count = count - 1;
                        }
                    }
                    else
                    {

                        if (players.Length == 2&&player==1)
                        {
                            MessageBox.Show($"Its {players[player-1]}'s turn");

                        }
                        else if (players[player].Equals("A") || players[player].Equals("B") || players[player].Equals("C"))
                        {
                            MessageBox.Show($"Its {players[player + 1]}'s turn");
                        }
                        
                    }

                    radioButton1.Checked = false;
                    textBox8.Text = " ";
                    textBox7.Text = " ";
                    textBox5.Text = " ";
                    textBox6.Text = " ";
                   

                }
            }
            else
            {
                //MessageBox.Show($"Round {round} completed");
                //round++;
                i = 0;
                count = -1;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitialAmount1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        //public void comparator(object sender, EventArgs e)
        //{
        //    String text = "Taking amount from all the Players";
        //    MessageBox.Show(text);
        //    pooledAmt = cashAmts[0] + cashAmts[1] + cashAmts[2] + cashAmts[3];
        //    String poolAmt = pooledAmt.ToString();
        //    textBox4.Text = poolAmt;

        //    for (int i = 0; i < players.Length; i++)
        //    {
        //        if (i >= players.Length)
        //        {
        //            break;
        //        }
        //        textBox5_TextChanged(sender, e);
        //        Thread.Sleep(1000);
        //        textBox6_TextChanged(sender, e);

        //        if (radioButton1.Checked)
        //        {
        //            MessageBox.Show("You clicked on YES");
        //            radioButton1_CheckedChanged(sender, e);
        //            int coin1 = int.Parse(textBox5.Text);
        //            int coin2 = int.Parse(textBox6.Text);
        //            int token = int.Parse(textBox7.Text);
        //            int pooledAmt = int.Parse(textBox4.Text);
        //            int betAmt = int.Parse(textBox8.Text);
        //            if ((coin1 < token && token < coin2) || (coin2 < token && token < coin1))
        //            {
        //                MessageBox.Show("Great!!! you won the amount");
        //                pooledAmt = pooledAmt - betAmt;
        //                cashAmts[i] = cashAmts[i] + betAmt;
        //                if (players[i].Equals("A"))
        //                {
        //                    InitialAmount1.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else if (players[i].Equals("B"))
        //                {
        //                    textBox1.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else if (players[i].Equals("C"))
        //                {
        //                    textBox2.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else
        //                {
        //                    textBox3.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }

        //                MessageBox.Show("Both Player's Amount and Pool Amount Updated");
        //                radioButton1.Checked = false;
        //                textBox8.Text = " ";
        //                textBox7.Text = " ";
        //                textBox5.Text = " ";
        //                textBox6.Text = " ";
        //                if (players[i].Equals("A") || players[i].Equals("B") || players[i].Equals("C"))
        //                {
        //                    MessageBox.Show($"Its {players[i + 1]}'s turn");
        //                }
        //            }

        //            else
        //            {
        //                MessageBox.Show("No, You lost the deal");
        //                pooledAmt = pooledAmt + betAmt;
        //                cashAmts[i] = cashAmts[i] - betAmt;

        //                if (players[i].Equals("A"))
        //                {
        //                    InitialAmount1.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else if (players[i].Equals("B"))
        //                {
        //                    textBox1.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else if (players[i].Equals("C"))
        //                {
        //                    textBox2.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                else
        //                {
        //                    textBox3.Text = cashAmts[i].ToString();
        //                    textBox4.Text = pooledAmt.ToString();
        //                }
        //                Thread.Sleep(1000);
        //                MessageBox.Show("Both Player's Amount and Pool Amount Updated");
        //                radioButton1.Checked = false;
        //                textBox8.Text = " ";
        //                textBox7.Text = " ";
        //                textBox5.Text = " ";
        //                textBox6.Text = " ";
        //                if (players[i].Equals("A") || players[i].Equals("B") || players[i].Equals("C"))
        //                {
        //                    MessageBox.Show($"Its {players[i + 1]}'s turn");
        //                }

        //            }
        //        }
        //        else if (radioButton2.Checked)

        //        {
        //            continue;
        //        }


        //    }

        //}
        public void poolingTheMoney()
        {

            String text = "Taking amount from all the Players";
            MessageBox.Show(text);
            pooledAmt = cashAmts[0] + cashAmts[1] + cashAmts[2] + cashAmts[3];
            String poolAmt = pooledAmt.ToString();
            textBox4.Text = poolAmt;
        }
    }
}
