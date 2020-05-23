<template>
  <div class="home">
    
    <div v-if="!isLoading">
    
      <JoinGame v-if="!hasActiveGame" />
      <CreateGame v-if="!hasActiveGame" />

      <GameManager v-if="hasActiveGame"/>
    </div>

    <div v-if="isLoading">
      Loading...
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
import { client } from '../client/api-factory';

@Component({
  name: 'Home',
  components: {
    JoinGame,
    CreateGame,
    GameManager
  }
})
export default class Home extends Vue {
  
  isLoading = true;

  get hasActiveGame() {
      return store.state.game != null;
  }

  mounted() {

    // Load existing game
    if(store.state.gameClientId == null) {
      this.isLoading = false;
      
    } else{
      console.log(`Loading existing game ${store.state.gameClientId}`);

      client.get(store.state.gameClientId).then(game=>{
        store.dispatch('addGame', game);

      }).catch(response=>{
        console.error('Failed to load existing game');
        console.error(response);

      }).then(()=>{
        this.isLoading = false;
      });
    }
  }
}
</script>
