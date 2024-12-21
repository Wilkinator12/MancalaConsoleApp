using MancalaLibrary.DataAccess.Repositories.Base;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MancalaLibrary.DataAccess.Repositories
{
    public class PlayerRepository : RepositoryBase, IRepository<PlayerModel>
    {
        public PlayerRepository(string connectionString) : base(connectionString) { }


        public bool Delete(int id)
        {
            if (PlayerIsInGame(id)) return false;


            string sqlStatement = "delete from Players where Id = @Id;";

            var parameters = new
            {
                Id = id
            };

            try
            {
                _db.SaveData(sqlStatement, parameters, _connectionString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PlayerModel Insert(PlayerModel entity)
        {
            string sqlStatement = "insert into Players (PlayerName, WinCount) values (@PlayerName, @WinCount);";

            var parameters = new
            {
                entity.PlayerName,
                entity.WinCount
            };

            entity.Id = _db.SaveSingle_AndLoadLastInsertedId(sqlStatement, parameters, _connectionString);

            return entity;
        }

        public List<PlayerModel> ReadAll()
        {
            string sqlStatement = "select * from Players;";

            return _db.LoadData<PlayerModel, dynamic>(sqlStatement, new { }, _connectionString);
        }

        public PlayerModel ReadById(int id)
        {
            string sqlStatement = "select * from Players where Id = @Id;";

            var parameters = new
            {
                Id = id
            };

            return _db.LoadData<PlayerModel, dynamic>(sqlStatement, parameters, _connectionString).First();
        }

        public PlayerModel Update(PlayerModel entity)
        {
            string sqlStatement = "update Players set PlayerName = @PlayerName, WinCount = @WinCount where Id = @Id;";

            _db.SaveData(sqlStatement, entity, _connectionString);

            return entity;
        }

        public PlayerModel Upsert(PlayerModel entity)
        {
            switch (entity.Id)
            {
                case 0:
                    return Insert(entity);
                default:
                    return Update(entity);
            }
        }



        private bool PlayerIsInGame(int id)
        {
            var allGames = new GameRepository(_connectionString).ReadAll();

            return allGames.SelectMany(g => g.GamePlayers).Any(gp => gp.PlayerInfo.Id == id);
        }
    }
}
