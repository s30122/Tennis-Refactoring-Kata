namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private static readonly string[] PointsNames = new[]
        {
            "Love", "Fifteen", "Thirty", "Forty"
        };

        private int player2Score;
        private int player1Score;
        private string player1Name;
        private string player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var isEndGame = !((player1Score < 4 && player2Score < 4) && (player1Score + player2Score < 6));

            if (isEndGame)
            {
                if (player1Score == player2Score)
                    return "Deuce";

                var winner = player1Score > player2Score ? player1Name : player2Name;

                return ((player1Score - player2Score) * (player1Score - player2Score) == 1) ? "Advantage " + winner : "Win for " + winner;
            }
            else
            {
                var score = PointsNames[player1Score];

                return (player1Score == player2Score) ? score + "-All" : score + "-" + PointsNames[player2Score];
            }
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.player1Score += 1;
            else
                this.player2Score += 1;
        }

    }
}