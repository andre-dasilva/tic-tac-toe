using System;
using System.Collections.Generic;

namespace tic_tac_toe
{
    public class TicTacToe
    {
        private char[,] board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        private List<int> usedPositions = new List<int>(9);
        private Player _playerOne;
        private Player _playerTwo;
        private Player _winner;

        public TicTacToe() { }

        public void Start()
        {
            ReadPlayers();
            ShowInstructions();
            Initialize();
        }

        public void ReadPlayers()
        {
            Console.WriteLine("Player 1:");
            _playerOne = ReadPlayer();
            Console.WriteLine("\n");
            Console.WriteLine("Player 2:");
            _playerTwo = ReadPlayer();
            Console.WriteLine("\n");
        }

        public Player ReadPlayer()
        {
            string playerName;
            Console.Write("Name of the player: ");
            playerName = Console.ReadLine();

            char playerIcon;
            Console.Write("Icon for the player: ");
            playerIcon = Console.ReadKey().KeyChar;
            return new Player { Name = playerName, Icon = playerIcon };
        }

        public void ShowInstructions()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe");
            Console.WriteLine("-----------------------\n");
            DrawBoard(new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } });
            Console.WriteLine("The numbers represent the positions for the input. In the game you just need to enter the position");
            Console.WriteLine("If you understood the instructions press enter...");
            Console.ReadKey();
            Console.WriteLine("\n");
        }

        public void DrawBoard(char[,] board)
        {
            Console.Write("    │    │       \n");
            Console.Write($"  {board[0, 0]} │  {board[0, 1]} │  {board[0, 2]}    \n");
            Console.Write("────┼────┼────\n");
            Console.Write($"  {board[1, 0]} │  {board[1, 1]} │  {board[1, 2]}    \n");
            Console.Write("────┼────┼────\n");
            Console.Write($"  {board[2, 0]} │  {board[2, 1]} │  {board[2, 2]}    \n");
            Console.Write("    │    │       \n");
            Console.Write("\n");
        }

        public void Initialize()
        {
            Console.WriteLine("Game starting...\n");
            PlayerQueue<Player> playerQueue = new PlayerQueue<Player>(2);
            playerQueue.Enqueue(_playerOne);
            playerQueue.Enqueue(_playerTwo);

            Player currentPlayer = playerQueue.GetNext();
            while (!CheckForWinner(currentPlayer))
            {
                DrawBoard(board);
                int position = ReadBoardPosition(currentPlayer);
                while (!InsertIntoBoard(currentPlayer, position))
                {
                    position = ReadBoardPosition(currentPlayer);
                }
                currentPlayer = playerQueue.GetNext();
            }
            if (_winner == null)
            {
                Console.WriteLine("It's a draw");
                Environment.Exit(0);
            }
            Console.WriteLine($"{_winner.Name} is the winner");
            Environment.Exit(0);
        }

        public int ReadBoardPosition(Player currentPlayer)
        {
            int position;
            Console.Write($"{currentPlayer.Name} enter a position (1-9): ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out position);
            return position;
        }

        public bool InsertIntoBoard(Player player, int position)
        {
            if (usedPositions.Contains(position))
            {
                return false;
            }
            else
            {
                usedPositions.Add(position);
            }

            switch (position)
            {
                case 1:
                    if (board[0, 0] == ' ')
                        board[0, 0] = player.Icon;
                    else
                        return false;
                    return true;
                case 2:
                    if (board[0, 1] == ' ')
                        board[0, 1] = player.Icon;
                    else
                        return false;
                    return true;
                case 3:
                    if (board[0, 2] == ' ')
                        board[0, 2] = player.Icon;
                    else
                        return false;
                    return true;
                case 4:
                    if (board[1, 0] == ' ')
                        board[1, 0] = player.Icon;
                    else
                        return false;
                    return true;
                case 5:
                    if (board[1, 1] == ' ')
                        board[1, 1] = player.Icon;
                    else
                        return false;
                    return true;
                case 6:
                    if (board[1, 2] == ' ')
                        board[1, 2] = player.Icon;
                    else
                        return false;
                    return true;
                case 7:
                    if (board[2, 0] == ' ')
                        board[2, 0] = player.Icon;
                    else
                        return false;
                    return true;
                case 8:
                    if (board[2, 1] == ' ')
                        board[2, 1] = player.Icon;
                    else
                        return false;
                    return true;
                case 9:
                    if (board[2, 2] == ' ')
                        board[2, 2] = player.Icon;
                    else
                        return false;
                    return true;
                default:
                    Console.WriteLine("The position is not valid. Only values from 1-9 are valid\n");
                    return false;
            }
        }

        public bool CheckForWinner(Player player)
        {
            // check if board is full
            if (usedPositions.Capacity == usedPositions.Count)
            {
                return true;
            }

            // check horizontal
            for (int x = 0; x < 3; x++)
            {
                if (board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2])
                {
                    _winner = player;
                    return true;
                }
            }
            // check vertically
            for (int y = 0; y < 3; y++)
            {
                if (board[0, y] == board[1, y] && board[1, y] == board[2, y])
                {
                    _winner = player;
                    return true;
                }
            }
            // check diagonally
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]
                || board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                _winner = player;
                return true;
            }
            return false;
        }
    }
}

