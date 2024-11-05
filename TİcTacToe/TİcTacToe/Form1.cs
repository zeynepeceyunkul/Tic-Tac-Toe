using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TİcTacToe
{
    public partial class Form1 : Form
    {

        public enum Player // Oyuncular için bir enum tanımlıyoruz: X ve O oyuncuları
        {
            X, O
        }

        Player currentPlayer; // Şu anki oyuncuyu takip eder
        Random random = new Random(); // CPU'nun rastgele hamle yapması için Random nesnesi
        int playerWinCount = 0; // Oyuncu kazanma sayısı
        int CPUWinCount = 0; // CPU kazanma sayısı
        List<Button> buttons; // Tüm butonları bir liste olarak saklar

        public Form1()
        {
            InitializeComponent();
            Restart(); // Oyunu başlatır
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if(buttons.Count > 0)
            {
                // Rastgele bir buton seç ve ona CPU'nun hamlesini işle
                int index = random.Next(buttons.Count);
                buttons[index].Enabled = false;
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.Silver;
                buttons.RemoveAt(index); // Seçilen butonu listeden kaldır
                CheckGame(); // Oyunun kazanma durumunu kontrol et
                CPUTimer.Stop(); // CPU'nun hamlesi bittiği için timer durdurulur
            }




        }

        private void PlayerClickButton(object sender, EventArgs e)
        {

            var button = (Button)sender;
            // Oyuncunun hamlesini işle
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.LightBlue;
            buttons.Remove(button); // Seçilen butonu listeden kaldır
            CheckGame(); // Oyunun kazanma durumunu kontrol et
            CPUTimer.Start(); // CPU'nun hamlesi için timer başlatılır

        }

        private void Restart(object sender, EventArgs e)
        {
            Restart();
        }

        private void CheckGame()
        {
            // Oyuncu X'in kazandığı durumları kontrol et
            if (button1.Text=="X" && button2.Text=="X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X" 
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins", "ZECE SAYS");
                playerWinCount++; // Oyuncu kazanma sayısını artır
                label1.Text = "Player Wins: " + playerWinCount;
                Restart(); // Oyunu yeniden başlat
            }
            // CPU'nun kazandığı durumları kontrol et
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                  || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                  || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                  || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                  || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                  || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                  || button3.Text == "O" && button5.Text == "O" && button7.Text == "O"
                )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins", "ZECE SAYS");
                CPUWinCount++; // CPU kazanma sayısını artır
                label2.Text = "CPU Wins: " + CPUWinCount;
                Restart(); // Oyunu yeniden başlat
            }

        }

        private void Restart() // Oyunu yeniden başlatan metod
        {
            // Butonları listeye ekler ve başlangıç durumuna getirir
            buttons = new List<Button> { button1,button2, button3, button4, button5, button6, button7,button8, button9};

            foreach(Button X in buttons)
            {
                X.Enabled = true; // Tüm butonları etkinleştir
                X.Text = "?"; // Metinleri başlangıç durumuna getir 
                X.BackColor = DefaultBackColor; // Renkleri sıfırla
            }
        }
    }
}
