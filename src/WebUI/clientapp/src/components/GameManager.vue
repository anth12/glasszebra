<template>
  <div>
    <button @click="exitGame">Exit</button>

    {{ game }}
    <Lobby v-if="game.Status == 'Lobby'" />
  </div>
</template>

<script lang="ts">
import store from "@/store";
import { Component, Vue } from 'vue-property-decorator';
import Lobby from '@/components/game/Lobby.vue'
import { GameClient, IGameClient } from '../client/api';

const client: IGameClient = new GameClient('https://localhost:44312');

@Component({
  components:{
    Lobby
  }
})
export default class GameManager extends Vue {

  get game() {
      return store.state.game;
  }

  exitGame(){
    //client.leave();
    
    store.dispatch('clear');
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
