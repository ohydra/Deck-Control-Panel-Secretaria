using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace Deck_Control_Panel
{

    public partial class Form1 : Form
    {
        double systemMemory;                            // MEMORIA RAM DO SISTEMA EM MB

        bool portsAvail = false;
        bool connected1 = false;
        PerformanceCounter cpuUsage;
        PerformanceCounter ramAvail;

        Random rnd = new Random();      //cria um numero random
        int rndnum1 = 0;
        int rndnum2 = 0;

        double cpuUse;
        double ramUsed;
        double ramFree;
        int horas;
        int minutos;

        SerialPort sp1;



        public Form1()
        {
            InitializeComponent();
            timerPortas.Start();
        }



        private async void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.CheckBoxSaver;  //carrega estado da checkbox da porta COM
            try     //conecta automatico
            {
                Hide();     //esconde o programa para o icon da tray quando arranca
                await Task.Delay(1000);
                if (portsAvail)     //executa automaticamente se existir portas COM abertas
                {
                    if (!connected1)        //VARIAVEL IGUAL A DE BAIXO DO BOTAO
                    {
                        //await Task.Delay(1000);

                        sp1.Open();
                        connected1 = true;
                        connButton.BackColor = Color.YellowGreen;
                        portComboBox.Enabled = false;
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = false;
                        radioButton3.Enabled = false;
                        pictureBox1.Image = Properties.Resources.img2;
                        connButton.Text = "Disconnect";
                        checkBox1.Enabled = false;
                        button_refresh.Enabled = false;
                        timer1.Start();
                        timerPortas.Stop();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Form1_Resize(object sender, EventArgs e)       //minimiza o programa para a tray
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)      //reabre o programa quando minimizado para a tray
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)      //botao para conectar/desconectar
        {
            try
            {
                if (portsAvail)
                {
                    if (!connected1)
                    {
                        sp1.Open();
                        connected1 = true;
                        connButton.BackColor = Color.YellowGreen;
                        portComboBox.Enabled = false;
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = false;
                        radioButton3.Enabled = false;
                        pictureBox1.Image = Properties.Resources.img2;
                        connButton.Text = "Disconnect";
                        checkBox1.Enabled = false;
                        button_refresh.Enabled = false;
                        timer1.Start();
                        timerPortas.Stop();
                        //MessageBox.Show("Serial port conectada.", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        sp1.Close();
                        sp1.Dispose();
                        connected1 = false;
                        connButton.BackColor = SystemColors.Control;
                        portComboBox.Enabled = true;
                        //radioButton1.Enabled = true;
                        //radioButton2.Enabled = true;
                        //radioButton3.Enabled = true;
                        radioButton1.Enabled = false;
                        radioButton2.Enabled = false;
                        radioButton3.Enabled = false;
                        pictureBox1.Image = Properties.Resources.img1;
                        connButton.Text = "Connect";
                        checkBox1.Enabled = true;
                        button_refresh.Enabled = true;
                        timer1.Stop();
                        timerPortas.Start();
                        progressBar1.Value = 1;
                        progressBar2.Value = 1;
                        labelHoras.Text = "--";
                        labelMinutos.Text = "--";

                        MessageBox.Show("Serial port desconectada!", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione primeiro uma porta COM.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void timer1_Tick(object sender, EventArgs e)    //inicia o timer quando conecetado
        {
            if (connected1)
            {
                try
                {

                    if (radioButton1.Checked)   //escolha do tamanho de memoria ram do sistema
                    {
                        systemMemory = 64000;
                    }
                    else if (radioButton2.Checked)
                    {
                        systemMemory = 32000;
                    }
                    else if (radioButton3.Checked)
                    {
                        systemMemory = 16000;
                    }

                    cpuUse = Math.Round(cpuUsage.NextValue());
                    ramUsed = Math.Round((systemMemory - ramAvail.NextValue()) * 0.001); //RECEBE EM MB E CONVERTE PARA GB
                    ramFree = Math.Round((ramAvail.NextValue()) * 0.001);                //
                    horas = DateTime.Now.Hour;
                    minutos = DateTime.Now.Minute;

                    rndnum1 = rnd.Next(1, 3);
                    rndnum2 = rnd.Next(1, 3);


                    //imprime nas labels
                    cpuUsageDisplayLabel.Text = cpuUse + " %";
                    ramUsageDisplayLabel.Text = ramUsed + " GB";
                    ramAvailDisplayLabel.Text = ramFree + " GB";
                    labelHoras.Text = horas.ToString();
                    labelMinutos.Text = minutos.ToString();
                    progressBar1.Value = rndnum1;
                    progressBar2.Value = rndnum2;


                    //SEND OVER SERIAL DISPLAY
                    //USO CPU + RAM USADA + RAM LIVRE + HORAS + MINUTOS
                    sp1.Write(cpuUse + "," + ramUsed + "," + ramFree + "," + horas + "," + minutos + ",");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void timer2_Tick(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) //CHECKBOX SELECIONADA
            {
                portComboBox.Enabled = false;
                portComboBox.ResetText();
                button_refresh.Enabled = false;

                try
                {
                    portsAvail = false;
                    portsAvail = true;

                    sp1 = new SerialPort("COM9", 9600); //define a porta COM fixa para a COM9

                    cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");       // percentagem de uso do cpu
                    ramAvail = new PerformanceCounter("Memory", "Available MBytes");                    //memoria do sistema disponivel
                    DateTime now = DateTime.Now;                                                        //para as horas e minutos
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else if (checkBox1.Checked == false) //CHECKBOX LIVRE
            {
                portComboBox.Enabled = true;
                button_refresh.Enabled = true;

                try
                {
                    portComboBox.DataSource = SerialPort.GetPortNames();

                    if (SerialPort.GetPortNames().Any())    //deteta se existe portas COM disponiveis
                    {
                        portsAvail = false;
                        portsAvail = true;

                        sp1 = new SerialPort(portComboBox.SelectedItem.ToString(), 9600); //passa a porta COM selecionada para a query

                        cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");       // percentagem de uso do cpu
                        ramAvail = new PerformanceCounter("Memory", "Available MBytes");                    //memoria do sistema disponivel
                        DateTime now = DateTime.Now;                                                        //para as horas e minutos
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }



        private void button_refresh_Click(object sender, EventArgs e)
        {
            portComboBox.ResetText();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.CheckBoxSaver = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }

}