import Vue from 'vue'
import Vuex from 'vuex'
import { GameDto, GamePlayerDto } from '../client/api'
import { GameHub } from '../hubs/gameHub';

Vue.use(Vuex)

export interface StoreState{
  game: null | GameDto;
  gameClientId: string;
  playerClientId: string;

  gameHub: GameHub;
}

export default new Vuex.Store({
  state: {
    game: null,
    gameClientId: localStorage.getItem('gameClientId'),
    playerClientId: localStorage.getItem('playerClientId')
  } as StoreState,
  mutations: {

    addGame(state, game: GameDto){
      state.game = game;
    },

    updatePlayer(state, player: GamePlayerDto){
      
      if (state.game?.players == null)
        return;

      const existigPlayerIndex = state.game.players.findIndex(p => p.id == player.id);

      if (existigPlayerIndex > -1)
        Object.assign(state.game.players[existigPlayerIndex], player);
      else
        state.game.players.push(player);
    },

    addGameClientId(state, clientId: string) {
      state.gameClientId = clientId;
    },

    addPlayerClientId(state, clientId: string) {
      state.playerClientId = clientId;
    }
  },
  actions: {

    clear(context){
      context.dispatch('addGame', null);
      context.dispatch('addGameClientId', null);
      context.dispatch('addPlayerClientId', null);
    },

    addGame(context, game: GameDto){
      context.commit('addGame', game);

      if (game != null && this.state.gameClientId != null){
        context.state.gameHub = new GameHub();
        context.state.gameHub.connect();
      }
    },

    addPlayer(context, game: GameDto){
      context.commit('addGame', game);

    },

    addGameClientId(context, clientId: string) {
      localStorage.setItem('gameClientId', clientId);
      context.commit('addGameClientId', clientId);
    },

    addPlayerClientId(context, clientId: string) {
      localStorage.setItem('playerClientId', clientId);
      context.commit('addPlayerClientId', clientId);
    }
  },
  modules: {
  }
})
