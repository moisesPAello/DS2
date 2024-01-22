using System.Numerics;

namespace TicTacToe
{
    internal class Program
    {
        public static int dimension = 3;
        static void Main(string[] args)
        {
            Tablero juego = new Tablero();
            juego.inicializarTablero();
            juego.juego();
                                                   
        }
    }

    public enum Ficha
    {
        vacio = '0',
        X,
        O
    }
    public class Casilla
    {
        private Ficha estado;
        public void setEstado(Ficha newEstado)
        { estado = newEstado;}
        public Ficha getEstado()
        { return estado;}
    }
    public class Tablero
    {
        private Casilla[,] tablero = new Casilla[Program.dimension, Program.dimension];
        public void inicializarTablero()
        {
            for (int i = 0; i < this.tablero.GetLength(0); i++)
            {
                for (int j = 0; j < this.tablero.GetLength(1); j++)
                {
                    this.tablero[i, j] = new Casilla();
                }
            }
        }
        public void imprimirTablero()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.Write(tablero[i, j].getEstado() + "  ");
                }
                Console.WriteLine();
            }
        }
        public void juego()
        {
            imprimirTablero();
            Console.WriteLine("(fila, columna)");
            string[] inputs = Console.ReadLine().Split(",");
            colocarFicha(int.Parse(inputs[0]), int.Parse(inputs[1]));
            juego();
        }

        private bool turno;
        public void setTurno(bool newTurno)
        { this.turno = newTurno; }
        public bool getTurno()
        { return this.turno; }
        public Ficha getJugador()
        { 
            return this.turno ? Ficha.O: Ficha.X;
        }


        private Ficha ganador;
        public void setGanador(Ficha newGanador)
        { this.ganador = newGanador; }
        public Ficha getGanador()
        {
            return this.turno ? Ficha.O : Ficha.X;
        }


        private bool gameOver = false;
        public void setGameOver(bool newGameOver)
        { this.gameOver = newGameOver;}
        public bool getGameOver()
        { return this.gameOver; }


        public void colocarFicha(int fila, int columna)
        {
            if (fila    < (Program.dimension) && fila >= 0 &&
                columna < (Program.dimension) && columna >= 0)
            {
                if (tablero[fila, columna].getEstado() == Ficha.vacio)
                    tablero[fila, columna].setEstado(getJugador());
            }
            else
            {
                Console.WriteLine(":p");
                juego();
            }

            validarGanador();
            setTurno(!getTurno());
        }
        public void validarGanador()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    //Check por fila
                    if (tablero[i, 0].getEstado() == getJugador() &&
                        tablero[i, 1].getEstado() == getJugador() &&
                        tablero[i, 2].getEstado() == getJugador() ||
                    //Check por columna
                        tablero[0, j].getEstado() == getJugador() &&
                        tablero[1, j].getEstado() == getJugador() &&
                        tablero[2, j].getEstado() == getJugador() ||
                    //Check diagonal \
                        tablero[0, 0].getEstado() == getJugador() &&
                        tablero[1, 1].getEstado() == getJugador() &&
                        tablero[2, 2].getEstado() == getJugador() ||
                    //Check diagonal /
                        tablero[0, 2].getEstado() == getJugador() &&
                        tablero[1, 1].getEstado() == getJugador() &&
                        tablero[2, 0].getEstado() == getJugador())
                    {
                        setGanador(getJugador());
                        setGameOver(true);
                    }
                }
            }
        }
    }
}
