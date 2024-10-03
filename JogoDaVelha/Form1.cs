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
    public partial class JogoDaVelha : Form
    {
        Form2 form2;

        public JogoDaVelha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.Beep(900, 300);
            MessageBox.Show("Iniciando o melhor jogo! ⚔️ 💙", "!Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Console.Beep(1500, 100);
            form2 = new Form2();
            form2.ShowDialog();
        }

        private void JogoDaVelha_Load(object sender, EventArgs e)
        {

        }
    }
}
