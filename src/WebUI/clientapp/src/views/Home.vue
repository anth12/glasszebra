<template>
  <div class="home" v-loading="isLoading">
    
    <div v-if="!isLoading">
    
      <JoinGame v-if="!hasActiveGame" />
      <CreateGame v-if="!hasActiveGame" />

      <GameManager v-if="hasActiveGame"/>
    </div>

  </div>
</template>

<script lang="ts">
// @ is an alias to /src
import { Component, Prop, Vue } from 'vue-property-decorator';
import store from "@/store";
import JoinGame from '@/components/JoinGame.vue'
import CreateGame from '@/components/CreateGame.vue'
import GameManager from '@/components/GameManager.vue'
import { gameClient } from '@/client/api-factory';

@Component({
  name: 'Home',
  components: {
    JoinGame,
    CreateGame,
    GameManager
  }
})
export default class Home extends Vue {
  
  get isLoading() {
      return store.state.isLoading;
  }

  get hasActiveGame() {
      return store.state.game != null;
  }

  mounted() {

    // Load existing game
    if(store.state.gameClientId == null) {
      store.commit('isLoading', false);
      
    } else{
      console.log(`Loading existing game ${store.state.gameClientId}`);

      gameClient.get(store.state.gameClientId).then(game=>{
        
        const playerExists = game.players?.some(p=> p.id == store.state.playerId);

        if(playerExists)
          store.dispatch('addGame', game);
        else
          store.dispatch('clear');

      }).catch(response=>{
        console.error('Failed to load existing game');
        console.error(response);

      }).then(()=>{
        store.commit('isLoading', false);
      });
    }
  }
}
</script>

<style scoped>

</style>