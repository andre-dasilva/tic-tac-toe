using System;

namespace tic_tac_toe
{
    public class TicTacToe
    {
        private Player _playerOne;
        private Player _playerTwo;

        public TicTacToe() { }

        public Player ReadPlayer()
        {
            string playerName;
            Console.Write("Name of the player: ");
            playerName = Console.ReadLine();

            string playerIcon;
            Console.Write("Icon for the player: ");
            playerIcon = Console.ReadLine();
            return new Player { Name = playerName, Icon = playerIcon };
        }

        public void Start()
        {
            Console.WriteLine("Player 1:");
            _playerOne = ReadPlayer();

            Console.WriteLine();

            Console.WriteLine("Player 2:");
            _playerTwo = ReadPlayer();

            InitializeGame();
        }

        public void InitializeGame()
        {
            DrawGame();
        }

        public void DrawGame()
        {
            Console.WriteLine();
            Console.Write("|");
        }
    }
}

