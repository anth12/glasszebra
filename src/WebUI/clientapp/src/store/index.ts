import Vue from 'vue'
import Vuex from 'vuex'
import { IGameDto } from '../client/api'

Vue.use(Vuex)

export interface StoreState{
  game: null | IGameDto;
  gameClientId: string;
  participantClientId: string;
}

export default new Vuex.Store({
  state: {
    game: null,
    gameClientId: localStorage.getItem('gameClientId'),
    participantClientId: localStorage.getItem('participantClientId')
  } as StoreState,
  mutations: {

    addGame(state, game: IGameDto){
      state.game = game;
    },

    addGameClientId(state, clientId: string) {
      state.gameClientId = clientId;
    },

    addParticipantClientId(state, clientId: string) {
      state.participantClientId = clientId;
    }
  },
  actions: {

    clear(context){
      context.dispatch('addGame', null);
      context.dispatch('addGameClientId', null);
      context.dispatch('addParticipantClientId', null);
    },

    addGame(context, game: IGameDto){
      context.commit('addGame', game);
    },

    addGameClientId(context, clientId: string) {
      localStorage.setItem('gameClientId', clientId);
      context.commit('addGameClientId', clientId);
    },

    addParticipantClientId(context, clientId: string) {
      localStorage.setItem('participantClientId', clientId);
      context.commit('addParticipantClientId', clientId);
    }
  },
  modules: {
  }
})
