<template>
  <div class="game" v-loading="isLoading">
    
    <div v-if="!isLoading">
    
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
import { gameService } from '@/services/gameService';

@Component({
  name: 'Game',
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
      this.$router.push("Home");      
    } else{
      console.log(`Loading existing game ${store.state.gameClientId}`);

      gameService.loadGame().catch(err=>{
        console.error('Failed to load existing game. Returning home');
        this.$router.push({ name: "Home" }); 

      }).then(()=>{
        store.commit('isLoading', false);
      });
    }
  }
}
</script>

<style scoped>

</style>