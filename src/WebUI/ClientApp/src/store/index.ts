import Vue from 'vue'
import Vuex from 'vuex'
import { Notification } from 'element-ui';
import { GameDto, GamePlayerDto, ValidationException, GameStatus } from '../client/api'
import { GameHub } from '../hubs/gameHub';
import { gameClient } from '@/client/api-factory';

Vue.use(Vuex)

export interface StoreState{

  isLoading: boolean;
  validation: { [key: string]: string[] };

  game: null | GameDto;
  gameClientId: string;
  playerClientId: string;
  playerId: null | number;

  gameHub: GameHub;
}

export default new Vuex.Store({
  state: {
    isLoading: true,
    validation: {},
    game: null,
    gameClientId: localStorage.getItem('gameClientId'),
    playerClientId: localStorage.getItem('playerClientId'),
    playerId: parseInt(localStorage.getItem('playerId') || "-1")
  } as StoreState,
  mutations: {

    isLoading(state, isLoading: boolean) {
      state.isLoading = isLoading;
    },

    addValidation(state, errors) {
      state.validation = errors;
    },

    addGame(state, game: GameDto){
      state.game = game;
    },

    removePlayer(state, playerId: number) {

      if (state.game?.players == null)
        return;

      const existigPlayerIndex = state.game.players.findIndex(p => p.id == playerId);

      if (existigPlayerIndex > -1)
        state.game.players.splice(existigPlayerIndex, 1);

    },

    updatePlayer(state, player: GamePlayerDto){
      
      if (state.game?.players == null)
        return;

      const existigPlayerIndex = state.game.players.findIndex(p => p.id == player.id);

      if (existigPlayerIndex > -1)
        Object.assign(state.game.players[existigPlayerIndex], player);
      else {
        state.game.players.push(player);
        Notification.success({ 
          title: "New player",
          dangerouslyUseHTMLString: true,
          message: `<strong>${player.name}</strong> has joined!`,
          position: 'bottom-right'
          });
      }
    },

    addGameClientId(state, clientId: string) {
      state.gameClientId = clientId;
    },

    addPlayerClientId(state, clientId: string) {
      state.playerClientId = clientId;
    },

    addPlayerId(state, playerId: number) {
      state.playerId = playerId;
    }

  },

  getters: {
    sortedPlayerList(state: StoreState) {
      if (state.game?.status == GameStatus.Lobby)
        return state.game?.players?.sort((a, b) => a.name?.localeCompare(b.name || '') || 0);
      else
        return state.game?.players?.sort((a, b) => (a.totalScore || 0) - (b.totalScore || 0));
    },

    isGameOwner(state: StoreState){
      if(state.playerId == null || state.game == null || state.game.players == null) {
        return false;
      }

      return state.game.players.filter(p=> p.isOwner && p.id == state.playerId).length == 1;
    },

    currentPlayer(state: StoreState) {
      if (state.playerId == null || state.game == null || state.game.players == null) {
        return null;
      }

      return state.game.players.filter(p => p.id == state.playerId)[0] || null;
    },

    getValidationError: state => 
    (property: string) =>
      Object.prototype.hasOwnProperty.call(state.validation, property)
      ? state.validation[property]
      : []
    
  },

  actions: {

    addValidation(context, error){
      if(error instanceof ValidationException && error.errors != null)
        context.commit('addValidation', error.errors);
      else
        context.commit('addValidation', {});
    },

    clear(context){
      context.dispatch('addGame', null);
      context.dispatch('addGameClientId', null);
      context.dispatch('addPlayerClientId', null);
      context.dispatch('addPlayerId', null);
    },

    addGame(context, game: GameDto){
      context.commit('addGame', game);

      if (game != null && this.state.gameClientId != null){
        context.state.gameHub = new GameHub();
        context.state.gameHub.connect();
      }
    },

    loadGame(context){
      gameClient.get(context.state.gameClientId).then(game => {

        const playerExists = game.players?.some(p => p.id == context.state.playerId);

        if (playerExists)
          context.dispatch('addGame', game);
        else
          context.dispatch('clear');

      }).catch(response => {
        console.error('Failed to load existing game');
        console.error(response);

      }).then(() => {
        context.commit('isLoading', false);
      });
    },
    
    updateGame(context, game: GameDto) {
      context.commit('addGame', game);
    },

    updatePlayer(context, player: GamePlayerDto){
      context.commit('updatePlayer', player);
    },

    removePlayer(context, playerId: number) {
      if(context.getters.currentPlayer.id == playerId) {
        // Booted
        context.dispatch('clear');
      } else {
        context.commit('removePlayer', playerId);
      }

    },

    addGameClientId(context, clientId: string) {
      localStorage.setItem('gameClientId', clientId);
      context.commit('addGameClientId', clientId);
    },

    addPlayerClientId(context, clientId: string) {
      localStorage.setItem('playerClientId', clientId);
      context.commit('addPlayerClientId', clientId);
    },

    addPlayerId(context, playerId: null | number) {
      localStorage.setItem('playerId', (playerId || 0).toString());
      context.commit('addPlayerId', playerId);
    }
  },
  modules: {
  }
})
