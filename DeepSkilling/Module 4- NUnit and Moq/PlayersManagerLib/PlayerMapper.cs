using System.Data.SqlClient;

namespace PlayersManagerLib
{
    public class PlayerMapper : IPlayerMapper
    {
        private readonly string _connectionString =
            "Data Source=(local);Initial Catalog=GameDB;Integrated Security=True";

        public bool IsPlayerNameExistsInDb(string name)
        {
            // Dummy implementation for the exercise.
            return false;
        }

        public void AddNewPlayerIntoDb(string name)
        {
            // Dummy implementation for the exercise.
        }
    }
}