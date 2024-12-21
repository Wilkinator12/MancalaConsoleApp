using MancalaLibrary.DataAccess.Models;
using MancalaLibrary.DataAccess.Models.Mappers;
using MancalaLibrary.DataAccess.Repositories.Base;
using MancalaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MancalaLibrary.DataAccess.Repositories
{
    public class GameRepository : RepositoryBase, IRepository<GameModel>
    {
        private readonly IRepository<PlayerModel> _playerRepository;

        public GameRepository(string connectionString) : base(connectionString)
        {
            _playerRepository = new PlayerRepository(connectionString);
        }



        public bool Delete(int id)
        {
            string sqlStatement = "delete from Games where Id = @Id;";

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

        public GameModel Insert(GameModel entity)
        {
            // Insert Games Table entry
            string sqlStatement = "insert into Games (CurrentPlayerTurnIndex, StartDate) values (@CurrentPlayerTurnIndex, @StartDate);";

            var parameters = new
            {
                entity.CurrentPlayerTurnIndex,
                StartDate = entity.StartDate.ToString()
            };

            entity.Id = _db.SaveSingle_AndLoadLastInsertedId(sqlStatement, parameters, _connectionString);

            InsertAllGamePlayers(entity);

            return entity;
        }

        public List<GameModel> ReadAll()
        {
            string sqlStatement = "select * from Games;";

            List<GameModel> output = _db.LoadData<GamesTableModel, dynamic>(sqlStatement, new { }, _connectionString).ToGameModel();

            foreach (var gameModel in output)
            {
                gameModel.GamePlayers = ReadAllGamePlayers(gameModel);
            }

            return output;
        }

        public GameModel ReadById(int id)
        {
            string sqlStatement = "select * from Games where Id = @Id;";

            var parameters = new
            {
                Id = id
            };

            GameModel output = _db.LoadData<GamesTableModel, dynamic>(sqlStatement, parameters, _connectionString).First().ToGameModel();

            output.GamePlayers = ReadAllGamePlayers(output);

            return output;
        }

        public GameModel Update(GameModel entity)
        {
            string sqlStatement = "update Games set CurrentPlayerTurnIndex = @CurrentPlayerTurnIndex where Id = @Id;";

            var parameters = new
            {
                entity.Id,
                entity.CurrentPlayerTurnIndex
            };

            _db.SaveData(sqlStatement, parameters, _connectionString);



            foreach (var gamePlayer in entity.GamePlayers)
            {
                UpdateStoreSeedCount(gamePlayer);
                UpdateAllPitSeedCounts(gamePlayer);
            }



            return entity;
        }

        public GameModel Upsert(GameModel entity)
        {
            switch (entity.Id)
            {
                case 0:
                    return Insert(entity);
                default:
                    return Update(entity);
            }
        }







        private void InsertAllGamePlayers(GameModel entity)
        {
            string sqlStatement = "insert into GamePlayers (GameId, PlayerId, TurnIndex) values (@GameId, @PlayerId, @TurnIndex);";

            for (int i = 0; i < entity.GamePlayers.Count; i++)
            {
                GamePlayerModel currentGamePlayer = entity.GamePlayers[i];

                var parameters = new
                {
                    GameId = entity.Id,
                    PlayerId = currentGamePlayer.PlayerInfo.Id,
                    TurnIndex = i
                };

                currentGamePlayer.Id = _db.SaveSingle_AndLoadLastInsertedId(sqlStatement, parameters, _connectionString);

                InsertGamePlayerStore(currentGamePlayer);
                InsertAllGamePlayerPits(currentGamePlayer);
            }
        }

        private void InsertGamePlayerStore(GamePlayerModel entity)
        {
            string sqlStatement = "insert into GamePlayerStores (GamePlayerId, SeedCount) values (@GamePlayerId, @SeedCount);";

            var parameters = new
            {
                GamePlayerId = entity.Id,
                entity.Store.SeedCount
            };

            _db.SaveData(sqlStatement, parameters, _connectionString);
        }

        private void InsertAllGamePlayerPits(GamePlayerModel entity)
        {
            string sqlStatement = "insert into GamePlayerPits (GamePlayerId, PositionIndex, SeedCount) values (@GamePlayerId, @PositionIndex, @SeedCount);";

            for (int i = 0; i < entity.Pits.Count; i++)
            {
                var currentPitSeedCount = entity.Pits[i].SeedCount;

                var parameters = new
                {
                    GamePlayerId = entity.Id,
                    PositionIndex = i,
                    SeedCount = currentPitSeedCount
                };

                _db.SaveData(sqlStatement, parameters, _connectionString);
            }
        }


        private List<GamePlayerModel> ReadAllGamePlayers(GameModel gameModel)
        {
            List<GamePlayerModel> output = new List<GamePlayerModel>();


            string sqlStatement = @"select gp.* from GamePlayers gp
                                    inner join Games g on g.Id = gp.GameId
                                    where gp.GameId = @Id
                                    order by TurnIndex;";

            var parameters = new
            {
                gameModel.Id
            };

            List<GamePlayersTableModel> gamePlayersTableModels = _db.LoadData<GamePlayersTableModel, dynamic>(sqlStatement, parameters, _connectionString);

            foreach (var gamePlayersTableModel in gamePlayersTableModels)
            {
                var gamePlayerModel = new GamePlayerModel()
                {
                    Id = gamePlayersTableModel.Id,
                    PlayerInfo = _playerRepository.ReadById(gamePlayersTableModel.PlayerId)
                };



                gamePlayerModel.Store.SeedCount = ReadStoreSeedCount(gamePlayersTableModel);



                var seedCounts = ReadAllPitSeedCounts(gamePlayersTableModel);

                foreach (var seedCount in seedCounts)
                {
                    var newPit = new CupModel()
                    {
                        CupType = CupType.Pit,
                        SeedCount = seedCount
                    };

                    gamePlayerModel.Pits.Add(newPit);
                }



                output.Add(gamePlayerModel);
            }

            return output;
        }

        private List<int> ReadAllPitSeedCounts(GamePlayersTableModel gamePlayersTableModel)
        {
            string sqlStatement = @"select gpp.SeedCount from GamePlayerPits gpp
                                    inner join GamePlayers gp on gp.Id = gpp.GamePlayerId
                                    where gp.Id = @Id
                                    order by PositionIndex;";

            var parameters = new
            {
                gamePlayersTableModel.Id
            };

            return _db.LoadData<int, dynamic>(sqlStatement, parameters, _connectionString);
        }

        private int ReadStoreSeedCount(GamePlayersTableModel gamePlayersTableModel)
        {
            string sqlStatement = @"select gps.SeedCount from GamePlayerStores gps
                                    inner join GamePlayers gp on gp.Id = gps.GamePlayerId
                                    where gp.Id = @Id;";

            var parameters = new
            {
                gamePlayersTableModel.Id
            };

            return _db.LoadData<int, dynamic>(sqlStatement, parameters, _connectionString).First();
        }


        private void UpdateAllPitSeedCounts(GamePlayerModel gamePlayer)
        {
            string sqlStatement = @"update GamePlayerPits set SeedCount = @SeedCount 
                                    where GamePlayerId = @GamePlayerId and PositionIndex = @PositionIndex;";

            for (int i = 0; i < gamePlayer.Pits.Count; i++)
            {
                var currentPitSeedCount = gamePlayer.Pits[i].SeedCount;

                var parameters = new
                {
                    GamePlayerId = gamePlayer.Id,
                    PositionIndex = i,
                    SeedCount = currentPitSeedCount
                };

                _db.SaveData(sqlStatement, parameters, _connectionString);
            }
        }

        private void UpdateStoreSeedCount(GamePlayerModel gamePlayer)
        {
            string sqlStatement = "update GamePlayerStores set SeedCount = @SeedCount where GamePlayerId = @GamePlayerId;";

            var parameters = new
            {
                GamePlayerId = gamePlayer.Id,
                gamePlayer.Store.SeedCount
            };

            _db.SaveData(sqlStatement, parameters, _connectionString);
        }
    }
}
