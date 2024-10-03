using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha
{
    public partial class Form2 : Form
    {
        JogoDaVelha form1;

        int Xplayer = 0, Oplayer = 0, velhapontos = 0, rodadas = 0;
        bool turno = true, jogoFinal = false;
        string[] texto = new string[9];

        private void button11_Click(object sender, EventArgs e)
        {
            Console.Beep(900, 300);
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            rodadas = 0;
            jogoFinal = false;
            for (int i = 0; i < 9; i++)
            {
                texto[i] = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Console.Beep(900, 300);
            DialogResult result = MessageBox.Show("O placar sera perdido. Deseja continuar?", "!Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            Console.Beep(1500, 100);

            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep(900, 300);

            Button button1 = (Button)sender;
            int buttonindex = button1.TabIndex;

            if (button1.Text == "" && jogoFinal == false)
            {
                if (turno)
                {
                    button1.Text = "⚔️";
                    texto[buttonindex] = button1.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(1);
                }
                else
                {
                    button1.Text = "💙";
                    texto[buttonindex] = button1.Text;
                    rodadas++;
                    turno = !turno;
                    Checagem(2);
                }
            }
        }

        void vencedor(int playerQueGanhou)
        {
            jogoFinal = true;

            if (playerQueGanhou == 1)
            {
                Xplayer++;
                Xpontos.Text = Convert.ToString(Xplayer);
                MessageBox.Show("Jogador ⚔️ ganhou!");
                Console.Beep(1500, 100);
                turno = true;
            }
            else
            {
                Oplayer++;
                Opontos.Text = Convert.ToString(Oplayer);
                MessageBox.Show("Jogador 💙 ganhou!");
                Console.Beep(1500, 100);
                turno = false;
            }
        }
        void Checagem(int checagemPlayer)
        {
            string suporte = "";

            if (checagemPlayer == 1)
            {
                suporte = "⚔️";
            }
            else
            {
                suporte = "💙";
            }
            for (int horizontal = 0; horizontal < 8; horizontal += 3)
            {
                if (suporte == texto[horizontal])
                {
                    if (texto[horizontal] == texto[horizontal + 1] && texto[horizontal] == texto[horizontal + 2])
                    {
                        vencedor(checagemPlayer);
                        return;
                    }
                }
            }
            for (int vertical = 0; vertical < 3; vertical++)
            {
                if (suporte == texto[vertical])
                {
                    if (texto[vertical] == texto[vertical + 3] && texto[vertical] == texto[vertical + 6])
                    {
                        vencedor(checagemPlayer);
                        return;
                    }
                }
            }

            if (texto[0] == suporte)
            {
                if (texto[0] == texto[4] && texto[0] == texto[8])
                {
                    vencedor(checagemPlayer);
                    return;
                }
            }
            if (texto[2] == suporte)
            {
                if (texto[2] == texto[4] && texto[2] == texto[6])
                {
                    vencedor(checagemPlayer);
                    return; ;
                }
            }

            if (rodadas == 9 && jogoFinal == false)
            {
                velhapontos++;
                velha.Text = Convert.ToString(velhapontos);
                MessageBox.Show("DEU VÉIA! ⚰️👵");
                Console.Beep(1500, 100);
                jogoFinal = true;
                return;
            }
        }

    }
}
