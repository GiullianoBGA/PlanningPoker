using Microsoft.AspNetCore.SignalR;
using PlanningPokerBlazor.Shared;

namespace PlanningPokerBlazor.Server.Hubs
{
    public class GameHub : Hub
    {
        private static List<GamePlay> gamePlays = new();

        public async Task RegisterPlayerAsync2(RegisterPlayerRequest registerPlayerRequest)
        {
            var alreadyExists = gamePlays.Exists(ga => ga.HubConnectionId == Context.ConnectionId);

            if (alreadyExists)
                return;

            //Atualizar dados de Context.ConnectionId com o Game recebido
            if (RoomsCreated.RoomList.Any(x => x.GameId == registerPlayerRequest.Game.Id))
            {
                RoomsCreated.RoomList = RoomsCreated.RoomList.Where(x => x.GameId != null).ToList();
            }
            else
            {
                Room? room = RoomsCreated.RoomList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                room.GameId = registerPlayerRequest.Game.Id;
                room.Time = registerPlayerRequest.Game.Time;
                room.Sequence = registerPlayerRequest.Game.Sequence;
                room.GameType = registerPlayerRequest.Game.GameType;
            }

            if (registerPlayerRequest.Player.MemberType == EnumMemberType.Player)
            {
                Room roomPlayer = RoomsCreated.RoomList.First(x => x.GameId == registerPlayerRequest.Game.Id);

                if (!roomPlayer.PlayerColors.Any(x => x.IsAvailable))
                {
                    throw new Exception("Não existem mais cadeiras disponíveis nesta sala no momento!");
                }

                registerPlayerRequest.Player.PlayerColor = GetPlayerColor(roomPlayer.PlayerColors);
                registerPlayerRequest.Player.PlayerCSS = roomPlayer.PlayerCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
                registerPlayerRequest.Player.CardCSS = roomPlayer.CardCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
            }

            var gamePlay = new GamePlay
            {
                HubConnectionId = Context.ConnectionId,
                Game = registerPlayerRequest.Game,
                Player = registerPlayerRequest.Player,
                CardPlayed = new Card(),
                CardVoted = new Card(),
            };

            gamePlays.Add(gamePlay);

            await Groups.AddToGroupAsync(Context.ConnectionId, registerPlayerRequest.Game.Id);

            await UpdateGame(gamePlay.Game.Id, registerPlayerRequest.Game.GameType);
        }

        public async Task RegisterPlayerAsync(RegisterPlayerRequest registerPlayerRequest)
        {
            if (gamePlays.Exists(ga => ga.HubConnectionId == Context.ConnectionId))
                return;

            //Atualizar dados de Context.ConnectionId com o Game recebido
            if (RoomsCreated.RoomList.Any(x => x.GameId == registerPlayerRequest.Game.Id))
            {
                RoomsCreated.RoomList = RoomsCreated.RoomList.Where(x => x.GameId != null).ToList();
            }
            else
            {
                Room? room = RoomsCreated.RoomList.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                room.GameId = registerPlayerRequest.Game.Id;
                room.Time = registerPlayerRequest.Game.Time;
                room.Sequence = registerPlayerRequest.Game.Sequence;
                room.GameType = registerPlayerRequest.Game.GameType;
            }

            if (registerPlayerRequest.Player.MemberType == EnumMemberType.Player)
            {
                Room roomPlayer = RoomsCreated.RoomList.First(x => x.GameId == registerPlayerRequest.Game.Id);

                if (!roomPlayer.PlayerColors.Any(x => x.IsAvailable))
                {
                    throw new Exception("Não existem mais cadeiras disponíveis nesta sala no momento!");
                }

                registerPlayerRequest.Player.PlayerColor = GetPlayerColor(roomPlayer.PlayerColors);
                registerPlayerRequest.Player.PlayerCSS = roomPlayer.PlayerCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
                registerPlayerRequest.Player.CardCSS = roomPlayer.CardCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
            }

            var gamePlay = new GamePlay
            {
                HubConnectionId = Context.ConnectionId,
                Game = registerPlayerRequest.Game,
                Player = registerPlayerRequest.Player,
                CardPlayed = new Card(),
                CardVoted = new Card(),
            };

            gamePlays.Add(gamePlay);

            await Groups.AddToGroupAsync(Context.ConnectionId, registerPlayerRequest.Game.Id);

            await UpdateGame(gamePlay.Game.Id, registerPlayerRequest.Game.GameType);
        }

        public async Task UnregisterPlayerAsync(RegisterPlayerRequest registerPlayerRequest)
        {
            if (!gamePlays.Exists(ga => ga.HubConnectionId == Context.ConnectionId))
                return;

            //Atualizar dados de Context.ConnectionId com o Game recebido

            var t = gamePlays.Where(x => x.Game.Id == registerPlayerRequest.Game.Id && x.Player.Id == registerPlayerRequest.Player.Id).ToList();

            Room roomPlayer = RoomsCreated.RoomList.First(x => x.GameId == registerPlayerRequest.Game.Id);
            //if (registerPlayerRequest.Player.MemberType == EnumMemberType.Player)
            //{

            //    if (!roomPlayer.PlayerColors.Any(x => x.IsAvailable))
            //    {
            //        throw new Exception("Não existem mais cadeiras disponíveis nesta sala no momento!");
            //    }

            //    registerPlayerRequest.Player.PlayerColor = GetPlayerColor(roomPlayer.PlayerColors);
            //    registerPlayerRequest.Player.PlayerCSS = roomPlayer.PlayerCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
            //    registerPlayerRequest.Player.CardCSS = roomPlayer.CardCSSes.First(x => x.Id == registerPlayerRequest.Player.PlayerColor.Id);
            //}
            //            remover jogador

            var gamePlay = new GamePlay
            {
                HubConnectionId = Context.ConnectionId,
                Game = registerPlayerRequest.Game,
                Player = registerPlayerRequest.Player,
                CardPlayed = new Card(),
                CardVoted = new Card(),
            };

            gamePlays.Remove(gamePlay);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, registerPlayerRequest.Game.Id);

            await UpdateGame(gamePlay.Game.Id, registerPlayerRequest.Game.GameType);
        }

        public async Task PlayCardAsync(PlayCardRequest playCardRequest)
        {
            var gamePlay = gamePlays.FirstOrDefault(ga => ga.HubConnectionId == Context.ConnectionId);

            if (gamePlay == null)
                return;

            gamePlay.CardPlayed = new Card()
            {
                Color = "white",
                Flipped = false,
                Text = "0",
                Value = "0"
            };

            gamePlay.CardVoted = playCardRequest.CardPlayed;

            await UpdateGame(gamePlay.Game.Id);
        }

        public async Task FlipCardAsync()
        {
            if (gamePlays == null || !gamePlays.Any())
            {
                return;
            }

            foreach (var gamePlay in gamePlays)
            {
                gamePlay.CardPlayed.Flipped = true;
            }

            //await UpdateGame(gamePlays.First().Game.Id);
        }

        public async Task ResetGame(ResetGameRequest resetGameRequest)
        {
            var gamesPlaysForThisGame = gamePlays.Where(gp => gp.Game.Id == resetGameRequest.Game.Id).ToList();
            gamesPlaysForThisGame.ForEach(gp =>
            {
                gp.CardPlayed = new Card();
                gp.CardVoted = new Card();
            });

            await UpdateGame(resetGameRequest.Game.Id, resetGameRequest.PlayerType);
        }

        public override Task OnConnectedAsync()
        {
            RoomsCreated.RoomList.Add(new Room(Context.ConnectionId));

            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var gamePlay = gamePlays.FirstOrDefault(ga => ga.HubConnectionId == Context.ConnectionId);

            if (gamePlay != null)
            {
                gamePlays.Remove(gamePlay);
                await UpdateGame(gamePlay.Game.Id);
            }

            var room = RoomsCreated.RoomList.FirstOrDefault(x => x.GameId == gamePlay.Game.Id && gamePlay.Player.MemberType == EnumMemberType.Player);
            if (room != null)
                room.PlayerColors.First(x => x.Id == gamePlay.Player.PlayerColor.Id).IsAvailable = true;

            if (gamePlays.Count(x => x.Game.Id == gamePlay.Game.Id) == 0)
            {
                if (RoomsCreated.RoomList.Count(x => x.GameId == gamePlay.Game.Id) <= 1)
                    RoomsCreated.RoomList.Remove(RoomsCreated.RoomList.FirstOrDefault(x => x.GameId == gamePlay.Game.Id));
            }

            await base.OnDisconnectedAsync(exception);
        }

        //private async Task UpdateGame(string gameId)
        //{
        //    var gamesPlaysForThisGame = gamePlays.Where(gp => gp.Game.Id == gameId);

        //    await Clients.Group(gameId).SendAsync("UpdateGame", gamesPlaysForThisGame);
        //}

        private async Task UpdateGame(string gameId, EnumPlayerType? playerType = null)
        {
            var gamesPlaysForThisGame = gamePlays.Where(gp => gp.Game.Id == gameId);

            await Clients.Group(gameId).SendAsync("UpdateGame", new UpdateGameRequest() { GamePlays = gamesPlaysForThisGame, PlayerType = playerType });
        }

        private PlayerColor GetPlayerColor(List<PlayerColor> playerColors)
        {
            PlayerColor playerColor = new();
            if (playerColors.Count(x => x.IsAvailable) <= 1)
            {
                playerColor = playerColors.FirstOrDefault(x => x.IsAvailable);
                playerColor.IsAvailable = false;

                return playerColor;
            }
            else
            {
                var disponiveis = playerColors.Where(x => x.IsAvailable).ToList();

                var random = new Random();
                int newId = random.Next(0, disponiveis.Count);

                playerColor = disponiveis[newId];
                playerColor.IsAvailable = false;

                return playerColor;
            }
        }
    }
}
