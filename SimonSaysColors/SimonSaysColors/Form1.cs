/* INTEGRANTES
 Alvarez Lucas (26929)
 Enora Joel (27092)
 Tande Matías (27148)
 Zarate Franco (27098)
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SimonGame
{
    public partial class Form1 : Form
    {
        //Lista de botones
        private List<Button> buttonList;
        //Patron de colores
        private List<int> patron;
        //Indice actual en el patron
        private int patronIndex;
        //Generador de numeros aleatorios
        private Random random;
        //Indica si es el turno del jugador
        private bool playerTurn;
        //Indica si el juego ha terminado
        private bool gameOver;

        public Form1()
        {
            InitializeComponent();
            //Agregar evento Click al boton Iniciar
            buttonIniciar.Click += buttonIniciar_Click;

            //Inicializar variables
            buttonList = new List<Button> { buttonGreen, buttonRed, buttonBlue, buttonYellow };
            patron = new List<int>();
            patronIndex = 0;
            random = new Random();
            playerTurn = false;
            gameOver = false;

            //Intervalo de 1 segundo entre colores
            timer.Interval = 1000;
            timer.Tick += MostarSiguienteColor;
        }

        //Metodo para manejar el evento Click del botón Iniciar
        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            if (!playerTurn)
            {
                StartGame();
            }
        }

        //Metodo para manejar el evento Click de los botones de colores
        private void button_Click(object sender, EventArgs e)
        {
            if (playerTurn && !gameOver)
            {
                Button clickedButton = (Button)sender;
                int buttonIndex = buttonList.IndexOf(clickedButton);

                if (buttonIndex == patron[patronIndex])
                {
                    patronIndex++;

                    if (patronIndex == patron.Count)
                    {
                        playerTurn = false;
                        patronIndex = 0;
                        AgregarColor();
                        MostrarPatron();
                    }
                }
                else
                {
                    GameOver();
                }
            }
        }

        //Metodo para iniciar el juego
        private void StartGame()
        {
            patron.Clear();
            patronIndex = 0;
            playerTurn = false;
            gameOver = false;

            AgregarColor();
            MostrarPatron();
        }

        //Metodo para agregar un nuevo color al patron
        private void AgregarColor()
        {
            int randomIndex = random.Next(0, buttonList.Count);
            patron.Add(randomIndex);
        }

        //Metodo para mostrar el patron de colores al jugador
        private void MostrarPatron()
        {
            playerTurn = false;
            timer.Start();
        }

        //Metodo para mostrar el siguiente color del patron
        private void MostarSiguienteColor(object sender, EventArgs e)
        {
            timer.Stop();

            if (patronIndex < patron.Count)
            {
                int buttonIndex = patron[patronIndex];
                Button button = buttonList[buttonIndex];
                ResaltarButton(button);
                patronIndex++;
                timer.Start();
            }
            else
            {
                playerTurn = true;
                patronIndex = 0;
                MessageBox.Show("¡Es tu turno! Repite la secuencia de colores.");
            }
        }

        //Metodo para resaltar un boton especifico durante un tiempo determinado
        private void ResaltarButton(Button button)
        {
            Color originalColor = button.BackColor;
            button.BackColor = Color.White;
            Refresh();
            //Mantener el color iluminado durante 0.5 segundos
            Thread.Sleep(500);
            button.BackColor = originalColor;
            Refresh();
            //Esperar 0.5 segundos antes de pasar al siguiente color
            Thread.Sleep(500);
        }

        //Metodo para manejar el error del jugador en la carga de la secuencia
        private void GameOver()
        {
            gameOver = true;
            MessageBox.Show("¡Has perdido! Intentalo de nuevo.");
            StartGame();
        }
    }
}